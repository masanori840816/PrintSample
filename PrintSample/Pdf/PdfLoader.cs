using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using PrintSample.Files;
using Windows.Data.Pdf;
using Windows.Storage.Streams;

namespace PrintSample.Pdf
{
    public class PdfLoader: IPdfLoader
    {
        public async Task<Image> LoadAsync(LoadPdfFileArgs args)
        {
            using(FileStream fileStream = new FileStream(args.FilePath, FileMode.Open))
            using(IRandomAccessStream stream = fileStream.AsRandomAccessStream())
            {
                PdfDocument document = await PdfDocument.LoadFromStreamAsync(stream);
                using(PdfPage page = document.GetPage(0))
                using(MemoryStream memoryStream = new MemoryStream())
                using(IRandomAccessStream outputStream = memoryStream.AsRandomAccessStream())
                {
                    await page.RenderToStreamAsync(outputStream);
                    // Get bitmap from stream
                    BitmapFrame? bitmap = BitmapDecoder.Create(memoryStream, BitmapCreateOptions.None,    
                            BitmapCacheOption.OnLoad).Frames[0];
                    
                    return new Image
                    {
                        Source = bitmap,
                    };
                }
            }            
        }
    }
}