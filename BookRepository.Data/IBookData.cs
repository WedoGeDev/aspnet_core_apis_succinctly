using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepository.Core;

namespace BookRepository.Data
{
    public interface IBookData
    {
        Task<IEnumerable<Book>> ListBooksAsync();
        Book GetBook(int Id);
        Task<Book> GetBookAsync(int Id);
        Book UpdateBook(Book bookData);
        Book AddBook(Book newBook);
        int Save();
        Task<int> SaveAsync<T>(T entity) where T : IEntity;
        Task<bool> UpdateAsync<T>(T entity) where T : IEntity;
        Task<bool> DeleteAsync<T>(T entity) where T : IEntity;
    }
}