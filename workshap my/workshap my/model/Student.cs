using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshap_my.model
{
    public class Student
    {
       public string Id { get; set; }
       public string Firstname {  get; set; }
       public string Lastname { get; set; }
       public string NationalId {  get; set; }
       public byte Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        byte[]marks { get; set; }= new byte[10];
    }
}
