using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepository.Core;
using Microsoft.EntityFrameworkCore;

namespace BookRepository.Data
{
    public class SqlData : IBookData
    {
        private readonly BookRepoDbContext _database;

        public SqlData(BookRepoDbContext database)
        {
            this._database = database;
        }

        public Book AddBook(Book newBook)
        {
            _database.Add(newBook);
            return newBook;
        }

        public async Task<bool> DeleteAsync<T>(T entity) where T : IEntity
        {
            var updatedEntity = _database.Remove(entity);
            updatedEntity.State = EntityState.Deleted;

            return (await _database.SaveChangesAsync() > 0);
        }

        public Book GetBook(int Id)
        {
            return _database.Books.Find(Id);
        }

        public async Task<Book> GetBookAsync(int Id)
        {
            return await _database.Books.FindAsync(Id);
        }

        public async Task<IEnumerable<Book>> ListBooksAsync()
        {
            return await _database.Books
                .OrderBy(b => b.Title)
                .ToListAsync();
        }

        public int Save()
        {
            return _database.SaveChanges();
        }

        public async Task<int> SaveAsync<T>(T entity) where T : IEntity
        {
            var addedIdentity = _database.Add(entity);
            var entityId = -1;

            if (await _database.SaveChangesAsync() > -1)
            {
                entityId = Convert.ToInt32(addedIdentity.Property("Id").CurrentValue);
            }

            return entityId;
        }

        public async Task<bool> UpdateAsync<T>(T entity) where T : IEntity
        {
            var updatedEntity = _database.Attach(entity);
            updatedEntity.State = EntityState.Modified;

            return (await _database.SaveChangesAsync() > 0);
        }

        public Book UpdateBook(Book bookData)
        {
            var entity = _database.Books.Attach(bookData);
            entity.State = EntityState.Modified;
            return bookData;
        }
    }
}