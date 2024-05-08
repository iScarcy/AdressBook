﻿namespace AdressBook.Api.Services.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetByID(string ID);

        Task Insert(T entity);

        Task Update(T entity);
    }
}
