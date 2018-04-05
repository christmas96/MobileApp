using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GodView : ContentPage
	{
        public class God
        {
            public int Id { get; set; }
            public int sub_type_id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string image { get; set; }
            public int amount { get; set; }
            public double price { get; set; }

            public God(int Id, int sub_type_id, string title, string description, string image, int amount, double price)
            {
                this.Id = Id;
                this.sub_type_id = sub_type_id;
                this.title = title;
                this.description = description;
                this.image = image;
                this.amount = amount;
                this.price = price;
            }
        }
        public God gd;

        public GodView(int Id, int sub_type_id, string title, string description, string image, int amount, double price)
        {
            InitializeComponent();
            gd = new God(Id, sub_type_id, title, description, image, amount, price);
            gdImage.Source = gd.image;
            gdName.Text = gd.title;
            gdPrice.Text = gd.price.ToString();
            gdAmount.Text = gd.amount.ToString();
            gdDescription.Text = gd.description;

            for (int i = 1; i <= gd.amount; i++)
            {
                picker.Items.Add(i.ToString());
            }            
        }

        private void BuyButtonClicked()
        {
            DisplayAlert("Okay", "Hello", "Ok");
            //int count = Int32.Parse(picker.SelectedItem.ToString());
            //Navigation.PushAsync(new Order(count, gd.Id, gd.sub_type_id, gd.title, gd.description, gd.amount, gd.price));
        }
	}
}