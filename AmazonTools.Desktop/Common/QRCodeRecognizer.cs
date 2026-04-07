using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

namespace AmazonTools.Desktop.Common
{
    public class QRCodeRecognizer
    {
        public string RecognizeQRCodeFromImage(string imagePath)
        {
            try
            {
                // 加载图像
                Bitmap bitmap = new Bitmap(imagePath);

                // 创建二维码读取器
                BarcodeReader reader = new BarcodeReader();
                reader.Options = new DecodingOptions
                {
                    PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE },
                    TryHarder = true
                };

                // 识别二维码
                Result result = reader.Decode(bitmap);
                bitmap.Dispose();

                return result?.Text;
            }
            catch 
            {
               Growl.ErrorGlobal("二维码识别失败");
                return "";
            }
        }
    }
}
