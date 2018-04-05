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
	public partial class Categories : ContentPage
	{     
        public class GetCategories
        {
            public int Id { get; set; }
            public string category_name { get; set; }
        }
      
		public Categories ()
		{
			InitializeComponent ();
            LoadData();
            ListView1.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
             {
                 if (((ListView)sender).SelectedItem == null) return;
                 var foo = e.SelectedItem as GetCategories;
                 Navigation.PushAsync(new SubCategories(foo.Id));
                 ((ListView)sender).SelectedItem = null;                 
             };
        }
        

        public async void LoadData()
        {
            try
            {
                HttpClient client = new HttpClient();
                var RestURL = "http://appformob.azurewebsites.net/api/Categories";
                client.BaseAddress = new Uri(RestURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(RestURL);
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<GetCategories>>(content);
                ListView1.ItemsSource = Items;
            }
            catch (HttpRequestException e)
            {
               await DisplayAlert("Error",e.ToString(),"Ok");
            }
            catch(JsonSerializationException e)
            {
                await DisplayAlert("Error", e.ToString(), "Ok");
            }
        }
	}
}