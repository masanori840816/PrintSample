using System.Windows.Media;

namespace PrintSample.Prints
{
    public interface IPrinter
    {
        void Print(Visual target);
    }
}