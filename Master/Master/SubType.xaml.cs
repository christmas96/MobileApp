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
	public partial class SubType : ContentPage
	{
        public class GetSubType
        {
            public int Id { get; set; }
            public int id_sub_cat { get; set; }
            public string name { get; set; }
        }

        public SubType (int ID)
		{
			InitializeComponent ();
            LoadData(ID);
            ListView1.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (((ListView)sender).SelectedItem == null) return;
                var foo = e.SelectedItem as GetSubType;
                Navigation.PushAsync(new Gods(foo.Id));
                ((ListView)sender).SelectedItem = null;
            };
        }

        public async void LoadData(int Id)
        {
            try
            {
                var content = "";
                HttpClient client = new HttpClient();
                var RestURL = string.Format("http://appformob.azurewebsites.net/api/SubType");
                client.BaseAddress = new Uri(RestURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(RestURL);
                content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<GetSubType>>(content);
                List<GetSubType> item = new List<GetSubType>();
                foreach (GetSubType g in Items)
                {
                    if (Id == g.id_sub_cat)
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