using DAN_XLIII.Command;
using DAN_XLIII.Service;
using DAN_XLIII.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIII.ViewModel
{
    class AdminViewModel:ViewModelBase
    {
        AdminMenu adminMenu;
        private tblEmployee _newEmployee;
        public tblEmployee newEmployee
        {
            get
            {
                return _newEmployee;
            }
            set
            {
                _newEmployee=value;
                OnPropertyChanged("newEmployee");
            }
        }

        public AdminViewModel(AdminMenu openAdminMenu)
        {
            adminMenu = openAdminMenu;
            newEmployee = new tblEmployee(); 
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
                Service.Service.AddNewEmployeeOrManager(newEmployee, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            //if (String.IsNullOrEmpty(newUser.firstname) || String.IsNullOrEmpty(newUser.lastname) || String.IsNullOrEmpty(newUser.authority) || String.IsNullOrEmpty(newUser.sex) || String.IsNullOrEmpty(newUser.jmbg) || newUser.location == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            return true;
        }

        private ICommand _logOut;
        public ICommand logOut
        {
            get
            {
                if (_logOut == null)
                {
                    _logOut = new RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }
                return _logOut;
            }
        }

        private void LogOutExecute()
        {
            try
            {
                adminMenu.Close();
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
