using FunnyWaterCarrier.Models.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModels
{
    class DepartamentViewModel : BaseViewModel
    {
        private Departament _inputDepartament;
        public DepartamentViewModel(ServiceClient client, BaseViewModel parent) : base(client, parent)
        {
            Departaments = client.GetDepartaments();
        }

        private List<Departament> _subDepartament;
        public List<Departament> Departaments
        {
            get => _subDepartament;
            set
            {
                _subDepartament = value;
                OnPropertyChanged("Departaments");
            }
        }
        public Departament Input
        {
            get => _inputDepartament;
            set
            {
                _inputDepartament = value;
                OnPropertyChanged("Input");
            }
        }

        public ICommand Change
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddDepartamentViewModel(ServiceClient, Parent, _inputDepartament));
            });
        }

        public ICommand Accept
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
