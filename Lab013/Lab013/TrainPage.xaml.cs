using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab013
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainPage : ContentPage
    {
        ApplicationContext context;
        public Train Train0 { get; set; }
        public TrainPage(ApplicationContext db)
        {
            InitializeComponent();
            context = db;
        }
        private void SaveTrain(object sender, EventArgs e)
        {
            Train0 = (Train)BindingContext;

            if (Train0.Id != 0)
            {
                context.Trains.Update(Train0);
                context.SaveChanges();
                this.Navigation.PopAsync();
            }
            else
            {
                context.Trains.Add(Train0);
                context.SaveChanges();
                this.Navigation.PopAsync();
            }
        }
        private void DeleteTrain(object sender, EventArgs e)
        {
            Train0 = (Train)BindingContext;
            if (Train0 != null)
            {
                context.Trains.Remove(Train0);
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