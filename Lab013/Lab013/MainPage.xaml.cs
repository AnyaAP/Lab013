using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace Lab013
{
    public partial class MainPage : ContentPage
    {
        private readonly ApplicationContext context;
        public List<Train> Trains { get; private set; } = new List<Train>();
        public List<Passenger> Passengers { get; private set; } = new List<Passenger>();
        public List<Ticket> Tickets { get; private set; } = new List<Ticket>();
        public MainPage()
        {
            InitializeComponent();
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            context = new ApplicationContext(options);
        }
        protected override async void OnAppearing()
        {
            Trains = context.Trains.AsNoTracking().ToList();
            Passengers = context.Passengers.AsNoTracking().ToList();
            Tickets = context.Tickets.AsNoTracking().ToList();

            base.OnAppearing();
            trainsList.ItemsSource = Trains;
            passengersList.ItemsSource = Passengers;
            ticketsList.ItemsSource = Tickets;
        }
        private void TrainsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
             Train selectedTrain = e.Item as Train;
             TrainPage trainPage = new TrainPage(context);
             trainPage.BindingContext = selectedTrain;
             Navigation.PushAsync(trainPage);
        }
        
        private void CreateTrain(object sender, EventArgs e)
        {
            Train train = new Train();
            TrainPage trainPage = new TrainPage(context);
            trainPage.BindingContext = train;
            Navigation.PushAsync(trainPage);
        }
        private void PassengersList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Passenger selectedPassenger = e.Item as Passenger;
            PassengerPage passengerPage = new PassengerPage(context);
            passengerPage.BindingContext = selectedPassenger;
            Navigation.PushAsync(passengerPage);
        }
        private void CreatePassenger(object sender, EventArgs e)
        {
            Passenger passenger = new Passenger();
            PassengerPage passengerPage = new PassengerPage(context);
            passengerPage.BindingContext = passenger;
            Navigation.PushAsync(passengerPage);
        }
        private void TicketsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Ticket selectedTicket = e.Item as Ticket;
            TicketPage ticketPage = new TicketPage(context);
            ticketPage.BindingContext = selectedTicket;
            Navigation.PushAsync(ticketPage);
        }
        private void CreateTicket(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            TicketPage ticketPage = new TicketPage(context);
            ticketPage.BindingContext = ticket;
            Navigation.PushAsync(ticketPage);
        }
    }
}
