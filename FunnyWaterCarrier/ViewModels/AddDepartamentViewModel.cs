using FunnyWaterCarrier.Models.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModels
{
    public class AddDepartamentViewModel : BaseViewModel
    {
        private Departament _inputDepartament;
        public AddDepartamentViewModel(ServiceClient client, BaseViewModel parent = null, Departament input = null) : base(client, parent)
        {
            if (input != null)
            {
                _inputDepartament = input;
                _employees = ServiceClient.GetEmployeesInDepartament(_inputDepartament);
                DepartamentName = _inputDepartament.Name;
                DepartamentLeader = _inputDepartament.Leader;
            }
        }

        private string _departamentName;
        private Employee _departamentLeader;

        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get
            {
                if ((_employees == null) && (_inputDepartament != null)) _employees = ServiceClient.GetEmployeesInDepartament(_inputDepartament);
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public string DepartamentName
        {
            get => _departamentName;
            set
            {
                _departamentName = value;
                OnPropertyChanged("DepartamentName");
            }
        }

        public Employee DepartamentLeader
        {
            get => _departamentLeader;
            set
            {
                _departamentLeader = value;
                OnPropertyChanged("DepartamentLeader");
            }
        }

        public ICommand Accept
        {
            get => new BaseCommand((sender) =>
            {
                if (_inputDepartament == null)
                {
                    if (DepartamentName == null) MessageBox.Show("Не задано название подразделения");
                    else
                    {
                        ServiceClient.CreateDepartament(DepartamentName, DepartamentLeader);
                        Back();
                    }
                }
                else
                {
                    if (DepartamentName == null) MessageBox.Show("Не задано название подразделения");
                    else
                    {
                        _inputDepartament.Name = DepartamentName;
                        _inputDepartament.Leader = DepartamentLeader;
                        ServiceClient.ChangeDepartament(_inputDepartament);
                        Back();
                    }
                }
            });
        }

        public ICommand Decline
        {
            get => new BaseCommand((sender) =>
            {
                Back();
            });
        }

        private void Back()
        {
            OnShowView(this, Parent);
        }
    }
}
