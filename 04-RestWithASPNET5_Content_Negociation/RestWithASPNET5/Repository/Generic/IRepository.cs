﻿using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Base;

namespace RestWithASPNET5.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
    }
}
