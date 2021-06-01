using FunnyWaterCarrier.Models.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModels
{
    class OrderViewModel : BaseViewModel
    {
        private Order _inputOrder;
        public OrderViewModel(ServiceClient client, BaseViewModel parent = null) : base(client, parent)
        {
            Orders = client.GetOrders();
        }

        private List<Order> _orders;
        public List<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }
        public Order Input
        {
            get => _inputOrder;
            set
            {
                _inputOrder = value;
                OnPropertyChanged("Input");
            }
        }

        public ICommand Change
        {
            get => new BaseCommand((object obj) =>
            {
                OnShowView(this, new AddOrderViewModel(ServiceClient, Parent, _inputOrder));
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
