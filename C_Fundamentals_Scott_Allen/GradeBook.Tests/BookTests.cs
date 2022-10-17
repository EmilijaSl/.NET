
using C_Fundamentals_Scott_Allen;

namespace GradeBook.Tests
 
{
    public class BookTests
    {
        [Fact] //atributas
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(85.6, result.Average, 1); //trecias rodmuo yra precisions. Parodo kiek skaiciu po kablelio tikrinti
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

            

            ////arrange vieta kur surasome visas testo vertes ir ko tikimes
            //var x = 5;
            //var y = 10;
            //var expected = 15;

            //// act iskvieti metoda kuris pateiks rezultata 
            //var actual = x + y;

            ////assert 
            //Assert.Equal(expected, actual); //mes pasakome kad 
        }
    }
}