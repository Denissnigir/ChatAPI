using ChatAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.Models
{
    public partial class ResponseDepartment
    {
        public ResponseDepartment(Department department)
        {
            id = department.Id;
            name = department.Name;
        }
        public int id { get; set; }
        public string name { get; set; }
    }
}