﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06
{
    public class Student : Person
    {
        // properties
        public int RegistrationNumber { get; set; }
        public Course[]? Courses { get; set; }


        // constructors
        public Student()
        {

        }
        public Student(Guid id) : base(id)
        {

        }
        public Student(Guid id, string name) : base(id, name)
        {

        }
        public Student(Guid id, string name, int age) : base(id, name, age)
        {

        }
        public Student(Guid id, string name, int age, int registrationNumber) : base(id, name, age)
        {
            RegistrationNumber= registrationNumber;
        }
        public Student(Guid id, string name, int age, int registrationNumber, Course[] courses) : base(id, name, age)
        {
            RegistrationNumber = registrationNumber; ;
            Courses = courses;
        }


        // methods
        public void Attend (string course, DateTime datetime)
        {

        }

        public void WriteExam (string course, DateTime datetime)
        {

        }

    }
}
