using FunnyWaterCarrier.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModels
{
    class AddEmployeeModel : BaseViewModel
    {
        private Employee _inputEmloyee;
        public AddEmployeeModel(ServiceClient client, BaseViewModel parent = null, Employee employee = null) : base(client, parent)
        {
            Departaments = client.GetDepartaments();
            EmployeeDate = new DateTime(2001, 01, 01);

            if (employee != null)
            {
                _inputEmloyee = employee;
                EmployeeDate = _inputEmloyee.BirthDate;
                EmployeeSurname = _inputEmloyee.Surname;
                EmployeePatronymic = _inputEmloyee.Patronymic;
                EmployeeName = _inputEmloyee.Name;
                EmployeeDepartament = _inputEmloyee.Departament;
                SelectedGender = _inputEmloyee.Gender;
            }
        }

        private string _employeeSurname;
        private string _employeeName;
        private string _employeePatronymic;
        private Genders _selectedGender;
        private DateTime _employeeDate;
        private Departament _employeeDepartament;

        private List<Departament> _departaments;

        public List<Departament> Departaments
        {
            get
            {
                if (_departaments == null) _departaments = ServiceClient.GetDepartaments();
                return _departaments;
            }
            set
            {
                _departaments = value;
                OnPropertyChanged("Departaments");
            }
        }

        public string EmployeeSurname
        {
            get => _employeeSurname;
            set
            {
                _employeeSurname = value;
                OnPropertyChanged("EmployeeSurname");
            }
        }
        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                _employeeName = value;
                OnPropertyChanged("EmployeeName");
            }
        }
        public string EmployeePatronymic
        {
            get => _employeePatronymic;
            set
            {
                _employeePatronymic = value;
                OnPropertyChanged("EmployeePatronymic");
            }
        }


        private Dictionary<Genders, string> _gender = new Dictionary<Genders, string>()
        {
            {Genders.Male, "Мужской"},
            {Genders.Female, "Женский" }
        };
        public Dictionary<Genders, string> GendersDictionary
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged("GendersDictionary");
            }
        }

        public Genders SelectedGender
        {
            get => _selectedGender;
            set
            {
                _selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }
        public Departament EmployeeDepartament
        {
            get => _employeeDepartament;
            set
            {
                _employeeDepartament = value;
                OnPropertyChanged("EmployeeDepartament");
            }
        }

        public DateTime EmployeeDate
        {
            get => _employeeDate;
            set
            {
                _employeeDate = value;
                OnPropertyChanged("EmployeeDate");
            }
        }

        public ICommand Accept
        {
            get => new BaseCommand((sender) =>
            {
                if (_inputEmloyee == null)
                {
                    if ((EmployeeSurname == null) || (EmployeeName == null) || (EmployeePatronymic == null) ||
                    (EmployeeDate.Year < (DateTime.Now.Year - 100)) || (EmployeeDate.Year > DateTime.Now.Year) || (EmployeeDepartament == null))
                    {
                        StringBuilder errormess = new StringBuilder();
                        if (EmployeeSurname == null) errormess.Append("Не задана фамилия!\n");
                        if (EmployeeName == null) errormess.Append("Не задано имя!\n");
                        if (EmployeePatronymic == null) errormess.Append("Не задано отчество!\n");
                        if ((EmployeeDate.Year < (DateTime.Now.Year - 100)) || (EmployeeDate.Year > DateTime.Now.Year)) errormess.Append("Некорректная дата!\n");
                        if (EmployeeDepartament == null) errormess.Append("Не задано подразделение!\n");
                        MessageBox.Show(Convert.ToString(errormess));
                    }
                    else
                    {
                        ServiceClient.CreateEmployee(EmployeeSurname, EmployeeName, EmployeePatronymic, EmployeeDate, SelectedGender, EmployeeDepartament);
                        Back();
                    }
                }
                else
                {
                    if ((EmployeeSurname == null) || (EmployeeName == null) || (EmployeePatronymic == null) ||
                    (EmployeeDate.Year < (DateTime.Now.Year - 100)) || (EmployeeDate.Year > DateTime.Now.Year) || (EmployeeDepartament == null))
                    {
                        StringBuilder errormess = new StringBuilder();
                        if (EmployeeSurname == null) errormess.Append("Не задана фамилия!\n");
                        if (EmployeeName == null) errormess.Append("Не задано имя!\n");
                        if (EmployeePatronymic == null) errormess.Append("Не задано отчество!\n");
                        if ((EmployeeDate.Year < (DateTime.Now.Year - 100)) || (EmployeeDate.Year > DateTime.Now.Year)) errormess.Append("Некорректная дата!\n");
                        if (EmployeeDepartament == null) errormess.Append("Не задано подразделение!\n");
                        MessageBox.Show(Convert.ToString(errormess));
                    }
                    else
                    {
                        if (_inputEmloyee.Departament.Leader.Id != _inputEmloyee.Id)
                        {
                            _inputEmloyee.Surname = EmployeeSurname;
                            _inputEmloyee.Name = EmployeeName;
                            _inputEmloyee.Patronymic = EmployeePatronymic;
                            _inputEmloyee.BirthDate = EmployeeDate;
                            _inputEmloyee.Gender = SelectedGender;
                            _inputEmloyee.Departament = EmployeeDepartament;
                            ServiceClient.ChangeEmployee(_inputEmloyee);
                            Back();
                        }
                        else
                        {
                            MessageBox.Show($"Сотрудник является руководителем.\nСмените руководителя \"{_inputEmloyee.Departament.Name}\"");
                        }
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
