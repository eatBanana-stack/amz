using System;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Input;
using AmazonTools.Desktop.Common;
using AmazonTools.Model._Admin;
using HandyControl.Controls;
using Clipboard = System.Windows.Clipboard;

namespace AmazonTools.Desktop
{
    /// <summary>
    /// ValidatorWindows.xaml 的交互逻辑
    /// </summary>
    public partial class ValidatorWindows
    {
        private AmazonSiteInfo siteMode = new AmazonSiteInfo();
        private AppDbContext db = new AppDbContext();

        private GoogleAuthenticatorService _authService;
        private QRCodeRecognizer _qrRecognizer;
        private GoogleAuthenticatorParser _parser;
        public ValidatorWindows(AmazonSiteInfo siteEntiy)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            siteMode = siteEntiy;
            tb_FaUserNameCn.Text = siteMode.AmazonUser.FaUserNameCn;
            tb_FaUserNameUs.Text = siteMode.AmazonUser.FaUserNameUs;
            tb_FaIdCard.Text = siteMode.AmazonUser.FaIdCard;
            tb_FaBornTime.Text = siteMode.AmazonUser.FaBornTime;
            tb_FaEndTime.Text = siteMode.AmazonUser.FaEndTime;
            tb_LicenseCn.Text = siteMode.AmazonUser.LicenseCn;
            tb_LicenseUs.Text = siteMode.AmazonUser.LicenseUs;
            tb_LicenseCode.Text = siteMode.AmazonUser.LicenseCode;
            tb_License.Text = siteMode.AmazonUser.License;
            tb_shouji.Text = siteMode.Phone;
            tb_LicenseZipCode.Text = siteMode.AmazonUser.LicenseZipCode;
            tb_LicenseAddress.Text = siteMode.AmazonUser.LicenseAddress;

            tb_MailingZipCode.Text = siteMode.AmazonUser.MailingZipCode;
            tb_MailingAddress.Text = siteMode.AmazonUser.MailingAddress;

            tb_Mail.Text = siteMode.Mail;
            tb_AccountPassWord.Text = siteMode.AccountPassWord;
            tb_CreditCard.Text = siteMode.CreditCard;
            tb_SecurityCode.Text = siteMode.SecurityCode;
            tb_MailPassWord.Text = siteMode.MailPassWord;
            tb_ValidityPeriod.Text = siteMode.ValidityPeriod;
            this.Title = $"  {siteMode.SiteName.DicFieldDes}站点  --  {siteMode.CreateBy}  --  {siteMode.CreateTime}";


            _authService = new GoogleAuthenticatorService();
            _qrRecognizer = new QRCodeRecognizer();
            _parser = new GoogleAuthenticatorParser();



            _authService.OnCodeUpdated += (code, seconds) =>
            {
                Dispatcher.Invoke(() =>
                {
                    TbVerificationCode.Content = code;
                    PbCountdown.Value = seconds;
                    TbCountdown.Content = $"{seconds}秒";
                });
            };
            if (!string.IsNullOrEmpty(Convert.ToString(siteMode.GooogleVerificationId)))
            {
                // 2. 从剪切板获取图像
                var clipboardImage = System.Windows.Forms.Clipboard.GetImage();

                // 3. 指定保存到桌面的文件名和路径
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\二部验证器\\{siteMode.SiteName.DicFieldDes}{siteMode.AmazonUser.FaUserNameCn}\\";
                if (!System.IO.Directory.Exists(desktopPath))
                {
                    System.IO.Directory.CreateDirectory(desktopPath);
                }
                string fileName = $"{siteMode.SiteName.DicFieldDes}站点{siteMode.AmazonUser.FaUserNameCn}{DateTime.Now:yyyyMMddHHmmss}.png"; // 自定义文件名，使用时间戳避免重复
                string fullPath = System.IO.Path.Combine(desktopPath, fileName);
                string url = $"_file/downloadfile/{siteMode.GooogleVerificationId}";
                HttpClientHelper.DownloadFile(url, fullPath);
                GoogleNice(fullPath);
            }
        }

        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            if (!System.Windows.Forms.Clipboard.ContainsImage())
            {
                Growl.WarningGlobal("剪贴板中没有图片");
                return;
            }


