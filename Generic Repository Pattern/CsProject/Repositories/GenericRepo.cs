using CsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsProject.Repositories
{
    public class GenericRepo<T> : IRepo<T> where T : BcPerson
    {
        private readonly IList<T> data;
        public GenericRepo()
        { 
            this.data = new List<T>();
        }
        public void Add(T person)
        {
            this.data.Add(person);
        }

        public void AddRange(IEnumerable<T> persons)
        {
            foreach (var person in persons)
            {
                this.data.Add(person);
            }
        }

        public void Delete(int id)
        {
            var person = this.data.FirstOrDefault(x => x.Id == id);
            if (person != null)
            {
                this.data.Remove(person);
            }
        }

        public T Get(int id)
        {
            return this.data.FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return this.data.ToList();
        }

        public void Update(T person)
        {
            int i = this.data.IndexOf(person);
            this.data.RemoveAt(i);
            this.data.Add(person);
        }
    }
}
