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
    public partial class TicketPage : ContentPage
    {
        ApplicationContext context;
        public Ticket Ticket0 { get; set; }
        public TicketPage(ApplicationContext db)
        {
            InitializeComponent();
            context = db;
        }
        private void SaveTicket(object sender, EventArgs e)
        {
            Ticket0 = (Ticket)BindingContext;

            if (Ticket0.Id != 0)
            {
                context.Tickets.Update(Ticket0);
                context.SaveChanges();
                this.Navigation.PopAsync();
            }
            else
            {
                context.Tickets.Add(Ticket0);
                context.SaveChanges();
                this.Navigation.PopAsync();
            }
        }
        private void DeleteTicket(object sender, EventArgs e)
        {
            Ticket0 = (Ticket)BindingContext;
            if (Ticket0 != null)
            {
                context.Tickets.Remove(Ticket0);
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