using DAN_XLIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIII.Service
{
    class Service
    {
        public static tblEmployee GetEmployeeByUsernameAndPsw(string username, string password)
        {
            try
            {
                using (DataRecordsEntities context = new DataRecordsEntities())
                {
                    tblEmployee result = (from x in context.tblEmployees where x.username == username && x.password == password select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public static bool isManager(tblEmployee e)
        {
            try
            {
                using (DataRecordsEntities context = new DataRecordsEntities())
                {
                    tblManager result = (from x in context.tblManagers where x.managerId == e.employeeId select x).FirstOrDefault();
                    if (result != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return false;
            }
        }

        public static tblManager GetManagerById(int id)
        {
            try
            {
                using (DataRecordsEntities context = new DataRecordsEntities())
                {
                    tblManager result = (from x in context.tblManagers where x.managerId == id select x).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }

        }


        #region ADD
        /// <summary>
        /// Add new employee or manager to db. 
        /// </summary>
        /// <param name="employee">Add this employee to db</param>
        /// <param name="manager">true if this employee is also and manager</param>
        public static void AddNewEmployeeOrManager(tblEmployee employee, bool manager)
        {
            try
            {
                using (DataRecordsEntities context = new DataRecordsEntities())
                {
                    //add into tblEmployee
                    tblEmployee newEmployee = new tblEmployee();
                    newEmployee.firstname = employee.firstname;
                    newEmployee.lastname = employee.lastname;
                    newEmployee.dateOfBirth = employee.dateOfBirth;
                    newEmployee.jmbg = employee.jmbg;
                    newEmployee.accountNumber = employee.accountNumber;
                    newEmployee.mail = employee.mail;
                    newEmployee.salary = employee.salary;
                    newEmployee.position = employee.position;
                    newEmployee.username = employee.username;
                    newEmployee.password = employee.password;
                    context.tblEmployees.Add(newEmployee);
                    context.SaveChanges();
                    employee.employeeId = newEmployee.employeeId;

                    if (manager)
                    {
                        //add into tblManager
                        tblManager newManager = new tblManager();
                        newManager.managerId = employee.employeeId;
                        newManager.sector = employee.sector;
                        newManager.access = employee.access;
                        context.tblManagers.Add(newManager);
                        context.SaveChanges();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return;
            }
        }
        #endregion
    }
}
