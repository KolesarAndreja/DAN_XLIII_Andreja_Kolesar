using DAN_XLIII.Command;
using DAN_XLIII.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIII.ViewModel
{
    class EmployeeViewModel:ViewModelBase
    {
        View.Employee emp;

        private tblReport _newReport;
        public tblReport newReport
        {
            get
            {
                return _newReport;
            }
            set
            {
                _newReport = value;
                OnPropertyChanged("newReport");
            }
        }


        public EmployeeViewModel(View.Employee open, int id)
        {
            emp = open;
            newReport = new tblReport();
            newReport.employeeId = id;
        }


        #region Commands

        private ICommand _save;
        public ICommand save
        {
            get
            {
                if (_save == null)
                {
                    _save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return _save;
            }
        }

        private void SaveExecute()
        {
            try
            {
                string r = Service.Service.AddReport(newReport);
                if (r != null)
                {
                    MessageBox.Show(r);
                }
                else
                {
                    MessageBox.Show("Report has been saved.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(newReport.project))
            { 
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand _logOut;
        public ICommand logOut
        {
            get
            {
                if (_logOut == null)
                {
                    _logOut = new Command.RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }
                return _logOut;
            }
        }

        private void LogOutExecute()
        {
            try
            {
                emp.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogOutExecute()
        {
            return true;
        }
        #endregion
    }
}
