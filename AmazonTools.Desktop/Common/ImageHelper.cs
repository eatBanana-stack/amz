using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace AmazonTools.Desktop.Common
{
    public class ImageHelper
    {
        public static void CenterOnWhiteBackground(string sourcePath, string outputPath, int canvasWidth, int canvasHeight)
        {
            using (var source = Image.Load<Rgba32>(sourcePath))
            using (var canvas = new Image<Rgba32>(canvasWidth, canvasHeight, Color.Black))
            {
                int x = (canvasWidth - source.Width) / 2;
                int y = (canvasHeight - source.Height) / 2;

                canvas.Mutate(ctx => ctx.DrawImage(source, new Point(x, y), 1f));
                canvas.Save(outputPath);
            }
        }
    }
}
