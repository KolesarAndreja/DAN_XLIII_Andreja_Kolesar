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
    class AuthenticationViewModel : ViewModelBase
    {
        AuthenticationWindow authentication;

        private DAN_XLIII.Model.Employee _currentEmployee;
        public DAN_XLIII.Model.Employee currentEmployee
        {
            get
            {
                return _currentEmployee;
            }

            set
            {
                _currentEmployee = value;
                OnPropertyChanged("currentEmployee");
            }
        }


        public AuthenticationViewModel(AuthenticationWindow authenticationWindow)
        {
            authentication = authenticationWindow;
            currentEmployee = new DAN_XLIII.Model.Employee();
        }


        #region Commands
        private ICommand _login;
        public ICommand login
        {
            get
            {
                if (_login == null)
                {
                    _login = new RelayCommand(param => LoginExecute(), param => CanLoginExecute());
                }
                return _login;
            }
        }

        private void LoginExecute()
        { 
            try
            {
                switch (currentEmployee.role)
                {
                    case "admin":
                        AdminMenu adminMenu = new AdminMenu();
                        adminMenu.ShowDialog();
                        break;
                    case "employee":
                        DAN_XLIII.View.Employee e = new DAN_XLIII.View.Employee(currentEmployee.id);
                        e.ShowDialog();
                        break;
                    case "manager":
                        tblManager m = Service.Service.GetManagerById(currentEmployee.id);
                        if(m.access == "modify")
                        {
                            ManagerModify managerModify = new ManagerModify();
                            managerModify.ShowDialog();
                        }
                        else
                        {
                            ManagerReadonly managerReadonly = new ManagerReadonly();
                            managerReadonly.ShowDialog();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLoginExecute()
        {
            return true;
        }
        #endregion
    }
}