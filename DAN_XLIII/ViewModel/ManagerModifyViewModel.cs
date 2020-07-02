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
    class ManagerModifyViewModel:ViewModelBase
    {
        #region Property
        ManagerModify modify;

        private List<tblEmployee> _employeeList;
        public List<tblEmployee> employeeList
        {
            get
            {
                return _employeeList;
            }
            set
            {
                _employeeList = value;
                OnPropertyChanged("employeesList");
            }
        }


        private tblEmployee _viewEmployee;
        public tblEmployee viewEmployee
        {
            get
            {
                return _viewEmployee;
            }
            set
            {
                _viewEmployee = value;
                OnPropertyChanged("viewEmployee");
            }
        }
        private bool _isDeletedEmployee;
        public bool isDeletedEmployee
        {
            get
            {
                return _isDeletedEmployee;
            }
            set
            {
                _isDeletedEmployee = value;
            }
        }
        #endregion

        #region constructor
        public ManagerModifyViewModel(ManagerModify openModify)
        {
            modify = openModify;
            employeeList = Service.Service.GetAllEmployees();
        }
        #endregion


        #region DELETE command
        private ICommand _deleteThisEmployee;
        public ICommand deleteThisEmployee
        {
            get
            {
                if (_deleteThisEmployee == null)
                {
                    _deleteThisEmployee = new Command.RelayCommand(param => DeleteThisEmployeeExecute(), param => CanDeleteThisEmployeeExecute());

                }
                return _deleteThisEmployee;
            }
        }

        private void DeleteThisEmployeeExecute()
        {
            MessageBoxResult result = MessageBox.Show("Do you realy want to delete this user?", "Delete User", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Service.Service.DeleteEmployee(viewEmployee);
                //string content2 = "User  " + viewUser.fullname + " with id " + viewUser.userID + " has been deleted.";
                //LogIntoFile.getInstance().PrintActionIntoFile(content2);
                isDeletedEmployee = true;
                employeeList = Service.Service.GetAllEmployees();

            }
        }
        private bool CanDeleteThisEmployeeExecute()
        {
            return true;
        }

        //open window for editing user's data
        private ICommand _editThisEmployee;
        public ICommand editThisEmployee
        {
            get
            {
                if (_editThisEmployee == null)
                {
                    _editThisEmployee = new RelayCommand(param => EditThisEmployeeExecute(), param => CanEditThisEmployeeExecute());
                }
                return _editThisEmployee;
            }
        }
        #endregion

        #region EDIT command
        private void EditThisEmployeeExecute()
        {
            try
            {
                //pass data about user as viewUser parameter
                //EditUser editUser = new EditUser(viewUser);
                //editUser.ShowDialog();
                //if ((editUser.DataContext as EditUserViewModel).isUpdatedUser == true)
                //{
                //    userList = Service.Service.GetAllUsers();

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanEditThisEmployeeExecute()
        {
            return true;
        }
        #endregion
    }
}
