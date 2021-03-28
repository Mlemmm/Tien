using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Asm2
{
        internal abstract class Users
        {
            public abstract UserTpye UP { get; }
            protected string ID { get; set; }
            protected string Name { get; set; }
            protected DateTime DateOfBirth { get; set; }
            protected string Email { get; set; }
            protected string Address { get; set; }
            protected string Type { get; set; }

            public string SetID(string value) => ID = value;
            public string SetName(string value) => Name = value;
            public DateTime SetDateOfBirth(DateTime value) => DateOfBirth = value;
            public string SetEmail(string value) => Email = value;
            public string SetAddress(string value) => Address = value;
            public string SetType(string value) => Type = value;

            public string GetID() => ID;

            public string GetName() => Name;

            public Users(string[] inputFields)
            {
                ID = inputFields[0];
                Name = inputFields[1];
                DateOfBirth = DateTime.Parse(inputFields[2], CultureInfo.CreateSpecificCulture("de-DE"));
                Email = inputFields[3];
                Address = inputFields[4];
                Type = inputFields[5];
            }

            public string DiplayUsers()
            {
                var typeOfType = GetType().Name == "Student" ? "BATCH" : "DEPARTMENT";
                return
                    "ID: " + ID +
                    " || NAME: " + Name +
                    " || DATE OF BIRTH: " + DateOfBirth.ToString("dd-MM-yyyy") +
                    " || EMAIL: " + Email +
                    " || ADDRESS: " + Address +
                    " || " + typeOfType + ": " + Type;
            }
        }

        public enum UserTpye
    {
            Student,
            Lecturer
        }

        internal class Student : Users
        {
            public Student(string[] inputFields) : base(inputFields)
            {
            }

            public override UserTpye UP { get => UserTpye.Student; }
        }

        internal class Lecturer : Users
        {
            public Lecturer(string[] inputFields) : base(inputFields)
            {
            }

            public override UserTpye UP { get => UserTpye.Lecturer; }
        }
}
