using BooksMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksMvcApp.Services
{
    public interface IBookServices
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int Id);
        bool Add(Book book);
        bool Edit(Book book);
        bool Delete(Book book);
    }
}
