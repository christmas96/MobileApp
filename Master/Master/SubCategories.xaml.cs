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
	public partial class SubCategories : ContentPage
	{
        public class GetSubCategories
        {
            public int Id { get; set; }
            public int cat_id { get; set; }
            public string gods_name { get; set; }
        }
        
        public SubCategories (int ID)
		{
			InitializeComponent ();
            LoadData(ID);
            ListView1.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (((ListView)sender).SelectedItem == null) return;
                var foo = e.SelectedItem as GetSubCategories;
                Navigation.PushAsync(new SubType(foo.Id));
                ((ListView)sender).SelectedItem = null;
            };
        }
        public async void LoadData(int Id)
        {            
            try
            {
                var content = "";
                HttpClient client = new HttpClient();
                var RestURL = string.Format("http://appformob.azurewebsites.net/api/SubCategories");
                client.BaseAddress = new Uri(RestURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(RestURL);
                content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<GetSubCategories>>(content);
                List<GetSubCategories> item = new List<GetSubCategories>();
                foreach(GetSubCategories g in Items)
                {
                    if (Id == g.cat_id)
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