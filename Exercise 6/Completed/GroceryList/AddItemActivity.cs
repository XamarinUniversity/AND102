using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace GroceryList
{
	[Activity(Label = "Add Item")]			
	public class AddItemActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.AddItem);

			FindViewById<Button>(Resource.Id.saveButton  ).Click += OnSaveClick;
			FindViewById<Button>(Resource.Id.cancelButton).Click += OnCancelClick;
		}

		void OnSaveClick(object sender, EventArgs e)
		{
			//
			// Retrieve the values the user entered into the UI
			//
			string name  = FindViewById<EditText>(Resource.Id.nameInput).Text;
			int    count = int.Parse(FindViewById<EditText>(Resource.Id.countInput).Text);

			var intent = new Intent();

			//
			// Load the new data into an Intent for transport back to the Activity that started this one.
			//
			intent.PutExtra("ItemName",  name );
			intent.PutExtra("ItemCount", count);

			//
			// Send the result code and data back (this does not end the current Activity)
			//
			SetResult(Result.Ok, intent);

			//
			// End the current Activity.
			//
			Finish();
		}

		void OnCancelClick(object sender, EventArgs e)
		{
			//
			// End the current Activity.
			// The Result Code will default to Result.Canceled.
			//
			Finish();
		}
	}
}

