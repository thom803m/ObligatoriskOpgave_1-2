using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpgave_1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgave_1_2.Tests
{
    [TestClass()]
    public class NewBookRepositoryTests
    {

        //Metoden vil blive testet om den er valid implementeret, efter det tilføjet ID.
        [TestMethod()]
        public void GetByIdTest()
        {
            var repository = new NewBookRepository();
            int existingBook = 2;
            NewBook? foundTheBook = repository.GetById(existingBook);

            Assert.IsNotNull(foundTheBook);
            Assert.AreEqual(existingBook, foundTheBook?.id);
        }

        //Metoden vil blive testet om den er valid implementeret, efter om et objekt kan blive tilføjet.
        [TestMethod()]
        public void AddTest()
        {
            var repository = new NewBookRepository();
            var addBook = new NewBook { id = 6, title = "Gummi Tarzan", price = 300 };
            NewBook newBookAdded = repository.Add(addBook);

            Assert.IsNotNull(newBookAdded);
            Assert.AreEqual(addBook.id, newBookAdded.id);
        }

        //Metoden vil blive testet om den er valid implementeret, efter om et objekt kan blive slettet.
        [TestMethod()]
        public void DeleteTest()
        {
            var repository = new NewBookRepository();
            int deleteBook = 1;
            NewBook? newBookDeleted = repository.Delete(deleteBook);

            Assert.IsNotNull(newBookDeleted);
            Assert.AreEqual(deleteBook, newBookDeleted?.id);
            Assert.AreEqual(2, repository.Get().Count);
        }
    }
}