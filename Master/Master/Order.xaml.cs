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
	public partial class Order : ContentPage
	{
		public Order (int count, int Id, int sub_type_id, string title, string description, int amount, double price)
		{
			InitializeComponent ();

            SendOrder(count, Id, sub_type_id, title, description, amount, price);
		}

        private void SendOrder(int count, int Id, int sub_type_id, string title, string description, int amount, double price)
        {

        }
	}
}