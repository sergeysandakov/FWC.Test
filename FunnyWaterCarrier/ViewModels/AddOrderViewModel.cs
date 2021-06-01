using FunnyWaterCarrier.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace FunnyWaterCarrier.ViewModels
{
    class AddOrderViewModel : BaseViewModel
    {
        private Order _inputOrder;
        public AddOrderViewModel(ServiceClient client, BaseViewModel parent = null, Order input = null) : base(client, parent)
        {
            Employees = client.GetEmployees();
            if (input != null)
            {
                _inputOrder = input;
                OrderNumber = _inputOrder.Number;
                OrderPartner = _inputOrder.Partner;
                OrderWorker = _inputOrder.Worker;
            }
        }

        private int _orderNumber;
        private string _orderPartner;
        private Employee _orderWorker;

        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get
            {
                if (_employees == null) _employees = ServiceClient.GetEmployees();
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public int OrderNumber
        {
            get => _orderNumber;
            set
            {
                _orderNumber = Convert.ToInt32(value);
                OnPropertyChanged("OrderNumber");
            }
        }
        public string OrderPartner
        {
            get => _orderPartner;
            set
            {
                _orderPartner = value;
                OnPropertyChanged("OrderPartner");
            }
        }

        public Employee OrderWorker
        {
            get => _orderWorker;
            set
            {
                _orderWorker = value;
                OnPropertyChanged("OrderWorker");
            }
        }

        public ICommand Accept
        {
            get => new BaseCommand((sender) =>
            {
                if (_inputOrder == null)
                {
                    if ((OrderNumber == 0) || (OrderPartner == null) || (OrderWorker == null))
                    {
                        StringBuilder errormess = new StringBuilder();
                        if (OrderNumber == 0) errormess.Append("Не задан номер заказа!\n");
                        if (OrderPartner == null) errormess.Append("Не задано название товара!\n");
                        if (OrderWorker == null) errormess.Append("Не задан сотрудник!\n");
                        MessageBox.Show(Convert.ToString(errormess));
                    }
                    else
                    {
                        ServiceClient.CreateOrder(OrderNumber, OrderPartner, OrderWorker);
                        Back();
                    }
                }
                else
                {
                    if ((OrderNumber == 0) || (OrderPartner == null) || (OrderWorker == null))
                    {
                        StringBuilder errormess = new StringBuilder();
                        if (OrderNumber == 0) errormess.Append("Не задан номер заказа!\n");
                        if (OrderPartner == null) errormess.Append("Не задано название товара!\n");
                        if (OrderWorker == null) errormess.Append("Не задан сотрудник!\n");
                        MessageBox.Show(Convert.ToString(errormess));
                    }
                    else
                    {
                        _inputOrder.Number = OrderNumber;
                        _inputOrder.Partner = OrderPartner;
                        _inputOrder.Worker = OrderWorker;
                        ServiceClient.ChangeOrder(_inputOrder);
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
