using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AddressPurificationExample;
using AmazonTools.Desktop.Common;
using AmazonTools.Model._Admin;
using DotNetCommon.PinYin;
using HandyControl.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace AmazonTools.Desktop
{
    /// <summary>
    /// AddAmazonUserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class AddAmazonUserInfo
    {
        private AppDbContext db = new AppDbContext();

        public AddAmazonUserInfo()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            var dicmode = db.DicDefs.First(x=>x.DicName=="代理");
            db.DicFields.Where(x => x.DicDefId == dicmode.ID).ToList().ForEach(x =>
            {
                Cb_BelongingNameId.Items.Add(x.DicFieldDes);
            });
            Cb_BelongingNameId.SelectedItem = "志明";
            var dicmodeadd = db.DicDefs.First(x=>x.DicName=="站点");
            db.DicFields.Where(x => x.DicDefId == dicmodeadd.ID).ToList().ForEach(x =>
            {
                cb_zhandian.Items.Add(x.DicFieldDes);
            });
            cb_zhandian.SelectedItem = "欧洲";

            cb_youxian.Items.Add("自动");
            cb_youxian.Items.Add("手动");
            cb_youxian.SelectedItem = "自动";

            cb_xinka.Items.Add("自动");
            cb_xinka.Items.Add("手动");
            cb_xinka.SelectedItem = "自动";

        }

        private void Button_Click_sfz(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "图片文件|*.jpg;*.jpeg;*.png;",
                Title = "选择要上传的图片"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;


                lb_IDCardPhotoZId.Content = "正在上传中";
                lb_IDCardPhotoZId.Background = System.Windows.Media.Brushes.Red;

                Task.Run(() =>
                {
                    TencentCloud.Ocr.V20181119.Models.IDCardOCRResponse mode =   TencentCloudOcrTools.ProcessImage(filePath, "FRONT");
                    var fileStr =   HttpClientHelper.FileResponse("_file/upload",filePath);

                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        tb_FaUserNameCn.Text = mode.Name;
                        tb_FaUserNameUs.Text = WordsHelper.GetPinyinForName(mode.Name);
                        tb_FaIdCard.Text = mode.IdNum;
                        tb_FaBornTime.Text = mode.Birth;
                        lb_IDCardPhotoZId.Content = fileStr.Id;
                        tb_MailingAddress.Text = mode.Address;
                        lb_IDCardPhotoZId.Background = System.Windows.Media.Brushes.Green;
                        tb_MailingZipCode.Text = SelectZipCode(mode.Address);
                    }));
                });




            }
        }

        private void Button_Click_sfb(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "图片文件|*.jpg;*.jpeg;*.png;",
                Title = "选择要上传的图片"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                lb_IDCardPhotoFId.Content = "正在上传中";
                lb_IDCardPhotoFId.Background = System.Windows.Media.Brushes.Red;
                Task.Run(() =>
                {
                    TencentCloud.Ocr.V20181119.Models.IDCardOCRResponse mode =   TencentCloudOcrTools.ProcessImage(filePath, "BACK");
                    var fileStr =   HttpClientHelper.FileResponse("_file/upload",filePath);
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        tb_FaEndTime.Text = mode.ValidDate;
                        lb_IDCardPhotoFId.Content = fileStr.Id;
                        lb_IDCardPhotoFId.Background = System.Windows.Media.Brushes.Green;
                    }));
                });

            }
        }

        private void Button_Click_yyzz(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "图片文件|*.jpg;*.jpeg;*.png;",
                Title = "选择要上传的图片"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                lb_LicensePhotoId.Content = "正在上传中";
                lb_LicensePhotoId.Background = System.Windows.Media.Brushes.Red;
                Task.Run(() =>
                {
                    TencentCloud.Ocr.V20181119.Models.BizLicenseOCRResponse mode =   TencentCloudOcrTools.ProcessImageBiz(filePath);
                    var licID   = HttpClientHelper.FileResponse("_file/upload", filePath).Id;
                    //var translator = new AggregateTranslator();
                    //var licenseUs=  translator.TranslateAsync(mode.Name, "en").Result.Translation;
                    this.Dispatcher?.Invoke(new Action(() =>
                    {
                        lb_LicensePhotoId.Content = licID;
                        lb_LicensePhotoId.Background = System.Windows.Media.Brushes.Green;
                        tb_LicenseCn.Text = mode.Name;
                        tb_LicenseUs.Text = WordsHelper.GetPinyinForName(mode.Name);
                        tb_LicenseCode.Text = mode.RegNum;
                        tb_License.Text = mode.RegistrationDate;
                        tb_LicenseAddress.Text = mode.Address;
                        tb_LicenseZipCode.Text = SelectZipCode(mode.Address);
                    }));


                });

            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

            if (tb_FaUserNameCn.Text == ""
                || tb_FaUserNameUs.Text == ""
                || tb_FaIdCard.Text == ""
                || tb_FaBornTime.Text == ""
                || tb_FaEndTime.Text == ""
                || tb_LicenseCn.Text == ""
                || tb_LicenseUs.Text == ""
                || tb_LicenseCode.Text == ""
                || tb_License.Text == ""
                || tb_MailingAddress.Text == ""
                || tb_MailingZipCode.Text == ""
                || tb_LicenseZipCode.Text == ""
                || tb_LicenseAddress.Text == ""
                )
            {
                Growl.InfoGlobal("资料不全，请补充完整材料后提交！！");
                return;
            }
            if (Cb_BelongingNameId.Text == "")
            {
                Growl.InfoGlobal("请补全正确的代理人！！！");
                return;
            }
            var dicmode = db.DicDefs.First(x=>x.DicName=="代理");
            var belongingNameid = db.DicFields.Where(x => x.DicDefId == dicmode.ID).FirstOrDefault(x=>x.DicFieldDes== Cb_BelongingNameId.Text);

            var sitDicemode = db.DicDefs.First(x=>x.DicName=="站点");
            var siteid = db.DicFields.Where(x => x.DicDefId == sitDicemode.ID).FirstOrDefault(x=>x.DicFieldDes== cb_zhandian.Text);

            AmazonUserInfo amazonUserInfo = new AmazonUserInfo
            {
                BelongingNameId = belongingNameid.ID,
                FaUserNameCn = tb_FaUserNameCn.Text,
                FaUserNameUs = tb_FaUserNameUs.Text,
                FaIdCard = tb_FaIdCard.Text,
                FaBornTime = tb_FaBornTime.Text,
                FaEndTime = tb_FaEndTime.Text,
                LicenseCn = tb_LicenseCn.Text,
                LicenseUs = tb_LicenseUs.Text,
                LicenseCode = tb_LicenseCode.Text,
                License = tb_License.Text,
                IDCardPhotoZId = Guid.Parse(lb_IDCardPhotoZId.Content.ToString()) ,
                IDCardPhotoFId = Guid.Parse(lb_IDCardPhotoFId.Content.ToString()),
                LicensePhotoId = Guid.Parse(lb_LicensePhotoId.Content.ToString()),
                MailingAddress = tb_MailingAddress.Text,
                MailingZipCode = tb_MailingZipCode.Text,
                LicenseZipCode = tb_LicenseZipCode.Text,
                LicenseAddress = tb_LicenseAddress.Text,
                CreateBy=HttpClientHelper.account,
                CreateTime=DateTime.Now,

            };
            amazonUserInfo.ID = Guid.NewGuid();
            var siteList = new List<AmazonSiteInfo>();
            var siteMode = new AmazonSiteInfo();
            siteMode.SiteName = siteid;
            siteMode.SiteNameId = siteid.ID;
            MailManage mailMode = null;
            if (cb_youxian.Text == "自动")
            {
                mailMode = db.MailManages.FirstOrDefault();
                if (mailMode == null)
                {
                    Growl.ErrorGlobal("没有邮箱库存了！请联系管理添加！");
                    return;
                }
                siteMode.Mail = mailMode.Mail;
                siteMode.MailPassWord = mailMode.PassWord;
            }
            CreditCardManage CreditCardMode =  null;

            if (cb_xinka.Text == "自动")
            {
                CreditCardMode = db.CreditCardManages.FirstOrDefault();
                if (CreditCardMode == null)
                {
                    Growl.ErrorGlobal("没有信用卡库存了！请联系管理添加！");
                    return;
                }
                siteMode.CreditCard = CreditCardMode.CreditCard;
                siteMode.SecurityCode = CreditCardMode.SecurityCode;
                siteMode.ValidityPeriod = CreditCardMode.ValidityPeriod;
            }




            var AmazonStateDicemode = db.DicDefs.First(x=>x.DicName=="站点状态");
            var AmazonStateid = db.DicFields.Where(x => x.DicDefId == AmazonStateDicemode.ID).FirstOrDefault(x=>x.DicFieldDes== "待人脸");
            siteMode.AmazonState = AmazonStateid;
            siteMode.AmazonStateId = AmazonStateid.ID;
            siteMode.AmazonUser = amazonUserInfo;
            siteMode.AmazonUserId = amazonUserInfo.ID;
            siteMode.Phone = tb_shouji.Text;
            siteMode.CreateBy = HttpClientHelper.account;
            siteMode.CreateTime = DateTime.Now;

            var rdName = new Random();
            siteMode.AccountPassWord = "Kuajin" + rdName.Next(10000, 99999).ToString() + "!";

            siteMode.ID = Guid.NewGuid();
            siteList.Add(siteMode);

            amazonUserInfo.AmazonSiteInfo_AmazonUser = siteList;
            db.AmazonUserInfos.Add(amazonUserInfo);
            if (mailMode != null)
            {
                db.MailManages.Remove(mailMode);
            }
            if (CreditCardMode != null)
            {
                db.CreditCardManages.Remove(CreditCardMode);
            }

            if (db.SaveChanges() > 0)
            {
                Growl.SuccessGlobal($"客户:{tb_FaUserNameCn.Text}材料整理完毕！！！");
                this.Close();
            }
            else
            {
                Growl.ErrorGlobal($"客户:{tb_FaUserNameCn.Text}保存失败！！！");
                return;
            }
        }

        private void Button_Click_zipCode(object sender, RoutedEventArgs e)
        {

            string zipcode =  SelectZipCode(tb_MailingAddress.Text);
            if (string.IsNullOrEmpty(zipcode))
            {
                Growl.ErrorGlobal("邮编查询失败");
                return;
            }
            tb_MailingZipCode.Text = zipcode;
        }
        private string SelectZipCode(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return "";
            }
            var zipcode = AddressPurificationHelper.QueryPostCode(address);
            if (string.IsNullOrEmpty(zipcode))
            {
                return "";
            }
            return JsonConvert.DeserializeObject<aliZipCode>(zipcode).zipcode;
        }

        private void Button_Click_loadZipCode(object sender, RoutedEventArgs e)
        {
            string zipcode =  SelectZipCode(tb_LicenseAddress.Text);
            if (string.IsNullOrEmpty(zipcode))
            {
                Growl.ErrorGlobal("邮编查询失败");
                return;
            }
            tb_LicenseZipCode.Text = zipcode;
        }
    }
}
