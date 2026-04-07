using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using HandyControl.Controls;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Ocr.V20181119;
using TencentCloud.Ocr.V20181119.Models;

namespace AmazonTools.Desktop.Common
{
    class TencentCloudOcrTools
    {

        // 配置密钥及地域
       static  string secretId = "AKIDmT1b7Unw11yunW3MRJ1WnqjT0Qq33sVv";
        static string secretKey = "HKC2jFcombggU6cw64gBTXUMAoJnHcok";
        static string region = "ap-guangzhou";
        // 获取图片编码器
        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (var codec in codecs)
                if (codec.MimeType == mimeType)
                    return codec;
            return null;
        }
        public static IDCardOCRResponse ProcessImage(string filePath, string CardSide)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                // 如果文件大于 2MB，执行压缩
                if (fileInfo.Length > 2 * 1024 * 1024)
                {
                    string compressedPath = CompressImage(filePath);
                    var IDCard =  UploadImage(compressedPath, CardSide);
                    File.Delete(compressedPath); // 上传后删除临时文件

                    return IDCard;
                }
                else
                {
                    var IDCard =  UploadImage(filePath, CardSide);
                    return IDCard;
                }
            }
            catch (Exception ex)
            {
                Growl.ErrorGlobal($"操作失败: {ex.Message}");
                return null; // 确保在捕获异常时返回值
            }
        }

        // 上传图片到服务器
        private static IDCardOCRResponse UploadImage(string compressedPath, string CardSide)
        {
            try
            {
                // 初始化客户端
                Credential cred = new Credential { SecretId = secretId, SecretKey = secretKey };
                ClientProfile clientProfile = new ClientProfile();
                HttpProfile httpProfile = new HttpProfile { Endpoint = "ocr.tencentcloudapi.com" };
                clientProfile.HttpProfile = httpProfile;

                // 创建OCR客户端并调用身份证识别接口
                OcrClient client = new OcrClient(cred, region, clientProfile);
            
                IDCardOCRRequest req = new IDCardOCRRequest
                {
                    ImageBase64 = ImageToBase64(compressedPath), // 需将图片转换为Base64格式
                    CardSide = CardSide //"FRONT" // FRONT为正面，BACK为反面
                };

                try
                {
                    return  client.IDCardOCR(req).Result;
                }
                catch (Exception ex)
                {
                    Growl.ErrorGlobal($"识别失败: {ex.Message}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Growl.ErrorGlobal("上传失败");
                return null;
            }
        }



        public static BizLicenseOCRResponse ProcessImageBiz(string filePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                // 如果文件大于 2MB，执行压缩
                if (fileInfo.Length > 2 * 1024 * 1024)
                {
                    string compressedPath = CompressImage(filePath);
                    BizLicenseOCRResponse IDCard =  UploadImageBiz(compressedPath);
                    File.Delete(compressedPath); // 上传后删除临时文件

                    return IDCard;
                }
                else
                {
                    var IDCard =  UploadImageBiz(filePath);
                    return IDCard;
                }
            }
            catch (Exception ex)
            {
                Growl.ErrorGlobal($"操作失败: {ex.Message}");
                return null; // 确保在捕获异常时返回值
            }
        }
        // 上传执照到服务器
        private static BizLicenseOCRResponse UploadImageBiz(string compressedPath)
        {
            try
            {
                // 初始化客户端
                Credential cred = new Credential { SecretId = secretId, SecretKey = secretKey };
                ClientProfile clientProfile = new ClientProfile();
                HttpProfile httpProfile = new HttpProfile { Endpoint = "ocr.tencentcloudapi.com" };
                clientProfile.HttpProfile = httpProfile;

                // 创建OCR客户端并调用身份证识别接口
                OcrClient client = new OcrClient(cred, region, clientProfile);

                // 构建营业执照识别请求
                var req = new BizLicenseOCRRequest
                {
                    ImageBase64 = ImageToBase64(compressedPath) // 或使用ImageUrl参数
                };

                try
                {
                    return client.BizLicenseOCR(req).Result;
                }
                catch (Exception ex)
                {
                    Growl.ErrorGlobal($"识别失败: {ex.Message}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Growl.ErrorGlobal("上传失败");
                return null;
            }
        }

        public static string ImageToBase64(string imagePath)
        {
            try
            {
                // 读取图片字节数组
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                // 转换为Base64字符串
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"转换失败: {ex.Message}");
                return null;
            }
        }
        // 压缩图片方法

        private static string CompressImage(string originalPath, long targetSizeKB = 200)
        {
            using (var image = System.Drawing.Image.FromFile(originalPath))
            {
                // 计算压缩质量（经验值调整）
                int quality = 70;
                if (new FileInfo(originalPath).Length > 5 * 1024 * 1024)
                    quality = 50;

                // 生成临时文件路径
                string tempPath = System.IO.Path.Combine(
                System.IO.Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".jpg"
            );

                // 保存压缩后的图片
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

                var jpegCodec = GetEncoderInfo("image/jpeg");
                image.Save(tempPath, jpegCodec, encoderParams);

                return tempPath;
            }
        }
    }
}
