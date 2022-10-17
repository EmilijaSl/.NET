/*var numbers = new[] {10,9,8.5,9.7 };*/ //sukuriame nauja areju ir ji uzpildome
namespace C_Fundamentals_Scott_Allen
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's grade book");
       
            EnterGrades(book);

            var stats = book.GetStatistics();
            book.Name = "";

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"Result is {stats.Average}"); //N:skaicius parodo kiek skaiciu turi buti po kablelio
            Console.WriteLine($"Highest result is {stats.High}");
            Console.WriteLine($"Lowest result is {stats.Low}");
            Console.WriteLine($"The letter grade is {stats.Letter}");




        }
        private static void EnterGrades(Book book)
        {
            while (true)
            {
                Console.WriteLine("Insert new gradeor q to quit");
                var userInput = (Console.ReadLine());

                if (userInput == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(userInput);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }

    }
}
