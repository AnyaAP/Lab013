using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab013
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassengerPage : ContentPage
    {
        ApplicationContext context;
        public Passenger Passenger0 { get; set; }
        public PassengerPage(ApplicationContext db)
        {
            InitializeComponent();
            context = db;
        }
        private void SavePassenger(object sender, EventArgs e)
        {
            Passenger0 = (Passenger)BindingContext;

            if (Passenger0.Id != 0)
            {
                context.Passengers.Update(Passenger0);
                context.SaveChanges();
                this.Navigation.PopAsync();
            }
            else
            {
                context.Passengers.Add(Passenger0);
                context.SaveChanges();
                this.Navigation.PopAsync();
            }
        }
        private void DeletePassenger(object sender, EventArgs e)
        {
            Passenger0 = (Passenger)BindingContext;
            if (Passenger0 != null)
            {
                context.Passengers.Remove(Passenger0);
                context.SaveChanges();
            }
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}