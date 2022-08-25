﻿using SMHotelBookingApp.Data_EF.Context;
using SMHotelBookingApp.Domain.Interfaces;
using System.Linq.Expressions;

namespace SMHotelBookingApp.Data_EF.TypeRepository;


public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly SMHotelBookingContext _context;

    public GenericRepository(SMHotelBookingContext sMHotelBookingContex)
    {
        _context = sMHotelBookingContex;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public void Edit(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public T Get(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
}
