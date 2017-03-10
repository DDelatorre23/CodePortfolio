using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;

namespace TypeChecker
{
	[Activity (Label = "TypeChecker", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			var atkSpinner = FindViewById<Spinner> (Resource.Id.atkSpinner);
			var defSpinner = FindViewById<Spinner> (Resource.Id.def1Spinner);
			var button = FindViewById<Button> (Resource.Id.myButton);

			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.type_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			atkSpinner.Adapter = adapter;
			defSpinner.Adapter = adapter;
			button.Click += delegate {
				var typeCheck = new Intent(this, typeof(TypeCheck));
				if((string)atkSpinner.SelectedItem != "Select a Type..." && 
					(string)defSpinner.SelectedItem != "Select a Type..."){
				typeCheck.PutExtra("Attacker", (string)atkSpinner.SelectedItem);
				typeCheck.PutExtra("Defender", (string)defSpinner.SelectedItem);
				StartActivity(typeCheck);
				}else{
					Toast t = Toast.MakeText(this, "Select both an attacker and defender type", ToastLength.Short);
					t.Show();
				}
			};

		}
	}
}


