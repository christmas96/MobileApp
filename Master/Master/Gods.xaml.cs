using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Gods : ContentPage
	{
        public class GetGoods
        {
            public int Id { get; set; }
            public int sub_type_id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string image { get; set; }
            public int amount { get; set; }
            public double price { get; set; }
        }

		public Gods (int ID)
		{
			InitializeComponent ();
            LoadData(ID);
            ListView1.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (((ListView)sender).SelectedItem == null) return;
                var foo = e.SelectedItem as GetGoods;
                OnItemSelect(foo.Id, foo.sub_type_id, foo.title, foo.description, foo.image, foo.amount, foo.price);
                ((ListView)sender).SelectedItem = null;
            };
        }

        public async void OnItemSelect(int Id, int sub_type_id, string title, string description, string image, int amount, double price)
        {
            await Navigation.PushAsync(new GodView(Id, sub_type_id, title, description, image, amount, price));
        }

        public async void LoadData(int Id)
        {
            try
            {               
                var content = "";
                HttpClient client = new HttpClient();
                var RestURL = string.Format("http://appformob.azurewebsites.net/api/Gods");
                client.BaseAddress = new Uri(RestURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(RestURL);
                content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<GetGoods>>(content);
                List<GetGoods> item = new List<GetGoods>();
                foreach (GetGoods g in Items)
                {
                    if (Id == g.sub_type_id)
                    {
                        item.Add(g);
                    }
                }
                ListView1.ItemsSource = item;
            }
            catch (HttpRequestException e)
            {
                await DisplayAlert("Error", e.ToString(), "Ok");
            }
            catch (JsonSerializationException e)
            {
                await DisplayAlert("Error", e.ToString(), "Ok");
            }
        }
    }
}