using System.Printing;
using System.Windows.Media;
using System.Windows.Xps;

namespace PrintSample.Prints
{
    public class Printer: IPrinter
    {
        public Printer()
        {

        }
        public void Print(Visual target)
        {
            LocalPrintServer printServer = new LocalPrintServer();
            PrintQueue queue = printServer.GetPrintQueue("Microsoft Print to PDF");
            // デフォルトのプリンターを使う場合
            // PrintQueue? defaultQueue = LocalPrintServer.GetDefaultPrintQueue();

            PrintTicket ticket = queue.DefaultPrintTicket;
            ticket.PageMediaSize = new PageMediaSize(200d, 300d);
            // A3など決まったサイズはPageMediaSizeNameで指定できる
            // ticket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA3);
            
            // 印刷部数
            ticket.CopyCount = 2;
            // 解像度
            ticket.PageResolution = new PageResolution(72, 72);
            // 向き(LandscapeにするとMediaSizeの指定が逆になるので注意)
            ticket.PageOrientation = PageOrientation.Landscape;
            // 余白なし
            ticket.PageBorderless = PageBorderless.Borderless;
            
            XpsDocumentWriter writer = PrintQueue.CreateXpsDocumentWriter(queue); 
            writer.Write(target, ticket);
        }
    }
}