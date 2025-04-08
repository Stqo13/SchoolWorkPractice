using System.Runtime.CompilerServices;
using UniSystem.Controllers;
using UniSystem.Data;
using UniSystem.Views;

namespace UniSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var context = new UniversityDbContext();
            var uniController = new UniversityController(context);
            var facultyController = new FacultyController(context);
            var majorController = new MajorController(context);

            Display display = new Display(uniController, facultyController, majorController);

            await display.Operations();
        }
    }
}
