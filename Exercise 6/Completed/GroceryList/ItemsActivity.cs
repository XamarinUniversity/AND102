using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GroceryList
{
	[Activity(Label = "Items")]			
	public class ItemsActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Items);

			var lv = FindViewById<ListView>(Resource.Id.listView);

			//
			// The ListView displays the collection of grocery items.
			// The Adapter prepares the rows for the ListView to display.
			// We are using the Android library components ArrayAdapter and SimpleListItem1 to display our items.
			//  - SimpleListItem1 is a layout file containing a single TextView
			//  - Text1 is the Id of the TextView inside the SimpleListItem1 layout file.
			//  - The ArrayAdapter instantiates the SimpleListItem1 layout file for each row. 
			//  - It uses the Text1 Id to lookup the TextView inside the row.
			//  - Once it finds the TextView, it set the Text property to the result of calling ToString on our grocery item.
			//
			lv.Adapter = new ArrayAdapter<Item>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, MainActivity.Items);	

			//
			// ListView will notify us when the user touches one of the list items
			//
			lv.ItemClick += OnItemClick;
		}

		void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var intent = new Intent(this, typeof(DetailsActivity));

			intent.PutExtra("ItemPosition", e.Position); // e.Position is the position in the list of the item the use touched

			StartActivity(intent);
		}
	}
}