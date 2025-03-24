using FormulaOne.Views;

namespace FormulaOne
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var display = new Display();

            await display.ShowMenuAsync();
        }
    }
}
