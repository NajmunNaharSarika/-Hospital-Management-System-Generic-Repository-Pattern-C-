using CsProject.Models;
using CsProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsProject.Hospital
{
    public class RepoHospital : IRepoHospital
    {
        public IRepo<T> CreateRepo<T>() where T : BcPerson
        {
            return new GenericRepo<T>();
        }
    }
}
