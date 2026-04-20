using System;
using System.Numerics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using SixLabors.ImageSharp.Processing;

public static class AmazonImageResizer
{
    /// <summary>
    /// 亚马逊专用：图片【直接放大1倍/保持原图】（等比例不变形）+ 过审优化
    /// </summary>
    public static void ResizeForAmazon(string sourcePath, string savePath, bool enableScaleUp = true, bool isPng = false)
    {
        // 1. 加载图片
        using var image = Image.Load(sourcePath);
        int targetWidth = enableScaleUp ? image.Width * 2 : image.Width;
        int targetHeight = enableScaleUp ? image.Height * 2 : image.Height;

        // 2. 高质量缩放（Lanczos3）
        if (enableScaleUp)
        {
            image.Mutate(x => x.Resize(targetWidth, targetHeight, KnownResamplers.Lanczos3));
        }

        // 3. 模拟苹果 EXIF
        AddFakeAppleExif(image, targetWidth, targetHeight);

        // 4. 手动添加噪声
        AddNaturalNoise(image);

        // 5. 轻微锐化
        image.Mutate(x => x.GaussianSharpen(0.5f));

        // 6. 保存
        if (isPng)
        {
            image.SaveAsPng(savePath);
        }
        else
        {
            var jpegEncoder = new JpegEncoder
            {
                Quality = 90
            };
            image.Save(savePath, jpegEncoder);
        }
    }

    // 模拟 iPhone 14 Pro + iOS 16 EXIF
    private static void AddFakeAppleExif(Image image, int width, int height)
    {
        var exif = image.Metadata.ExifProfile ?? new ExifProfile();
        var now = DateTime.Now;

        // --- 基础设备信息 ---
        exif.SetValue(ExifTag.Make, "Apple");
        exif.SetValue(ExifTag.Model, "iPhone 14 Pro");
        exif.SetValue(ExifTag.Software, "16.7.5");
        exif.SetValue(ExifTag.DateTime, now.ToString("yyyy:MM:dd HH:mm:ss"));
        exif.SetValue(ExifTag.DateTimeOriginal, now.ToString("yyyy:MM:dd HH:mm:ss"));
        exif.SetValue(ExifTag.DateTimeDigitized, now.ToString("yyyy:MM:dd HH:mm:ss"));

        // --- 拍摄参数 ---
        exif.SetValue(ExifTag.FNumber, new Rational(178, 100));
        exif.SetValue(ExifTag.FocalLength, new Rational(9, 1));
        exif.SetValue(ExifTag.FocalLengthIn35mmFilm, (ushort)24);
        exif.SetValue(ExifTag.ISOSpeedRatings, new ushort[] { 100 });
        exif.SetValue(ExifTag.ExposureTime, new Rational(1, 125));
        exif.SetValue(ExifTag.ExposureProgram, (ushort)2);

        // 🔥 修复1：显式指定 ExposureBiasValue 参数类型
        exif.SetValue(ExifTag.ExposureBiasValue, new SignedRational(0, 1));

        exif.SetValue(ExifTag.MeteringMode, (ushort)5);
        exif.SetValue(ExifTag.WhiteBalance, (ushort)0);
        exif.SetValue(ExifTag.Flash, (ushort)16);
        exif.SetValue(ExifTag.SceneCaptureType, (ushort)0);
        exif.SetValue(ExifTag.LensMake, "Apple");
        exif.SetValue(ExifTag.LensModel, "iPhone 14 Pro back camera 9.0mm f/1.78");

        // --- 图片尺寸 ---
        // 🔥 修复2：移除 ImageWidth/ImageHeight，只使用 PixelXDimension/PixelYDimension
        exif.SetValue(ExifTag.PixelXDimension, (uint)width);
        exif.SetValue(ExifTag.PixelYDimension, (uint)height);

        exif.SetValue(ExifTag.ColorSpace, (ushort)1);
        exif.SetValue(ExifTag.ComponentsConfiguration, new byte[] { 1, 2, 3, 0 });
        exif.SetValue(ExifTag.YCbCrPositioning, (ushort)1);

        // --- 其他 ---
        exif.SetValue(ExifTag.Orientation, (ushort)1);
        exif.SetValue(ExifTag.ResolutionUnit, (ushort)2);
        exif.SetValue(ExifTag.XResolution, new Rational(72, 1));
        exif.SetValue(ExifTag.YResolution, new Rational(72, 1));

        image.Metadata.ExifProfile = exif;
    }

    // 手动添加噪声
    private static void AddNaturalNoise(Image image)
    {
        Random random = new Random();
        image.Mutate(x => x.ProcessPixelRowsAsVector4(row =>
        {
            for (int i = 0; i < row.Length; i++)
            {
                var pixel = row[i];
                float noise = (float)(random.NextDouble() * 0.04 - 0.02);
                pixel.X += noise;
                pixel.Y += noise;
                pixel.Z += noise;
                row[i] = Vector4.Clamp(pixel, Vector4.Zero, Vector4.One);
            }
        }));
    }
}