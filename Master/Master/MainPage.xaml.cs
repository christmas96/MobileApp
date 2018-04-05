using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Master
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void ButtonMain_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MainPage())
            {
               BarBackgroundColor = Color.FromHex("#008000")
            };
            IsPresented = false;
        }

        private void ButtonSales_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Sales())
            {
                BarBackgroundColor = Color.FromHex("#008000")
            };
            IsPresented = false;
        }

        private void ButtonCategories_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Categories())
            {
                BarBackgroundColor = Color.FromHex("#008000")
            };
            IsPresented = false;
        }
    }
}
