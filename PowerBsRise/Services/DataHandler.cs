using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
    }
}
