using Android.App;
using Android.OS;
using Android.Widget;

namespace GroceryList
{
	[Activity(Label = "Details")]			
	public class DetailsActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Details);

			//
			// Retrieve the position of the item we need to display.
			//
			int position = Intent.GetIntExtra("ItemPosition", -1);

			//
			// Use the position to lookup the grocery item.
			//
			var item = MainActivity.Items[position];

			//
			// Populate the UI with the values of the grocery item.
			//
			FindViewById<TextView>(Resource.Id.nameTextView ).Text = "Name: "  + item.Name;
			FindViewById<TextView>(Resource.Id.countTextView).Text = "Count: " + item.Count.ToString();
		}
	}
}