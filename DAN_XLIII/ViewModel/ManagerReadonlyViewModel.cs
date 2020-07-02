using DAN_XLIII.Service;
using DAN_XLIII.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIII.ViewModel
{
    class ManagerReadonlyViewModel:ViewModelBase
    {
        #region Property
        ManagerReadonly readonlyManager;

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
        #endregion

        #region constructor
        public ManagerReadonlyViewModel(ManagerReadonly open)
        {
            readonlyManager = open;
            employeeList = Service.Service.GetAllEmployees();
        }
        #endregion
    }
}
