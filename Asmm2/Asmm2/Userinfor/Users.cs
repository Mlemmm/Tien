using System;
using System.Collections.Generic;
using System.Text;

namespace Asmm2.Userinfor
{
    class User
    {
        private string id, name, dob, email, address;
        Lecturer lect = new Lecturer();
        Student stu = new Student();
        public User() { }
        public User(string ID, string Name, string DoB, string Email, string Address, string Batch, string Dept)
        {
            id = ID;
            name = Name;
            dob = DoB;
            email = Email;
            address = Address;
            lect.Dept = Dept;
            stu.Batch = Batch;
        }
        public string Dept
        {
            get { return lect.Dept; }
            set { lect.Dept = value; }
        }
        public string Batch
        {
            get { return stu.Batch; }
            set { stu.Batch = value; }
        }
        public string ID 
        { 
            get { return id; }
            set { id = value; }
        }
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        public string DoB 
        {
            get { return dob; }
            set { dob = value; } 
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
                
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }   
}

