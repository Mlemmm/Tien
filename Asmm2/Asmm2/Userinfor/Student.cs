using System;
using System.Collections.Generic;
using System.Text;

namespace Asmm2.Userinfor
{
    class Student
    {
        private string batch;
        public Student() { batch = ""; }
        public string Batch
        {
            get { return batch; }
            set { batch = value; }
        }
    
    }
}