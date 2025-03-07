using System;
using System.Collections.Generic;
using ReactiveUI;
using EventApp.Models;
using System.Linq;
using Avalonia.Media.Imaging;
using Tmds.DBus.Protocol;
using System.Reactive;

namespace EventApp.ViewModels
{
	public class OrganizatorViewModel : ViewModelBase
	{
		private List<User> UsersList;
		private string Message;
		private Bitmap Avatar;
        private string dayMessage;
        public  ReactiveCommand <Unit, object> NavigateToEvent { get; }
        public TimeSpan CurrentTime => DateTime.Now.TimeOfDay;
        TimeSpan morning = new TimeSpan(9, 0, 0);
        TimeSpan morning_end = new TimeSpan(11, 0, 0);
        TimeSpan day_start = new TimeSpan(11, 1, 0);
        TimeSpan day_end = new TimeSpan(18, 0, 0);
        TimeSpan evening_start = new TimeSpan(18, 1, 0);
        TimeSpan evening_end = new TimeSpan(24, 0, 0);

        public OrganizatorViewModel(MainWindowViewModel MVM, User user)
		{
            NavigateToEvent = ReactiveCommand.Create(() => MVM.CurrentView = new EventsViewModel(MVM));

            if (CurrentTime >= morning && CurrentTime <= morning_end)
            {
                DayMessage = "Доброе утро!";

            }
            else if (CurrentTime >= day_start && CurrentTime <= day_end)
            {
                DayMessage = "Добрый день!";
            }
            else if (CurrentTime >= evening_start && CurrentTime <= evening_end)
            {
                DayMessage = "Добрый вечер!";
            }
            else
            {
                DayMessage = "Доброй ночи!";
            }

            if (user.GenderId == 1)
            {
                Message1 = $"Mr. {user.FirstName} {user.Patronymic}";
            }
            else
            {
                Message1 = $"Mrs. {user.FirstName} {user.Patronymic}";
            }
            Avatar1 = user.Image;
		}

        public List<User> UsersList1 { get => UsersList; set => this.RaiseAndSetIfChanged(ref UsersList, value); }
        public string Message1 { get => Message; set => this.RaiseAndSetIfChanged(ref Message, value); }
        public Bitmap Avatar1 { get => Avatar; set => this.RaiseAndSetIfChanged(ref Avatar, value); }
        public string DayMessage { get => dayMessage; set => this.RaiseAndSetIfChanged(ref dayMessage, value); }
    }


}