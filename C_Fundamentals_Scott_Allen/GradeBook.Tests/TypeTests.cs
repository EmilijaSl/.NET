
using C_Fundamentals_Scott_Allen;

namespace GradeBook.Tests
 
{
    public delegate string WriteLogDelegate (string logMessage);
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPontToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal("Hello!", result);
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }


        [Fact]
        public void StringsBehavesLikeValueType()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }
        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }


        [Fact] //atributas
        public void ValueTypesAlsoPassByValue()
        {
            var x= GetInt();
           SetInt(ref x);

            Assert.Equal(42, x);

        }
        private int GetInt()
        {
            return 3;
        }
        private void SetInt(ref int x)
        {
            x = 42;
        }

        [Fact] //atributas
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }
        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }


        [Fact] //atributas
        public void CSharpIsPasByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);

        }
        private void GetBookSetName(Book book, string name)
        {
            book= new Book (name);
        }


        [Fact] //atributas
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            
        }
        private void SetName(Book book, string name)
        { 
        book.Name= name;
        }

        [Fact] //atributas
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2"); 

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact] //atributas
        public void TwoVarsCarReferenceSameObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1; //sita eilute nukopijuojam book1 verte ir perkeliau koijuota i book2

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }


        Book GetBook(string name) //parametras pries pavadinima ivardina grazintina tipa
        { 
        return new Book(name);
        }
    }
}