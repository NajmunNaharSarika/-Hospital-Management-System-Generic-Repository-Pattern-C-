using CsProject.Models;
using CsProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsProject.Hospital
{
    public interface IRepoHospital
    {
        IRepo<T> CreateRepo<T>() where T : BcPerson;
    }
}
