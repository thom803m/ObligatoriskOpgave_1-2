using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObligatoriskOpgave_1_2
{
    public class NewBookRepository
    {
        private int nextId = 1;
        //Objekterne vil blive lagt op i listen og i rækkefølge efter det ID, som obejktet vil få tilsendt. 
        private List<NewBook> newbook = new List<NewBook>();

        public NewBookRepository()
        {
            newbook.Add(new NewBook { id = nextId++, title = "Toy Story", price = 200 });
            newbook.Add(new NewBook { id = nextId++, title = "Tintin", price = 100 });
            newbook.Add(new NewBook { id = nextId++, title = "Lucky Luke", price = 100 });
            newbook.Add(new NewBook { id = nextId++, title = "Tarzan", price = 200 });
            newbook.Add(new NewBook { id = nextId++, title = "Harry Potter", price = 300 });
        }

        //Via denne kollektion vil listen med bogobjekterne, hvis de følge kravene for om prisen på bogen er i mellem den laveste pris og højeste pris.
        //Ojekterne i listen kan også blive efter den's titel og pris.
        public List<NewBook> Get(int? maxPrice = null, int? minPrice = null, bool sortByTitle = false, bool sortByPrice = false)
        {
            IEnumerable<NewBook> filteredBooks = newbook;

            if (maxPrice.HasValue)
            {
                filteredBooks = filteredBooks.Where(book => book.price <= maxPrice.Value);
            }

            if (minPrice.HasValue)
            {
                filteredBooks = filteredBooks.Where(book => book.price >= minPrice.Value);
            }

            if (sortByTitle)
            {
                filteredBooks = filteredBooks.OrderBy(book => book.title);
            }

            if (sortByPrice)
            {
                filteredBooks = filteredBooks.OrderBy(book => book.price);
            }
            return filteredBooks.ToList();
        }

        //Metoden vil kunne finde den eksisterende bog efter sit ID.
        public NewBook? GetById(int id)
        {
            return newbook.Find(book => book.id == id);
        }

        //Metoden vil gøre, at man kan tilføje et nyt bogobjekt til listen, hvis det nyoprettet bogobjekt er validt.
        public NewBook Add(NewBook book)
        {
            book.Validate();
            book.id = nextId++;
            newbook.Add(book);
            return book;
        }

        //Metoden vil gøre, at man kan slette et bogokjekt ved benytte det tilføjet ID.
        public NewBook? Delete(int id)
        {
            NewBook? book = GetById(id);
            if (book != null)
            {
                newbook.Remove(book);
            }
            return book;
        }

        //Metoden vil gøre, at listen vil blive opdateret, når bliver foretaget ændringer.
        public NewBook? Update(int id, NewBook book)
        {
            NewBook? bookToUpdate = GetById(id);
            if (bookToUpdate != null)
            {
                bookToUpdate.title = book.title;
                bookToUpdate.price = book.price;
                bookToUpdate.Validate();
            }
            return bookToUpdate;
        }
    }
}
