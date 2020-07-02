using DAN_XLIII.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIII.Model
{
    //employee model contain username, password, role, and id
    class Employee
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role {
            get
            {
                
                if (username == "WPFadmin" && password == "WPFadmin")
                {
                    return "admin";
                }
                else if (Service.Service.GetEmployeeByUsernameAndPsw(username, password) == null)
                {
                    return "unemployed";
                }
                else
                {
                    tblEmployee employee = Service.Service.GetEmployeeByUsernameAndPsw(username, password);
                    if (Service.Service.isManager(employee))
                    {
                        return "manager";
                    }
                    else
                    {
                        return "employee";
                    }
                }
            }
        }
        public int id
        {
            get
            {
                if (role == "manager" || role == "employee")
                {
                    return Service.Service.GetEmployeeByUsernameAndPsw(username, password).employeeId;
                }
                else if (role == "admin")
                {
                    return -1;
                }
                else
                {
                    return 0;
                }

            }
        }
    }
}
