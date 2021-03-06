using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        private int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal("Hello!", result);
        }

        string IncrementCount(string messge)
        {
            count++;
            return messge.ToUpper();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(3, x);
        }

        private void SetInt(ref Int32 z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("InMemoryBook 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(out InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("InMemoryBook 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("InMemoryBook 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook = new InMemoryBook(name);
        }

        private void SetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("InMemoryBook 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void GetBookReturnsDifferentObject()
        {
            var book1 = GetBook("InMemoryBook 1");
            var book2 = GetBook("InMemoryBook 2");

            Assert.Equal("InMemoryBook 1", book1.Name);
            Assert.Equal("InMemoryBook 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("InMemoryBook 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }
    }
}
