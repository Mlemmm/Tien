using System;
using System.Collections.Generic;
using System.Text;

namespace Asmm2.Userinfor
{
    class Lecturer
    {
        private string dept;
        public Lecturer() { dept = ""; }
        public string Dept
        {
            get { return dept; }
            set { dept = value; } 
        }
    }
}
