using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FunnyWaterCarrier.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public object Sender;
        public delegate void ViewModelHandler(object sender, BaseViewModel viewModel);

        public event ViewModelHandler ShowViewEvent;

        protected ServiceClient ServiceClient;
        protected BaseViewModel Parent;

        public BaseViewModel(ServiceClient client, BaseViewModel parent = null)
        {
            ServiceClient = client;
            Parent = parent;
        }

        protected virtual void OnShowView(object sender, BaseViewModel viewmodel)
        {
            ShowViewEvent?.Invoke(sender, viewmodel);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
