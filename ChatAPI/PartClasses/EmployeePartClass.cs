using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.Model
{
    public partial class Employee
    {
        public string GetName
        {
            get
            {
                string name = $"{FirstName} {SecondName}";
                return name;
            }
        }
    }
}