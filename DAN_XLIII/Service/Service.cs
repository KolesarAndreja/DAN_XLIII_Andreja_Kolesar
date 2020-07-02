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
    }
}
