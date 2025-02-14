using System;
using System.Collections.Generic;

namespace PowerBsRise.Services
{
    public class DataHandler<T>
    {
        List<T> _listOfObjects = new List<T>();

        public DataHandler()
        {
        }

        public void Add(T obj)
        {
            _listOfObjects.Add(obj);
        }

        public void Remove(T obj)
        {
            _listOfObjects.Remove(obj);
        }

        public T Get(int id) 
        {
            throw new NotImplementedException();
        }
        public List<T> GetAll()
        {
            return _listOfObjects;
        }
    }
}
