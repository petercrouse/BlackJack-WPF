using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Shared;

namespace Blackjack.client.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel()
        {

        }

    }
}
