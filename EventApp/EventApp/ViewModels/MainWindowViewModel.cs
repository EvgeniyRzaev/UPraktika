using ReactiveUI;
using System.Reactive;

namespace EventApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object currentView;
        public ReactiveCommand<Unit,object> NavigateToMain { get; }
        public object CurrentView { get => currentView; set => this.RaiseAndSetIfChanged(ref currentView, value); }

        public MainWindowViewModel()
        {
            CurrentView = new MainViewModel(this);
        }
    }
}
