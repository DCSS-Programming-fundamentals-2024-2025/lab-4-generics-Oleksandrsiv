using System;
using generics.Interfaces;

namespace generics.Entities;

public class InMemoryRepository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity : class, new() where TKey : struct
{
    private Dictionary<TKey, TEntity> _entities = new();
   
    public void Add(TKey id, TEntity entity)
    {
        if (_entities.ContainsKey(id))
        {
            throw new ArgumentException($"An entity with the same key already exists: {id}");
        }
        _entities.Add(id, entity);
    }

    public TEntity Get(TKey id)
    {
        if (!_entities.TryGetValue(id, out var entity))
        {
            throw new KeyNotFoundException($"No entity found with the key: {id}");
        }
        return entity;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _entities.Values;
    }

    public void Remove(TKey id)
    {
        if (!_entities.Remove(id))
        {
            throw new KeyNotFoundException($"No entity found with the key: {id}");
        }
    }
}



public class ReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : class, new()where TKey : struct
{
private readonly Dictionary<TKey, TEntity> _entities = new();

public TEntity Get(TKey id)
{
    if (!_entities.TryGetValue(id, out var entity))
    {
        throw new KeyNotFoundException($"No entity found by id: {id}");
    }
    return entity;
}

public IEnumerable<TEntity> GetAll()
{
    return _entities.Values;
}
}

public class WriteRepository<TEntity, TKey> : IWriteRepository<TEntity, TKey> 
{
    private readonly Dictionary<TKey, TEntity> _entities = new();

    public void Add(TEntity entity)
    {
        var id = (TKey)entity.GetType().GetProperty("Id").GetValue(entity);
        if (_entities.ContainsKey(id))
        {
            throw new ArgumentException($"An entity with the same key already exists: {id}");
        }
        _entities.Add(id, entity);
    }

    public void Remove(TKey id)
    {
        if (!_entities.Remove(id))
        {
            throw new KeyNotFoundException($"No entity found with the key: {id}");
        }
    }
}

    