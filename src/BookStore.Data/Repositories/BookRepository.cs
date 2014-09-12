using BookStore.Data.DataContexts;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreDataContext _db;

        public BookRepository()
        {
            this._db = new BookStoreDataContext();
        }

        public List<Book> Get(int skip = 0, int take = 25)
        {
            return _db.Books.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public Book Get(int id)
        {
            return _db.Books.Find(id);
        }

        public List<Book> GetWithAuthors(int skip = 0, int take = 25)
        {
            return _db.Books.Include(x => x.Authors).OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public Book GetWithAuthors(int id)
        {
            return _db.Books.Include(x => x.Authors).Where(x => x.Id == id).FirstOrDefault();
        }

        public void Create(Book entity)
        {
            _db.Books.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Book entity)
        {
            _db.Entry<Book>(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Books.Remove(_db.Books.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
