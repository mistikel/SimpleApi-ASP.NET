using SimpleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApiContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{Name="Carson",Nim="09121002001",Major="Teknik Informatika"},
            new Student{Name="Meredith",Nim="09121002001",Major="Teknik Informatika"},
            new Student{Name="Arturo",Nim="09121002001",Major="Teknik Informatika"},
            new Student{Name="Gytis",Nim="09121002001",Major="Teknik Informatika"},
            new Student{Name="Yan",Nim="09121002001",Major="Teknik Informatika"},
            new Student{Name="Peggy",Nim="09121002001",Major="Teknik Informatika"},
            new Student{Name="Laura",Nim="09121002001",Major="Teknik Informatika"},
            new Student{Name="Nino",Nim="09121002001",Major="Teknik Informatika"}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var lecturer = new Lecturer[]
            {
            new Lecturer{Name="Carson",Nip="09121002001",Research="Teknik Informatika"},
            new Lecturer{Name="Meredith",Nip="09121002001",Research="Teknik Informatika"},
            new Lecturer{Name="Arturo",Nip="09121002001",Research="Teknik Informatika"},
            new Lecturer{Name="Gytis",Nip="09121002001",Research="Teknik Informatika"},
            new Lecturer{Name="Yan",Nip="09121002001",Research="Teknik Informatika"},
            new Lecturer{Name="Peggy",Nip="09121002001",Research="Teknik Informatika"},
            new Lecturer{Name="Laura",Nip="09121002001",Research="Teknik Informatika"},
            new Lecturer{Name="Nino",Nip="09121002001",Research="Teknik Informatika"}
            };
            foreach (Lecturer s in lecturer)
            {
                context.Lecturer.Add(s);
            }
            context.SaveChanges();
        }
    }
}
