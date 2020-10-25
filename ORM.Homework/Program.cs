using ORM.Homework.Context;
using ORM.Homework.Service;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Homework
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AppService service = new AppService(new HomeworkAppContext());

            var result = await service.CreateFaculty();

            Console.WriteLine(result);

            StringBuilder sb = new StringBuilder();

            foreach (var item in await service.GetAllAsync())
            {
                sb.Append("FullName: " + item.FirstName +" "+ item.LastName +" "+ item.MiddleName + ",");
                sb.Append(" Date of Birth " + item.DateOfBirth.Date.ToString("dd-MM-yy") + ",");
                sb.Append(" Group: " + item.Group.Number + ",");
                sb.Append(" Faculty: " + item.Group.Faculty.Number + Environment.NewLine + ".");
            }

            Console.WriteLine(sb);

            Console.ReadKey();
        }
    }
}
