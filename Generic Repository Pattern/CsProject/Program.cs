using CsProject.Hospital;
using CsProject.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepoHospital repoHospital = new RepoHospital();
            TestClass test = new TestClass(repoHospital);
            test.Run();
            Console.ReadKey();
        }
    }
}
