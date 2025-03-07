using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using EventApp.Models;
using ReactiveUI;

namespace EventApp.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
        public ReactiveCommand<Unit, object>  NavigateToLogin{ get; }
       
        List<Event> events;
        public List<Event> Events { get => events; set => this.RaiseAndSetIfChanged(ref events, value); }
        public MainViewModel(MainWindowViewModel MVM)
        {
            LoadData();
            NavigateToLogin = ReactiveCommand.Create(() => MVM.CurrentView = new LoginViewModel(MVM));
        }
        public void LoadData()
        {

            Events = db.Events.Select(e => new Event
            {
                EventTitle = e.EventTitle,
                Photo = e.Photo,
                Days = e.Days,
                StartDate = e.StartDate,

            }).ToList();
        }

    }
}