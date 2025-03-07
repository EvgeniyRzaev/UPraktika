using System;
using System.Collections.Generic;
using System.Linq;
using EventApp.Models;
using ReactiveUI;

namespace EventApp.ViewModels
{
	public class EventsViewModel : ViewModelBase
	{

        List<Event> events;
        public List<Event> Events { get => events; set => this.RaiseAndSetIfChanged(ref events, value); }
        public EventsViewModel(MainWindowViewModel MVM)
		{
            LoadData();

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