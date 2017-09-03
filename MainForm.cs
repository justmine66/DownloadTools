using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DownloadTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region 直接下载

        private async void btnDirectDownload_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                using (var httpClient = new HttpClient())
                {
                    string downloadUri = tbDownloadUri.Text;
                    var responseMsg = await httpClient.GetAsync(downloadUri, HttpCompletionOption.ResponseHeadersRead);
                    using (var responseStream = await responseMsg.Content.ReadAsStreamAsync())
                    {
                        int readChunkSize = 1024 * 1024;//每次下载1M(真实情况下,请根据带宽,文件大小智能计算)
                        var buffer = new byte[readChunkSize];
                        int writeChunkSize;
                        long contentSize = responseMsg.Content.Headers.ContentLength.Value;
                        var fileFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, (ulong)DateTime.Now.ToBinary() + ".zip");
                        if (File.Exists(fileFullName)) File.Delete(fileFullName);
                        var beginTime = DateTime.UtcNow;
                        long downloadedSize = 0;

                        while ((writeChunkSize = await responseStream.ReadAsync(buffer, 0, readChunkSize)) > 0)
                        {
                            using (var fileStream = new FileStream(fileFullName, FileMode.Append, FileAccess.Write))
                            {
                                await fileStream.WriteAsync(buffer, 0, writeChunkSize);
                            }

                            downloadedSize += writeChunkSize;
                            int downloadSpeed = Math.Max((int)(downloadedSize * 100 / contentSize), 1);

                            this.pbDownloadNotificationInvoke(pbDownloadSpeed1, downloadSpeed);

                            var endTime = DateTime.UtcNow;
                            var fileSizeUnitDesc = this.doGetFileSizeUnitDesc((long)(downloadedSize / endTime.Subtract(beginTime).TotalSeconds));
                            string speedText = "下载速度: " + fileSizeUnitDesc.result + fileSizeUnitDesc.unit + "/S";
                            this.pbDownloadNotificationInvoke(lbSpreedMsg1, speedText);

                            if (contentSize == downloadedSize)//下载完成
                            {
                                stopwatch.Stop();
                                this.pbDownloadNotificationInvoke(pbDownloadSpeed1, 100);
                                var downSizeUnitDesc = this.doGetFileSizeUnitDesc(downloadedSize);
                                string compMsg = "下载完成,耗时: " + (int)stopwatch.Elapsed.TotalSeconds + "秒,文件大小: " + downSizeUnitDesc.result + downSizeUnitDesc.unit;
                                this.pbDownloadNotificationInvoke(lbSpreedMsg1, compMsg);
                                //未完善：验证文件是否与服务器一致
                            }
                        }
                    }
                }
            });
        }

        #endregion

        #region 断点续传

        //是否暂停
        static bool isPause = true;
        //范围起始
        static long rangeFrom;
        //前一次文件实体标识
        static string preETag;
        //文件在服务器上的最后修改时间
        static DateTimeOffset? preLastModified;
        //用时监控
        static Stopwatch stopwatchForbpr;
        //区间请求作为规范定义在HTTP规范中
        //通过请求的Range报头来携带分区信息,采用的格式为:“bytes={from}-{to}”({from}和{to}分别表示区间开始和结束的位置),
        //返回的内容=>在整个资源的位置通过响应报头Content-Range表示,采用的格式为“{from}-{to}/{length}”;分区所采用的计量单位,通过响应报头“Accept-Ranges”.
        private async void btnBreakpointResume_Click(object sender, EventArgs e)
        {
            isPause = !isPause;
            if (!isPause)
            {
                btnBreakpointResume.Text = "暂停";
                if (rangeFrom == 0)
                {
                    stopwatchForbpr = new Stopwatch();
                    stopwatchForbpr.Start();
                }

                await Task.Run(async () =>
                {
                    using (var httpClient = new HttpClient())
                    {
                        string downloadUri = tbDownloadUri.Text;
                        var requestMsg = new HttpRequestMessage(HttpMethod.Get, downloadUri);
                        requestMsg.Headers.Range = new RangeHeaderValue(rangeFrom, null);
                        var responseMsg = await httpClient.SendAsync(requestMsg, HttpCompletionOption.ResponseHeadersRead);

                        if (!this.isAcceptRange(responseMsg) || this.isServerFileChanged(responseMsg))
                            return;
                        preETag = responseMsg.Headers.ETag.Tag;
                        preLastModified = responseMsg.Content.Headers.LastModified;

                        using (var responseStream = await responseMsg.Content.ReadAsStreamAsync())
                        {
                            int readChunkSize = 1024 * 1024;//每次下载1M(真实情况下,请根据带宽,文件大小智能计算)
                            var buffer = new byte[readChunkSize];
                            int writeChunkSize;
                            //文件总大小
                            long contentSize = responseMsg.Content.Headers.ContentRange.Length.Value;
                            var fileFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "breakpointResumeTest.zip");//文件需一致
                            if (rangeFrom == 0 && File.Exists(fileFullName))
                                File.Delete(fileFullName);
                            var beginTime = DateTime.UtcNow;

                            while ((writeChunkSize = await responseStream.ReadAsync(buffer, 0, readChunkSize)) > 0 && !isPause)
                            {
                                using (var fileStream = new FileStream(fileFullName, FileMode.Append, FileAccess.Write))
                                {
                                    await fileStream.WriteAsync(buffer, 0, writeChunkSize);
                                }

                                rangeFrom += writeChunkSize;
                                int downloadSpeed = Math.Max((int)(rangeFrom * 100 / contentSize), 1);
                                //进度条
                                this.pbDownloadNotificationInvoke(pbDownloadSpeed2, downloadSpeed);

                                var endTime = DateTime.UtcNow;
                                string speedText = "下载速度: " + (rangeFrom / 1024) / endTime.Subtract(beginTime).TotalSeconds + " KB/S";
                                this.pbDownloadNotificationInvoke(lbSpreedMsg2, speedText);

                                if (contentSize == rangeFrom)//下载完成
                                {
                                    rangeFrom = 0;
                                    isPause = true;
                                    this.pbDownloadNotificationInvoke(btnBreakpointResume, "断点续传");
                                    this.pbDownloadNotificationInvoke(pbDownloadSpeed2, 100);
                                    if (stopwatchForbpr != null)
                                    {
                                        stopwatchForbpr.Stop();
                                        var fileSizeDesc = this.doGetFileSizeUnitDesc(contentSize);
                                        string compMsg = "下载完成,耗时: " + (int)stopwatchForbpr.Elapsed.TotalSeconds + "秒,文件大小: " + fileSizeDesc.result + fileSizeDesc.unit;
                                        this.pbDownloadNotificationInvoke(lbSpreedMsg2, compMsg);
                                    }
                                    //未完善：验证文件是否与服务器一致
                                }
                            }
                        }
                    }
                });
            }
            else
            {
                btnBreakpointResume.Text = "继续下载";
                lbSpreedMsg2.Text = string.Empty;
            }
        }

        #endregion

        #region 分片下载
        //步骤：
        //    1、发送请求，获取服务器上文件的总长度
        //    2、根据总长度，计算出分片起始位置，多线程下载
        //    3、下载完成，合并分片成一个完整的文件
        //    4、验证文件是否与服务器一致
        private void btnSliceDownload_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    string downloadUri = tbDownloadUri.Text;
                    HttpResponseMessage responseMsg = await httpClient.GetAsync(downloadUri, HttpCompletionOption.ResponseHeadersRead);
                    //支持断点续传才能分片下载
                    if (!this.isAcceptRange(responseMsg) || this.isServerFileChanged(responseMsg))
                        return;
                    long? contentInfo = responseMsg.Content.Headers.ContentLength;
                    if (contentInfo.HasValue)
                    {
                        long sliceNumber = 10;//正式环境，需根据分片算法计算出合理的分片数。
                        long contentSize = contentInfo.Value;
                        long sliceUnitSize = contentSize / sliceNumber;
                        var sliceTasks = new Task[sliceNumber];
                        var cancelationTokenSource = new CancellationTokenSource();

                        for (int i = 0; i < sliceNumber; i++)
                        {
                            long rangefrom = sliceUnitSize * i;
                            long rangeTo = sliceUnitSize * (i + 1);

                            Task sliceTask = this.BuildRequestSliceTaskAsync(
                                i + 1,//分片序号需大于0
                                downloadUri,
                                rangefrom, rangeTo,
                                cancelationTokenSource.Token);

                            sliceTasks[i] = sliceTask;
                        }

                        string slicesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tempSlices");
                        try
                        {
                            //1、等待所有的分片任务完成
                            Task.WaitAll(sliceTasks);
                            //2、合并分片成一个完整的文件
                            await this.SlicesMergeAsync(slicesDir, (ulong)DateTime.Now.ToBinary() + ".zip");
                            Directory.Delete(slicesDir);//删除临时目录
                        }
                        catch (Exception ex)
                        {
                            cancelationTokenSource.Cancel();//出现异常取消下载
                            Directory.Delete(slicesDir);//删除临时目录
                            throw ex;
                        }
                    }
                }
            });
        }
        //分片下载任务
        private Task BuildRequestSliceTaskAsync(
            int sliceNo,
            string downloadUrl,
            long rangefrom, long rangeTo,
            CancellationToken cancellationToken)
        {
            var task = Task.Run(async () =>
            {
                if (string.IsNullOrWhiteSpace(downloadUrl))
                    throw new ArgumentNullException(nameof(downloadUrl));
                if (sliceNo <= 0)
                    throw new ArgumentException(nameof(sliceNo));
                if (rangeFrom < 0)
                    throw new ArgumentException(nameof(rangeFrom));
                if (rangeTo <= 0)
                    throw new ArgumentException(nameof(rangeTo));

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                using (var httpClient = new HttpClient())
                {
                    var requestMsg = new HttpRequestMessage(HttpMethod.Get, downloadUrl);
                    requestMsg.Headers.Range = new RangeHeaderValue(rangeFrom, rangeTo);
                    HttpResponseMessage responseMsg = await httpClient.SendAsync(requestMsg, HttpCompletionOption.ResponseHeadersRead);

                    using (var responseStream = await responseMsg.Content.ReadAsStreamAsync())
                    {
                        string tempSlicesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tempSlices");
                        if (!Directory.Exists(tempSlicesDir)) Directory.CreateDirectory(tempSlicesDir);
                        string fileFullName = Path.Combine(tempSlicesDir, sliceNo.ToString());
                        if (File.Exists(fileFullName)) File.Delete(fileFullName);

                        int readChunkSize = 1024 * 1024;//每次下载1M(真实情况下,请根据带宽,文件大小智能计算)
                        var buffer = new byte[readChunkSize];
                        int writeChunkSize;
                        long sliceContentSize = responseMsg.Content.Headers.ContentLength.Value;
                        var beginTime = DateTime.UtcNow;
                        long downloadedSize = 0;

                        while ((writeChunkSize = await responseStream.ReadAsync(buffer, 0, readChunkSize)) > 0)
                        {
                            using (var fileStream = new FileStream(fileFullName, FileMode.Append, FileAccess.Write))
                            {
                                await fileStream.WriteAsync(buffer, 0, writeChunkSize);
                            }

                            downloadedSize += writeChunkSize;
                            int downloadSpeed = Math.Max((int)(downloadedSize * 100 / sliceContentSize), 1);
                            //进度条,进度提示
                            var sliceDownloadSpeedPb = this.GetControl(this, "pbDownloadSpeed" + sliceNo);
                            var sliceSpreedMsgLb = this.GetControl(this, "lbSpreedMsg" + sliceNo);
                            this.pbDownloadNotificationInvoke(sliceDownloadSpeedPb, downloadSpeed);

                            var endTime = DateTime.UtcNow;
                            string speedText = "下载速度: " + (downloadedSize / 1024) / endTime.Subtract(beginTime).TotalSeconds + " KB/S";
                            this.pbDownloadNotificationInvoke(sliceSpreedMsgLb, speedText);

                            if (sliceContentSize == downloadedSize)//下载完成
                            {
                                this.pbDownloadNotificationInvoke(pbDownloadSpeed2, 100);
                                if (stopwatch != null)
                                {
                                    stopwatch.Stop();
                                    string compMsg = "下载完成,耗时: " + (int)stopwatch.Elapsed.TotalSeconds + "秒,文件大小: " + downloadedSize / 1024 + " KB";
                                    this.pbDownloadNotificationInvoke(sliceSpreedMsgLb, compMsg);
                                }
                                //未完善：验证文件是否与服务器一致
                            }
                        }
                    }
                }
            }, cancellationToken);
            return task;
        }
        //分片文件合并
        private Task SlicesMergeAsync(string dirPath, string resultFileName)
        {
            var task = Task.Run(async () =>
            {
                var slicePaths = Directory.GetFiles(dirPath)
                .OrderBy(slicePath => int.Parse(Path.GetFileNameWithoutExtension(slicePath)));

                if (slicePaths != null)
                {
                    foreach (var slicePath in slicePaths)
                    {
                        if (string.IsNullOrWhiteSpace(slicePath)
                        || !File.Exists(slicePath))
                            return;

                        using (var fileStream = new FileStream(
                        Directory.GetParent(dirPath).FullName,
                        FileMode.Append, FileAccess.Write))
                        {
                            byte[] buffer = File.ReadAllBytes(slicePath);
                            await fileStream.WriteAsync(buffer, 0, buffer.Length);
                        }
                        File.Delete(slicePath);
                    }
                }
            });

            return task;
        }
        #endregion

        //检查服务器是否支持断点续传
        //思路：
        //    区间请求作为标准定义在HTTP规范中。
        //    响应报文头:Accept-Ranges=>标识分区所采用的计量单位(一般为“bytes”)。报头值为“none”,标识服务端不支持区间请求。
        private bool isAcceptRange(HttpResponseMessage responseMessage)
        {
            //判断标准：当服务器不支持请求部分数据时，都会返回 Accept-Ranges: none。
            if (responseMessage.Headers.AcceptRanges != null)
            {
                if (responseMessage.Headers.AcceptRanges.Contains("none"))
                    return false;
            }
            return true;
        }
        //检查服务器端文件是否变化
        //思路一：
        //      客户端保存响应报文头(ETag和Last-Modified),每次下载时,判断文件是否改变.
        //思路二：
        //      条件请求作为标准定义在HTTP规范中
        //      客户端保存响应报文头(ETag和Last-Modified),每次请求时,将Last-Modified作为请求头If-Modified-Since的值,
        //同理,Last-Modified作为请求头If-None-Match的值,对服务器进行条件请求.
        //说明：本次示例,采用思路一.
        private bool isServerFileChanged(HttpResponseMessage responseMessage)
        {
            if (preLastModified == null && string.IsNullOrEmpty(preETag))//第一次下载.
            {
                return false;
            }

            //判断标准：ETag 和 Last-Modified都相同,则文件未改变。
            var currETag = responseMessage.Headers.ETag.Tag;
            DateTimeOffset? lastModified = responseMessage.Content.Headers.LastModified;
            if (!string.IsNullOrWhiteSpace(currETag) && preETag == currETag
                && lastModified != null && preLastModified == lastModified)
            {
                return false;//文件未改变，可以断点续传
            }
            return true;
        }
        private void pbDownloadNotificationInvoke(Control control, object value)
        {
            control.Invoke((Action)(() =>
            {
                if (control is ProgressBar)
                {
                    int.TryParse(value + string.Empty, out int iValue);
                    (control as ProgressBar).Value = Math.Min(iValue, 100);
                }
                if (control is Label)
                {
                    control.Text = value + string.Empty;
                }
                if (control is Button)
                {
                    control.Text = value + string.Empty;
                }
            }));
        }
        private Control GetControl(Form container, string controlName)
        {
            for (int i = 0; i < container.Controls.Count; i++)
            {
                var result = container.Controls[i];
                if (result != null && result.Name.Equals(controlName))
                    return result;
            }
            return null;
        }
        private (double result, string unit) doGetFileSizeUnitDesc(long downloadedSize)
        {
            //小于1KB
            if (downloadedSize < 1024)
                return (downloadedSize, "B");
            //1KB <= downloadedSize < 小于1M
            else if (1024 <= downloadedSize && downloadedSize < Math.Pow(1024, 2))
                return (Math.Round((double)downloadedSize / 1024, 2), "KB");
            //1M <= downloadedSize < 1G
            else if (Math.Pow(1024, 2) <= downloadedSize && downloadedSize < Math.Pow(1024, 3))
                return (Math.Round((double)downloadedSize / Math.Pow(1024, 2), 2), "M");
            else
                return (Math.Round((double)downloadedSize / Math.Pow(1024, 3), 2), "G");
        }
    }
}
