using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using NLog;
using PrintSample.Files;
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.Storage.Streams;

namespace PrintSample.Pdf
{
    public class PdfLoader: IPdfLoader
    {
        private readonly Logger logger;
        public PdfLoader()
        {
            this.logger = LogManager.GetCurrentClassLogger();
        }
        public async Task<List<Image>> LoadAsync(LoadPdfFileArgs args)
        {
            if(File.Exists(args.FilePath) == false)
            {
                return new List<Image>();
            }
            StorageFile file = await StorageFile.GetFileFromPathAsync(args.FilePath);
            using(IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read))
            {
                var results = new List<Image>();
                PdfDocument document = await PdfDocument.LoadFromStreamAsync(stream);
                for(uint i = 0; i < document.PageCount; i++)
                {
                    using(PdfPage page = document.GetPage(i))
                    using(IRandomAccessStream outputStream = new InMemoryRandomAccessStream())
                    {
                        await page.RenderToStreamAsync(outputStream);
                        // Get bitmap from stream
                        BitmapFrame? bitmap = BitmapDecoder.Create(outputStream.AsStream(),
                                BitmapCreateOptions.None,    
                                BitmapCacheOption.OnLoad).Frames[0];
                        
                        results.Add(new Image
                        {
                            Source = bitmap,
                        });
                    }
                }
                return results;
            }            
        }
    }
}