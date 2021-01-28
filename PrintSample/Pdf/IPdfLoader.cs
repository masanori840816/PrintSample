using System.Threading.Tasks;
using System.Windows.Controls;
using PrintSample.Files;

namespace PrintSample.Pdf
{
    public interface IPdfLoader
    {
        Task<Image> LoadAsync(LoadPdfFileArgs args);
    }
}