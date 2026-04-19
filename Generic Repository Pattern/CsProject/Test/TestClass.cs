using CsProject.Hospital;
using CsProject.Models;
using CsProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsProject.Test
{
    public class TestClass 
    {
        IRepoHospital hospital;
        public TestClass(IRepoHospital hospital)
        {
           this.hospital = hospital; 
        }

        public void Run()
        {
            IRepo<Doctor> doctorRepo = hospital.CreateRepo<Doctor>();
            doctorRepo.AddRange(new Doctor[]
            {
                new Doctor{Id=1,Name="Dr.Roni",Specialization="Medecin"},
                new Doctor{Id=2,Name="Dr.Golam Kibria",Specialization="Cardiology"},
                new Doctor{Id=3,Name="Dr.Sarmin Jara",Specialization="Gynecology"},
                new Doctor{Id=4,Name="Dr.Muskan",Specialization="Gynecology"},
                new Doctor{Id=5,Name="Dr.Nikhin Shen",Specialization="Arthopedic"},
                new Doctor{Id=6, Name="Dr. Rahman", Specialization="Cardiology"},
                new Doctor{Id=7, Name="Dr. Sultana", Specialization="Gynecology"},
                new Doctor{Id=8, Name="Dr. Ahmed", Specialization="Neurology"},
                new Doctor{Id=9, Name="Dr. Karim", Specialization="Dermatology"},
                new Doctor{Id=10, Name="Dr. Nikhin Shen", Specialization="Arthopedic"},
                new Doctor{Id=11, Name="Dr. Hasan", Specialization="Pediatrics"},
                new Doctor{Id=12, Name="Dr. Farzana", Specialization="Ophthalmology"},
                new Doctor{Id=13, Name="Dr. Kabir", Specialization="ENT"},
                new Doctor{Id=14, Name="Dr. Mahmud", Specialization="Psychiatry"},
                new Doctor{Id=15, Name="Dr. Tania", Specialization="Radiology"}
            });

            //Get All
            Console.WriteLine("==================Get All==================");
            doctorRepo.GetAll().ToList()
              .ForEach(d => Console.WriteLine($"Id : {d.Id}, Name: {d.Name},Specialization : {d.Specialization}"));

            Console.WriteLine();
            //Get by Id
            Console.WriteLine("============================Get==================");
            var doc = doctorRepo.Get(10);
            Console.WriteLine($"Id : {doc.Id}, Name: {doc.Name},Specialization : {doc.Specialization}");

            //Update
            Console.WriteLine();
            Console.WriteLine("============================Update==================");
            doc.Name = "Dr. Roton Das";
            doctorRepo.Update(doc);
            doctorRepo.GetAll().OrderBy(x => x.Id).ToList()
              .ForEach(d => Console.WriteLine($"Id : {d.Id}, Name: {d.Name},Specialization : {d.Specialization}"));

            Console.WriteLine();
            Console.WriteLine("============================Delete==================");
            doctorRepo.Delete(3);
            doctorRepo.GetAll().OrderBy(x => x.Id).ToList()
             .ForEach(d => Console.WriteLine($"Id : {d.Id}, Name: {d.Name},Specialization : {d.Specialization}"));

            Console.WriteLine();

            Console.WriteLine("===================Patient================");
            

            IRepo<Patient> patientRepo = hospital.CreateRepo<Patient>();
            patientRepo.AddRange(new Patient[]
            {
                new Patient{Id=1,Name="Ritu Jahan",Age=20,Disease="Illness",DoctorId=1},
                new Patient{Id=2, Name="Nabila Akter", Age=23, Disease="Fever", DoctorId=6},
                new Patient{Id=3, Name="Rahim Uddin", Age=35, Disease="Diabetes", DoctorId=10},
                new Patient{Id=4, Name="Sadia Islam", Age=28, Disease="Migraine", DoctorId=8},
                new Patient{Id=5, Name="Arif Hossain", Age=42, Disease="Back Pain", DoctorId=9},
                new Patient{Id=6, Name="Mim Sultana", Age=19, Disease="Anemia", DoctorId=7},
                new Patient{Id=7, Name="Hasan Ali", Age=50, Disease="Heart Problem", DoctorId=6},
                new Patient{Id=8, Name="Farhana Rahman", Age=31, Disease="Skin Allergy", DoctorId=9},
                new Patient{Id=9, Name="Jahid Khan", Age=27, Disease="Eye Infection", DoctorId=12},
                new Patient{Id=10, Name="Tania Noor", Age=34, Disease="Thyroid", DoctorId=11},
                new Patient{Id=11, Name="Shakib Mahmud", Age=22, Disease="Asthma", DoctorId=13},
                new Patient{Id=12, Name="Nusrat Jahan", Age=29, Disease="ENT Problem", DoctorId=13},
                new Patient{Id=13, Name="Rasel Mia", Age=45, Disease="Depression", DoctorId=14},
                new Patient{Id=14, Name="Priya Sen", Age=26, Disease="Fracture", DoctorId=10},
                new Patient{Id=15, Name="Imran Hossain", Age=38, Disease="Chest Pain", DoctorId=6}

            });
            //Get All

            Console.WriteLine("==================Get All==================");
          
            patientRepo.GetAll().ToList()
           .ForEach(p => Console.WriteLine($"Id : {p.Id}, Name : {p.Name}, Age : {p.Age},Disease : {p.Disease} "));
            Console.WriteLine();
            
            //Get by Id
            Console.WriteLine("============================Get==================");
            var pat = patientRepo.Get(10);
            Console.WriteLine($"Id : {pat.Id}, Name : {pat.Name}, Age : {pat.Age},Disease : {pat.Disease}");

            //Update
            Console.WriteLine();
            Console.WriteLine("============================Update==================");
            doc.Name = "Jhuma Jui";
            patientRepo.Update(pat);
            patientRepo.GetAll().OrderBy(x => x.Id).ToList()
             .ForEach(p => Console.WriteLine($"Id : {p.Id}, Name : {p.Name}, Age : {p.Age},Disease : {p.Disease} "));

            Console.WriteLine();
            Console.WriteLine("============================Delete==================");
            patientRepo.Delete(3);
            patientRepo.GetAll().OrderBy(x => x.Id).ToList()
            .ForEach(p => Console.WriteLine($"Id : {p.Id}, Name : {p.Name}, Age : {p.Age},Disease : {p.Disease} "));

            Console.WriteLine();
        }
    }
}
