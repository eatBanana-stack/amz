using System;
using System.IO;
using System.Linq;
using System.Windows;
using AmazonTools.Desktop.Common;
using AmazonTools.Model._Admin;
using HandyControl.Controls;
using Microsoft.EntityFrameworkCore;

namespace AmazonTools.Desktop
{
    /// <summary>
    /// EndPackaged.xaml 的交互逻辑
    /// </summary>
    public partial class EndPackaged
    {
        private AppDbContext db = new AppDbContext();
        private AmazonSiteInfo entity = new AmazonSiteInfo();
        public EndPackaged(AmazonSiteInfo siteInfo)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            entity = siteInfo;
            var zhuangTaiId = db.DicDefs.First(x => x.DicName == "站点状态");
            db.DicFields.Where(x => x.DicDefId == zhuangTaiId.ID).ToList().ForEach(x =>
            {

                cb_State.Items.Add(x.DicFieldDes);
            });

            cb_State.SelectedItem = siteInfo.AmazonState.DicFieldDes;
            lb_xk.Content = siteInfo.CreditCard;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            //// 2. 从剪切板获取图像
            //var clipboardImage = System.Windows.Forms.Clipboard.GetImage();

            // 3. 指定保存到桌面的文件名和路径
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\材料打包\\{entity.SiteName.DicFieldDes}{entity.AmazonUser.FaUserNameCn}\\";
            if (!System.IO.Directory.Exists(desktopPath))
            {
                System.IO.Directory.CreateDirectory(desktopPath);
            }
            string fileName = $"{entity.SiteName.DicFieldDes}站点{entity.AmazonUser.FaUserNameCn}{DateTime.Now:yyyyMMddHHmmss}.png"; // 自定义文件名，使用时间戳避免重复
            string fullPath = System.IO.Path.Combine(desktopPath, fileName);

            HttpClientHelper.DownloadFile($"_file/downloadfile/{entity.GooogleVerificationId}", fullPath);
            //身份证正面
            HttpClientHelper.DownloadFile($"_file/downloadfile/{entity.AmazonUser.IDCardPhotoZId}", System.IO.Path.Combine(desktopPath, $"{entity.AmazonUser.FaUserNameCn}身份证正面.png"));
            //身份证反面
            HttpClientHelper.DownloadFile($"_file/downloadfile/{entity.AmazonUser.IDCardPhotoFId}", System.IO.Path.Combine(desktopPath, $"{entity.AmazonUser.FaUserNameCn}身份证反面.png"));
            //营业执照
            HttpClientHelper.DownloadFile($"_file/downloadfile/{entity.AmazonUser.LicensePhotoId}", System.IO.Path.Combine(desktopPath, $"{entity.AmazonUser.FaUserNameCn}营业执照.png"));

            // 使用 using 语句确保资源被正确释放
            using (StreamWriter writer = new StreamWriter(desktopPath + "账号密码信息.txt"))
            {
                // 写入标题行并居中（通过添加前导空格模拟）
                writer.WriteLine($"                          质保开始时间:{DateTime.Now.ToString("yyyy年MM月dd日")}");
                writer.WriteLine("=========================================="); // 分隔线
                writer.WriteLine(); // 写入一个空行

                // 写入带项目符号的列表
                writer.WriteLine($"* 账号和邮箱:     {entity.Mail}");
                writer.WriteLine($"* 密码:              {entity.AccountPassWord}");
                writer.WriteLine($"* 邮箱密码:        {entity.MailPassWord}");
                writer.WriteLine($"* 亚马逊信用卡或希音账号:           {entity.CreditCard}");
                writer.WriteLine($"* 亚马逊安全码或希音品类:           {entity.SecurityCode}");
                writer.WriteLine($"* 有效期:           {entity.ValidityPeriod}");
                writer.WriteLine($"* 邮箱临时接码 - 谨慎使用:           https://b2u.me/5YTo82B/{entity.Mail}");


                writer.WriteLine("=========================================="); // 分隔线
                writer.WriteLine($"* 执照名称中文:  {entity.AmazonUser.LicenseCn}");
                writer.WriteLine($"* 执照名称拼音:  {entity.AmazonUser.LicenseUs}");
                writer.WriteLine($"* 执照信用代码:  {entity.AmazonUser.LicenseCode}");
                writer.WriteLine($"* 店铺运营地址:  {entity.AmazonUser.LicenseAddress}");
                writer.WriteLine($"* 店铺运营邮编:  {entity.AmazonUser.LicenseZipCode}");
                writer.WriteLine($"* 居住地址:        {entity.AmazonUser.MailingAddress}");
                writer.WriteLine($"* 居住邮编:        {entity.AmazonUser.MailingZipCode}");
            }

            // 最佳实践实现
            var stateName = cb_State.Text;

            // 获取状态ID（不跟踪查询）
            var stateId = db.DicFields.AsNoTracking()
    .Where(f => f.DicDef.DicName == "站点状态" && f.DicFieldDes == stateName)
    .Select(f => f.ID)
    .FirstOrDefault();

            if (stateId == default)
            {
                Growl.ErrorGlobal($"找不到对应的状态: {stateName}");
                return;
            }

            // 只更新外键ID
            entity.AmazonStateId = stateId;

            // 标记实体为已修改
            db.Entry(entity).Property(x => x.AmazonStateId).IsModified = true;

            if (db.SaveChanges() > 0)
            {

                Growl.SuccessGlobal($"客户:{entity.AmazonUser.FaUserNameCn}打包成功,修改状态为:{stateName}！！！");
                this.Close();
            }
            else
            {
                Growl.ErrorGlobal($"客户:{entity.AmazonUser.FaUserNameCn} 打包成功失败,状态修改失败！！！");
            }
        }

        private void lb_xk_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(lb_xk.Content.ToString().Trim());
            Growl.SuccessGlobal(lb_xk.Content.ToString());
        }
    }
}
