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

        private async void btnDirectDownload_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    string downloadUri = tbDownloadUri.Text;
                    var responseMsg = await httpClient.GetAsync(downloadUri, HttpCompletionOption.ResponseHeadersRead);
                    using (var responseStream = await responseMsg.Content.ReadAsStreamAsync())
                    {
                        int readChunkSize = 1024 * 1024;//每次下载1M
                        var buffer = new byte[readChunkSize];
                        int writeChunkSize;
                        long contentSize = responseMsg.Content.Headers.ContentLength.Value;
                        var fileFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToBinary() + ".zip");
                        if (File.Exists(fileFullName)) File.Delete(fileFullName);
                        int beginSecond = DateTime.Now.Second;
                        long downloadedSize = 0;

                        while ((writeChunkSize = await responseStream.ReadAsync(buffer, 0, readChunkSize)) > 0)
                        {
                            using (var fileStream = new FileStream(fileFullName, FileMode.Append, FileAccess.Write))
                            {
                                await fileStream.WriteAsync(buffer, 0, writeChunkSize);
                            }

                            downloadedSize += writeChunkSize;
                            pbDownloadSpeed.Invoke((Action)(() =>
                            {
                                int downloadSpeed = Math.Max((int)(downloadedSize * 100 / contentSize), 1);
                                this.pbDownloadNotificationInvoke(pbDownloadSpeed, downloadSpeed);
                            }));

                            int endSecond = DateTime.Now.Second;
                            if (beginSecond != endSecond)
                            {
                                beginSecond = endSecond;
                                lbSpreedMsg.Invoke((Action)(() =>
                                {
                                    string speedText = "下载速度: " + (downloadedSize / 1024) + " KB/S";
                                    this.pbDownloadNotificationInvoke(lbSpreedMsg, speedText);
                                }));
                            }

                            if (contentSize == downloadedSize)//下载完成
                            {
                                this.pbDownloadNotificationInvoke(pbDownloadSpeed, 100);
                                this.pbDownloadNotificationInvoke(lbSpreedMsg, string.Empty);
                                //未完善：验证文件是否与服务器一致
                            }
                        }
                    }
                }
            });
        }

        //是否暂停
        static bool isPause = true;
        //范围起始
        static long rangeFrom;
        //前一次文件实体标识
        static string preETag;
        //文件在服务器上的最后修改时间
        static DateTimeOffset? preLastModified;
        private async void btnBreakpointResume_Click(object sender, EventArgs e)
        {
            isPause = !isPause;
            if (!isPause)
            {
                btnBreakpointResume.Text = "暂停";
                Stopwatch stopwatch = null;
                if (rangeFrom == 0)
                {
                    stopwatch = new Stopwatch();
                    stopwatch.Start();
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
                            int readChunkSize = 1024 * 1024;//每次下载1M
                            var buffer = new byte[readChunkSize];
                            int writeChunkSize;
                            long contentSize = responseMsg.Content.Headers.ContentLength.Value;
                            var fileFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp.zip");
                            if (File.Exists(fileFullName)) File.Delete(fileFullName);
                            int beginSecond = DateTime.Now.Second;

                            while ((writeChunkSize = await responseStream.ReadAsync(buffer, 0, readChunkSize)) > 0 && !isPause)
                            {
                                using (var fileStream = new FileStream(fileFullName, FileMode.Append, FileAccess.Write))
                                {
                                    await fileStream.WriteAsync(buffer, 0, writeChunkSize);
                                }

                                rangeFrom += writeChunkSize;
                                pbDownloadSpeed.Invoke((Action)(() =>
                                {
                                    int downloadSpeed = Math.Max((int)(rangeFrom * 100 / contentSize), 1);
                                    this.pbDownloadNotificationInvoke(pbDownloadSpeed, downloadSpeed);
                                }));

                                int endSecond = DateTime.Now.Second;
                                if (beginSecond != endSecond)
                                {
                                    beginSecond = endSecond;
                                    lbSpreedMsg.Invoke((Action)(() =>
                                    {
                                        string speedText = "下载速度: " + (rangeFrom / 1024) + " KB/S";
                                        this.pbDownloadNotificationInvoke(lbSpreedMsg, speedText);
                                    }));
                                }

                                if (contentSize == rangeFrom)//下载完成
                                {
                                    this.pbDownloadNotificationInvoke(pbDownloadSpeed, 100);
                                    if (stopwatch != null)
                                    {
                                        stopwatch.Stop();
                                        string compMsg = "下载完成,耗时: " + stopwatch.Elapsed.Seconds + "秒,文件大小: " + rangeFrom / 1024 + " KB";
                                        this.pbDownloadNotificationInvoke(lbSpreedMsg, compMsg);
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
                lbSpreedMsg.Text = string.Empty;
            }
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
            }));
        }

        //检查服务器是否支持断点续传
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
        private bool isServerFileChanged(HttpResponseMessage responseMessage)
        {
            if (preLastModified == null && string.IsNullOrEmpty(preETag))//第一次下载，文件视为未改变
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
    }
}
