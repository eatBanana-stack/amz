using HandyControl.Themes;
using HandyControl.Tools;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HandyControl.Controls;
using WalkingTec.Mvvm.Core;
using AmazonTools.Model._Admin;
using System.Linq;
using AmazonTools.Desktop.Common;
using static Azure.Core.HttpHeader;
namespace AmazonTools.Desktop
{
    public partial class MainWindow
    {

        public MainWindow()
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Login login = new Login();
            login.ShowDialog();
            if (login.DialogResult == false)
            {
                this.Close();
            }
            Contr_page.Content = new Frame
            {
                Content = new SiteInfo()
            };
        }

        #region Change Theme
        private void ButtonConfig_OnClick(object sender, RoutedEventArgs e) => PopupConfig.IsOpen = true;

        private void ButtonSkins_OnClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                PopupConfig.IsOpen = false;
                if (button.Tag is ApplicationTheme tag)
                {
                    ((App)Application.Current).UpdateTheme(tag);
                }
                else if (button.Tag is Brush accentTag)
                {
                    ((App)Application.Current).UpdateAccent(accentTag);
                }
                else if (button.Tag is "Picker")
                {
                    var picker = SingleOpenHelper.CreateControl<ColorPicker>();
                    var window = new PopupWindow
                    {
                        PopupElement = picker,
                        WindowStartupLocation = WindowStartupLocation.CenterScreen,
                        AllowsTransparency = true,
                        WindowStyle = WindowStyle.None,
                        MinWidth = 0,
                        MinHeight = 0,
                        Title = "Select Accent Color"
                    };

                    picker.SelectedColorChanged += delegate
                    {
                        ((App)Application.Current).UpdateAccent(picker.SelectedBrush);
                        window.Close();
                    };
                    picker.Canceled += delegate
                    { window.Close(); };
                    window.Show();
                }
            }
        }
        #endregion

        private void MenuItem_Click_Kehu(object sender, RoutedEventArgs e)
        {
            Contr_page.Content = new Frame
            {
                Content = new AmazonUserInfoVIew()
            };
        }

        private void MenuItem_Click_site(object sender, RoutedEventArgs e)
        {
            Contr_page.Content = new Frame
            {
                Content = new SiteInfo()
            };
        }
    }
}
