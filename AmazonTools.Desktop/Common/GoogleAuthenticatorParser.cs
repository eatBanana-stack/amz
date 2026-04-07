using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTools.Desktop.Common
{
    public class GoogleAuthenticatorParser
    {

        public (string Secret, string Account, string Issuer) ParseAuthenticatorURI(string qrCodeData)
        {
            if (string.IsNullOrEmpty(qrCodeData) || !qrCodeData.StartsWith("otpauth://totp/"))
            {
                Growl.ErrorGlobal("无效的谷歌验证器二维码数据");

                return ("", "", "");
            }

            try
            {
                Uri uri = new Uri(qrCodeData);
                var parameters = System.Web.HttpUtility.ParseQueryString(uri.Query);

                string secret = parameters["secret"];
                string issuer = parameters["issuer"];
                string account = uri.AbsolutePath.TrimStart('/');

                if (string.IsNullOrEmpty(secret))
                {
                    Growl.ErrorGlobal("二维码中未找到有效的密钥");
                    return ("", "", "");
                }


                return (secret, account, issuer);
            }
            catch (Exception ex)
            {
                Growl.ErrorGlobal($"解析谷歌验证器数据失败: {ex.Message}");
                return ("", "", "");
            }
        }


    }
}
