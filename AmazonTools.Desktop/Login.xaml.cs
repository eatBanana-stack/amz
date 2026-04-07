using AmazonTools.Desktop.Common;
using AmazonTools.Desktop.Dtos;
using HandyControl.Controls;
using HandyControl.Themes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AmazonTools.Desktop
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login
    {
        private UserAccount _userAccount = new UserAccount();
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _userAccount = JsonFileExtensions<UserAccount>.Readr("UserAccount.json");
            tbUserName.Text = _userAccount.UserName;
            tbPassword.Password = _userAccount.PassWord;
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            if (tbUserName.Text == "" || tbPassword.Password == "")
            {
                Growl.Error("请输入账号密码");
            }
            var model = HttpClientHelper.PostResponse<TokenDto>("_Account/LoginJwt", JsonConvert.SerializeObject(new
            {
                Account = tbUserName.Text.Trim(),
                Password = tbPassword.Password.Trim(),
            }));

            if (model == null)
            {
                Growl.Error("账号或密码错误");
                return;
            }
            JsonFileExtensions<UserAccount>.Write(new UserAccount()
            {
                UserName = tbUserName.Text.Trim(),
                PassWord = tbPassword.Password.Trim(),
                Tenant = _userAccount.Tenant
            }, "UserAccount.json");
            HttpClientHelper.Auth = model.access_token;
            HttpClientHelper.account = tbUserName.Text.Trim();
          
            this.DialogResult = true;
        }

    }
}
