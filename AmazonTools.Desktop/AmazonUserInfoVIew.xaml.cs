using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AmazonTools.Desktop.Common;
using AmazonTools.Model._Admin;
using HandyControl.Controls;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NPOI.SS.Formula.Functions;

namespace AmazonTools.Desktop
{
    /// <summary>
    /// AmazonUserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class AmazonUserInfoVIew : UserControl
    {
        private AppDbContext db = new AppDbContext();
        public AmazonUserInfoVIew()
        {
            InitializeComponent();

            var mode = db.AmazonUserInfos.OrderByDescending(x=>x.CreateTime).Take(10).ToList();
            dg_filter.ItemsSource = mode;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            AddAmazonUserInfo addAmazonUserInfo = new AddAmazonUserInfo();
            addAmazonUserInfo.ShowDialog();
            var mode = db.AmazonUserInfos.OrderByDescending(x=>x.CreateTime).Take(10).ToList();
        }

        private void Button_Click_slect(object sender, RoutedEventArgs e)
        {
            dg_filter.ItemsSource = null;
            var selectMode = db.AmazonUserInfos.AsQueryable();
            if (!string.IsNullOrEmpty(tb_IdCard.Text.Trim()))
            {
                selectMode = selectMode.Where(x => x.FaIdCard.Contains(tb_IdCard.Text.Trim()));
            }
            if (!string.IsNullOrEmpty(tb_UserName.Text.Trim()))
            {
                selectMode = selectMode.Where(x => x.FaUserNameCn.Contains(tb_UserName.Text.Trim()));
            }
            dg_filter.ItemsSource = selectMode.ToList().Take(10);
        }
        /// <summary>
        /// 下载身份证正面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_dowSfz(object sender, RoutedEventArgs e)
        {
            var mode = dg_filter.SelectedItem as AmazonUserInfo;
            if (mode == null)
            {
                return;
            }
            try
            {

                string baseDir = @$"D:\{mode.FaUserNameCn}";
                // 使用示例
                if (!IsDDriveAvailable())
                {

                    Growl.InfoGlobal("D盘不可用,写入C盘！");
                    baseDir = @$"C:\{mode.FaUserNameCn}"; // 如果D盘不可用，使用C盘
                }
                // 2. 准备目录

                string safeDir = SanitizeDirectory(baseDir);
                CreateDirectorySafe(safeDir);
                // 使用示例
                if (!HasWritePermission(baseDir))
                {
                    throw new UnauthorizedAccessException("无目录写入权限");
                }
                Task.Run(() =>
               {
                   HttpClientHelper.DownloadFile($"_file/downloadfile/{mode.IDCardPhotoZId}", baseDir + $"//{GetRandomPassword(10)}.png");
                   this.Dispatcher.Invoke(() =>
                   {
                       Growl.SuccessGlobal($"{GetRandomPassword(10)} 的身份证正面下载成功！！");
                   });
               });

            }
            catch (Exception ex)
            {
                string exstr = ex.Message;
                Growl.ErrorGlobal("下载失败! 权限不足请开启管理员权限");
            }

        }

        public static string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
        public static bool HasWritePermission(string directoryPath)
        {
            try
            {
                // 尝试创建临时文件验证权限
                var tempFile = System.IO.Path.Combine(directoryPath, $"{Guid.NewGuid()}.tmp");
                using (File.Create(tempFile, 1, FileOptions.DeleteOnClose))
                { }
                return true;
            }
            catch
            {
                return false;
            }
        }
        bool IsDDriveAvailable()
        {
            return DriveInfo.GetDrives()
                .Any(drive => drive.Name.StartsWith("D:\\", StringComparison.OrdinalIgnoreCase));
        }
        string SanitizeDirectory(string path)
        {
            // 替换非法字符
            char[] invalidChars = System.IO.Path.GetInvalidPathChars();
            return new string(path.Select(c => invalidChars.Contains(c) ? '_' : c).ToArray());
        }
        // 创建目录
        void CreateDirectorySafe(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException($"无权限创建目录: {path}");
            }
        }

        private void Button_Click_dowSfzf(object sender, RoutedEventArgs e)
        {
            var mode = dg_filter.SelectedItem as AmazonUserInfo;
            if (mode == null)
            {
                return;
            }
            try
            {

                string baseDir = @$"D:\{mode.FaUserNameCn}";
                // 使用示例
                if (!IsDDriveAvailable())
                {

                    Growl.InfoGlobal("D盘不可用,写入C盘！");
                    baseDir = @$"C:\{mode.FaUserNameCn}"; // 如果D盘不可用，使用C盘
                }
                // 2. 准备目录
         
                string safeDir = SanitizeDirectory(baseDir);
                CreateDirectorySafe(safeDir);
                // 使用示例
                if (!HasWritePermission(baseDir))
                {
                    throw new UnauthorizedAccessException("无目录写入权限");
                }
                Task.Run(() =>
                {
                    HttpClientHelper.DownloadFile($"_file/downloadfile/{mode.IDCardPhotoFId}", baseDir + $"//{GetRandomPassword(10)}.png");
                    this.Dispatcher.Invoke(() =>
                    {
                        Growl.SuccessGlobal($"{GetRandomPassword(10)} 的身份证背面下载成功！！");
                    });
                });



            }
            catch (Exception ex)
            {
                string exstr = ex.Message;
                Growl.ErrorGlobal("下载失败! 权限不足请开启管理员权限");
            }

        }

        private void Button_Click_YYZZ(object sender, RoutedEventArgs e)
        {
            var mode = dg_filter.SelectedItem as AmazonUserInfo;
            if (mode == null)
            {
                return;
            }
            try
            {

                string baseDir = @$"D:\{mode.FaUserNameCn}";
                // 使用示例
                if (!IsDDriveAvailable())
                {

                    Growl.InfoGlobal("D盘不可用,写入C盘！");
                    baseDir = @$"C:\{mode.FaUserNameCn}"; // 如果D盘不可用，使用C盘
                }
                // 2. 准备目录
             
                string safeDir = SanitizeDirectory(baseDir);
                CreateDirectorySafe(safeDir);
                // 使用示例
                if (!HasWritePermission(baseDir))
                {
                    throw new UnauthorizedAccessException("无目录写入权限");
                }
                Task.Run(() =>
                {
                    HttpClientHelper.DownloadFile($"_file/downloadfile/{mode.LicensePhotoId}", baseDir + $"//{GetRandomPassword(10)}.png");
                    this.Dispatcher.Invoke(() =>
                    {
                        Growl.SuccessGlobal($"{GetRandomPassword(10)} 的营业执照下载成功！！");
                    });
                });



            }
            catch (Exception ex)
            {
                string exstr = ex.Message;
                Growl.ErrorGlobal("下载失败! 权限不足请开启管理员权限");
            }
        }
    }
}