            try
            {
                // 2. 从剪切板获取图像
                var clipboardImage = System.Windows.Forms.Clipboard.GetImage();

                // 3. 指定保存到桌面的文件名和路径
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\二部验证器\\{siteMode.SiteName.DicFieldDes}{siteMode.AmazonUser.FaUserNameCn}\\";
                if (!System.IO.Directory.Exists(desktopPath))
                {
                    System.IO.Directory.CreateDirectory(desktopPath);
                }
                string fileName = $"{siteMode.SiteName.DicFieldDes}站点{siteMode.AmazonUser.FaUserNameCn}{DateTime.Now:yyyyMMddHHmmss}.png"; // 自定义文件名，使用时间戳避免重复
                string fullPath = System.IO.Path.Combine(desktopPath, fileName);

                // 4. 保存图像
                // 使用PNG格式保存，因为它支持无损压缩和透明度。如果文件已存在，Save方法会直接覆盖。
                clipboardImage.Save(fullPath, ImageFormat.Png);
                //启动二部
                GoogleNice(fullPath);

                var fileStr = HttpClientHelper.FileResponse("_file/upload", fullPath);
                siteMode.GooogleVerificationId = Guid.Parse(fileStr.Id);
                db.AmazonSiteInfos.Update(siteMode);
                if (db.SaveChanges() > 0)
                {
                    Growl.SuccessGlobal("二部上传成功");
                }
                else
                {
                    Growl.ErrorGlobal("二部上传失败,请及时备份! 丢失就要扣工资了哦!!!");

                }
            }
            catch
            {
                Growl.ErrorGlobal("二部上传失败,请及时备份! 丢失就要扣工资了哦!!!");
            }

        }

        private void GoogleNice(string fullPath)
        {

            try
            {
                // 识别二维码
                string qrData = _qrRecognizer.RecognizeQRCodeFromImage(fullPath);

                // 解析谷歌验证器数据
                var (secret, account, issuer) = _parser.ParseAuthenticatorURI(qrData);

                string decodedAccount = HttpUtility.UrlDecode(account);
                // 显示账户信息
                TbAccountInfo.Text = $"账户: {decodedAccount}";

                // 启动自动刷新
                _authService.Start(secret);
            }
            catch
            {
                Growl.ErrorGlobal("二维码识别失败,截图截好点,小老弟!!!");
            }

        }

        #region 双击复制
        //private void Button_Click_jietu(object sender, RoutedEventArgs e)
        //{
        //    if (!System.Windows.Forms.Clipboard.ContainsImage())
        //    {
        //        Growl.WarningGlobal("剪贴板中没有图片");
        //        return;
        //    }
        //    try
        //    {
        //        // 2. 从剪切板获取图像
        //        var clipboardImage = System.Windows.Forms.Clipboard.GetImage();

        //        // 3. 指定保存到桌面的文件名和路径
        //        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //        string fileName = $"MyClipboardImage_{DateTime.Now:yyyyMMddHHmmss}.png"; // 自定义文件名，使用时间戳避免重复
        //        string fullPath = System.IO.Path.Combine(desktopPath, fileName);

        //        // 4. 保存图像
        //        // 使用PNG格式保存，因为它支持无损压缩和透明度。如果文件已存在，Save方法会直接覆盖。
        //        clipboardImage.Save(fullPath, ImageFormat.Png);

        //        System.Windows.MessageBox.Show($"图像已保存到：\n{fullPath}", "保存成功");
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.MessageBox.Show($"操作失败：{ex.Message}", "错误");
        //    }
        //}

        private void tb_FaUserNameCn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Clipboard.SetDataObject(tb_FaUserNameCn.Text);
            Growl.InfoGlobal(tb_FaUserNameCn.Text);
        }

        private void tb_FaUserNameUs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_FaUserNameUs.Text);
            Growl.InfoGlobal(tb_FaUserNameUs.Text);
        }

        private void tb_FaIdCard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_FaIdCard.Text);
            Growl.InfoGlobal(tb_FaIdCard.Text);
        }

        private void tb_LicenseCn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_LicenseCn.Text);
            Growl.InfoGlobal(tb_LicenseCn.Text);
        }

        private void tb_LicenseUs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_LicenseUs.Text);
            Growl.InfoGlobal(tb_LicenseUs.Text);

        }

        private void tb_LicenseCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_LicenseCode.Text);
            Growl.InfoGlobal(tb_LicenseCode.Text);
        }

        private void tb_LicenseZipCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_LicenseZipCode.Text);
            Growl.InfoGlobal(tb_LicenseZipCode.Text);
        }

        private void tb_LicenseAddress_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_LicenseAddress.Text);
            Growl.InfoGlobal(tb_LicenseAddress.Text);
        }

        private void tb_MailingAddress_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_MailingAddress.Text);
            Growl.InfoGlobal(tb_MailingAddress.Text);
        }

        private void tb_MailingZipCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_MailingZipCode.Text);
            Growl.InfoGlobal(tb_MailingZipCode.Text);
        }

        private void tb_Mail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_Mail.Text);
            Growl.InfoGlobal(tb_Mail.Text);
        }

        private void tb_AccountPassWord_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_AccountPassWord.Text);
            Growl.InfoGlobal(tb_AccountPassWord.Text);
        }

        private void tb_CreditCard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_CreditCard.Text);
            Growl.InfoGlobal(tb_CreditCard.Text);
        }

        private void tb_SecurityCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_SecurityCode.Text);
            Growl.InfoGlobal(tb_SecurityCode.Text);
        }

        #endregion

        private void Button_Click_update(object sender, RoutedEventArgs e)
        {
            siteMode.Mail = tb_Mail.Text.Trim();
            siteMode.MailPassWord = tb_MailPassWord.Text.Trim();
            siteMode.AccountPassWord = tb_AccountPassWord.Text.Trim();
            siteMode.CreditCard = tb_CreditCard.Text.Trim();
            siteMode.SecurityCode = tb_SecurityCode.Text.Trim();
            siteMode.Phone = tb_shouji.Text.Trim();
            siteMode.ValidityPeriod = tb_ValidityPeriod.Text.Trim();

            siteMode.UpdateBy = HttpClientHelper.account;
            siteMode.UpdateTime = DateTime.Now;
            siteMode.AmazonUser.UpdateBy = HttpClientHelper.account;
            siteMode.AmazonUser.UpdateTime = DateTime.Now;
            db.AmazonSiteInfos.Update(siteMode);
            if (db.SaveChanges() > 0)
            {
                Growl.SuccessGlobal("保存成功");
                this.Close();
            }
            else
            {
                Growl.ErrorGlobal("保存失败");

            }
        }

        private void TbVerificationCode_Click_VerificationCode(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(TbVerificationCode.Content);
            Growl.SuccessGlobal(TbVerificationCode.Content.ToString());
        }

        private void TbShouEmail_Click(object sender, RoutedEventArgs e)
        {
            OpenInDefaultBrowser(@$"https://b2u.me/5YTo82B/{tb_Mail.Text}");
        }

        private void OpenInDefaultBrowser(string url)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void tb_shouji_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetDataObject(tb_shouji.Text.Trim());
            Growl.SuccessGlobal(tb_shouji.Text.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Task.Run(() =>
                {
                    // 3. 指定保存到桌面的文件名和路径
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\临时使用\\{siteMode.SiteName.DicFieldDes}{siteMode.AmazonUser.FaUserNameCn}\\";
                    if (!System.IO.Directory.Exists(desktopPath))
                    {
                        System.IO.Directory.CreateDirectory(desktopPath);
                    }
                    string fileName = $"{siteMode.SiteName.DicFieldDes}站点{siteMode.AmazonUser.FaUserNameCn}{DateTime.Now:yyyyMMddHHmmss}.png"; // 自定义文件名，使用时间戳避免重复
                    string fullPath = System.IO.Path.Combine(desktopPath, fileName);

                    HttpClientHelper.DownloadFile($"_file/downloadfile/{siteMode.GooogleVerificationId}", fullPath);
                    //身份证正面
                    HttpClientHelper.DownloadFile($"_file/downloadfile/{siteMode.AmazonUser.IDCardPhotoZId}", System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}身份证正面.png"));
                    //身份证反面
                    HttpClientHelper.DownloadFile($"_file/downloadfile/{siteMode.AmazonUser.IDCardPhotoFId}", System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}身份证反面.png"));
                    //营业执照
                    HttpClientHelper.DownloadFile($"_file/downloadfile/{siteMode.AmazonUser.LicensePhotoId}", System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}营业执照.png"));

                    AmazonImageResizer.ResizeForAmazon(System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}身份证正面.png"),
                        System.IO.Path.Combine(desktopPath, $"G{siteMode.AmazonUser.FaUserNameUs}sfzz.png"), enableScaleUp: false);
                    AmazonImageResizer.ResizeForAmazon(System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}身份证反面.png"),
                        System.IO.Path.Combine(desktopPath, $"G{siteMode.AmazonUser.FaUserNameUs}sfzb.png"), enableScaleUp: false);
                    AmazonImageResizer.ResizeForAmazon(System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}营业执照.png"),
                        System.IO.Path.Combine(desktopPath, $"G{siteMode.AmazonUser.FaUserNameUs}yyzz.png"), enableScaleUp: false);

                    ImageHelper.CenterOnWhiteBackground(System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}身份证正面.png"), System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}身份证正面扩展.png"), 5000, 5000);
                    ImageHelper.CenterOnWhiteBackground(System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}身份证反面.png"), System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}身份证反面扩展.png"), 5000, 5000);
                    ImageHelper.CenterOnWhiteBackground(System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}营业执照.png"), System.IO.Path.Combine(desktopPath, $"{siteMode.AmazonUser.FaUserNameCn}营业执照扩展.png"), 5000, 5000);


                    Dispatcher.Invoke(new Action(() =>
                    {
                        Growl.SuccessGlobal($"获取成功");
                    }));
                });



            }
            catch
            {

                Growl.ErrorGlobal($"获取失败");
            }

        }
    }
}
