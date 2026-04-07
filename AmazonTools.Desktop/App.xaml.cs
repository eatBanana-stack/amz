using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using AmazonTools.Desktop.Common;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Themes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AmazonTools.Desktop
{
    public partial class App : Application
{
        protected override void OnStartup(StartupEventArgs e)
        {
            // 检查是否需要管理员权限
            if (RequiresAdminPrivileges())
            {
                LaunchAdminProcess();
                return;
            }
            
            base.OnStartup(e);
        }
        private static bool RequiresAdminPrivileges()
        {
            // 根据业务逻辑判断是否需要管理员权限
            return Environment.GetCommandLineArgs().Contains("--admin-task");
        }
        private static void LaunchAdminProcess()
        {
            try
            {
                var exePath = Path.ChangeExtension(Process.GetCurrentProcess().MainModule.FileName, ".exe");
                var startInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = "--elevated",
                    UseShellExecute = true,
                    Verb = "runas" // 请求UAC提升
                };

                Process.Start(startInfo);
            }
            catch 
            {
          
                Growl.Error("管理员权限请求失败");
            }
            finally
            {
                Environment.Exit(0);
            }
        }
        internal void UpdateTheme(ApplicationTheme theme)
        {
            if (ThemeManager.Current.ApplicationTheme != theme)
            {
                ThemeManager.Current.ApplicationTheme = theme;
            }
            
        }

  

        internal void UpdateAccent(Brush accent)
        {
            if (ThemeManager.Current.AccentColor != accent)
            {
                ThemeManager.Current.AccentColor = accent;
            }
        }
    }
}
