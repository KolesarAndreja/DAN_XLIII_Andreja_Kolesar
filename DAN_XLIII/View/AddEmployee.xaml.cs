﻿using DAN_XLIII.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DAN_XLIII.View
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.AddEmployeeViewModel(this);
        }

        public AddEmployee(Service.tblEmployee emp)
        {
            InitializeComponent();
            this.DataContext = new AddEmployeeViewModel(this, emp);
        }
    }
}
