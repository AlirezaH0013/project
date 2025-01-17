using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using workshap_my.model;
using static System.Net.Mime.MediaTypeNames;
namespace workshap_my.serveses
{

    public class Student_reposestory
    {
        private model.Student?[] students = new model.Student?[20];

        public bool Add(Student student)
        {
            int nullIndex = 0;
            for (int index = 0; index < students.Length; index++)
            {
                if (students[index] == null)
                {
                    nullIndex = index;
                    break;
                }
            }
            students[nullIndex] = student;
            return true;
        }
         public int? Findindex(string id)
        {
            for (int index = 0;index < students.Length; index++)
            {
                if (students[index] != null && students[index].Id == id)
                {
                    return index;
                }
            }
            return null;
        }

        public bool Editstudent(string id, string firstname, string lastname, string nationalid, byte age, string country, string city, string phone)
        {
            var student=GetStudent(id);
            if (student == null) 
                return false;
            student.Firstname = firstname;
            student.Lastname = lastname;
            student.NationalId = nationalid;
            student.Age = age;
            student.Country = country;
            student.City = city;
            student.Phone = phone;
            return true;

        }

        public Student[] GetAll()
        {
            return students;
        }

        public bool Deletestudent(string id)
        {
            int indextodelete = -1;
            for (int index = 0; index < students.Length; index++)
            {
                if (students[index]!=null && students[index].Id==id)
                {
                    indextodelete=index;
                }
            }
            if (indextodelete < 0)
                return false;
            students[indextodelete] = null;
            return true;
        }

        public Student?GetStudent(int index)
        {
            return students[index];
        }
        public Student?GetStudent(string id)
        {
            var index=Findindex(id);
            if(index.HasValue)
                return students[index.Value];
            return null;  
        }

        public bool Add(string id, string firstname, string lastname, string nationalid, byte age, string country, string city, string phone)
        {
            return Add(new Student()
            {
                Id = id,
                Firstname = firstname,
                Lastname = lastname,
                NationalId = nationalid,
                Age = age,
                Country = country,
                City = city,
                Phone = phone
            });
        }

   

        public int cont
        {
            get
            {
                int cont = 0;
          for (int i = 0; i < students.Length; i++)
                {
                    if (students[i] != null)
                        cont++;
                }
          return cont; 
            }
        }


    }
}

