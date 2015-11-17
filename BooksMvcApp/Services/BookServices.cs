using BooksMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksMvcApp.Services
{
    public class BookServices:IBookServices
    {
        public IEnumerable<Book> GetAllBooks()
        {
            using (var db = new BookContext())
            {
                return db.Books.ToList();
            }
        }

        public Book GetBookById(int Id)
        {
            Book _objBook = new Book();
            using (var db = new BookContext())
            {
                _objBook = db.Books.Find(Id);
            }
           return _objBook;
        }

        public bool Add(Book book)
        {
            Boolean res = false;
            using (var db = new BookContext())
            {
                    db.Books.Add(book);
                    db.SaveChanges();
                    res = true;
             
            }
            return res;
        }

        public bool Edit(Book book)
        {
            Boolean res = false;
            using (var db = new BookContext())
            {
               db.Entry(book).State = System.Data.EntityState.Modified;
               db.SaveChanges();
               res = true;
                
            }
            return res;
        }

        public bool Delete(Book book)
        {
            Boolean res = false;
            using (var db = new BookContext())
            {
               db.Entry(book).State = System.Data.EntityState.Deleted;
               db.SaveChanges();
               res = true;
                
            }
            return res;
        }
        


       
    }
}