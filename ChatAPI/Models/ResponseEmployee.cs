using ChatAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ChatAPI.Models
{
    public partial class ResponseEmployee
    {
        public ResponseEmployee(Employee employee)
        {
            id = employee.Id;
            firstName = employee.FirstName;
            secondName = employee.SecondName;
            departmentId = employee.DepartmentId;
            username = employee.Username;
            password = employee.Password;
            getName = employee.GetName;
        }
        public int id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public int departmentId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string getName { get; set; }
    }
}