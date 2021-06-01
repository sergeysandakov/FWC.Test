using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(ServiceClient client, BaseViewModel parent = null) : base(client, parent)
        {
        }

        public ICommand AddDepartament
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddDepartamentViewModel(ServiceClient, this));
            });
        }

        public ICommand AddEmployee
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddEmployeeModel(ServiceClient, this));
            });
        }

        public ICommand AddOrder
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddOrderViewModel(ServiceClient, this));
            });
        }

        public ICommand ShowDepartament
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new DepartamentViewModel(ServiceClient, this));
            });
        }
        public ICommand ShowEmployee
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new EmployeeViewModel(ServiceClient, this));
            });
        }
        public ICommand ShowOrder
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new OrderViewModel(ServiceClient, this));
            });
        }
    }
}
