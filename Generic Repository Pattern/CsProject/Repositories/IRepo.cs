using CsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsProject.Repositories
{
    public interface IRepo<T> where T :BcPerson 
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T person);
        void AddRange(IEnumerable<T> persons);
        void Update(T person);
        void Delete(int id);
    }
}
