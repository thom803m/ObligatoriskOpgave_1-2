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
    public class NewBookTests
    {
        //Metoden vil først blive testet for den titel på bogokjektet er valid implementeret. Formålet: Titlen kan ikke være NULL (Altså uden karakterer).
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateTitleTest()
        {
            var book = new NewBook()
            {
                title = ""
            };
            book.ValidateTitle();
        }

        //Metoden vil for det andet blive testet for den titel på bogokjektet er valid implementeret. Formålet: Titlen skal have de bestemte karakterer.
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateTitleTest2()
        {
            var book = new NewBook()
            {
                title = "ØV"
            };
            book.ValidateTitle();
        }

        //Metoden vil først blive testet for den pris på bogokjektet er valid implementeret. Formålet: Prisen kan ikke være 0 eller lavere.
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidatePriceTest()
        {
            var book = new NewBook()
            {
                price = 0
            };
            book.ValidatePrice();
        }

        //Metoden vil for det andet blive testet for den pris på bogokjektet er valid implementeret. Formålet: Prisen kan ikke være 1201 eller højere.
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidatePriceTest2()
        {
            var book = new NewBook()
            {
                price = 1201
            };
            book.ValidatePrice();
        }
    }
}