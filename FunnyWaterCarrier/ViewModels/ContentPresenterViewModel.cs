namespace FunnyWaterCarrier.ViewModels
{
    public class ContentPresenterViewModel : BaseViewModel
    {
        private BaseViewModel _view;
        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public BaseViewModel ViewModel
        {
            get => _view;
            set
            {
                _view = value;
                OnPropertyChanged("ViewModel");
            }
        }

        public ContentPresenterViewModel() : base(new ServiceClient(), null)
        {
            Title = "Веселый Водовоз";
            ShowView(this, new MainViewModel(ServiceClient));
        }

        public void ShowView(object sender, BaseViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.ShowViewEvent += ShowView;
        }
    }
}
