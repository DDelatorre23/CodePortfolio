
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TypeChecker
{
	[Activity (Label = "TypeCheck")]			
	public class TypeCheck : Activity
	{
		List<Type> typeList;
		double effectiveness = 0.0;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.CheckType);
			LoadTypes ();
			string atk = Intent.GetStringExtra ("Attacker").ToLower() ?? "Data not available";
			string def1 = Intent.GetStringExtra ("Defender").ToLower() ?? "Data not available";
			var attacker = typeList.Find(t => t.TypeName == atk);

			var text = FindViewById<TextView> (Resource.Id.textView2);
			var img = FindViewById<ImageView> (Resource.Id.textView1);
			string message = CheckTypeChart (attacker, def1);
			text.Text = message;
			if (effectiveness == 0.0) {
				img.SetImageResource (Resource.Mipmap.sadpokemon);
			}else{
				if (effectiveness == 0.5) {
					img.SetImageResource (Resource.Mipmap.MadPokemon);
				}else {
					if (effectiveness == 1.0) {
						img.SetImageResource (Resource.Mipmap.charmanderhappy);
					} else { 
						img.SetImageResource (Resource.Mipmap.happyPichachu);
					}

				}
			}

			img.Click += delegate {
				var main = new Intent(this, typeof(MainActivity));
				StartActivity(main);
			};
		}
	

		public void LoadTypes ()
		{
			//typeList = new List<Type> ();
			XMLFileReader typeReader = new XMLFileReader (Assets.Open (@"Typechart.xml"));
			//			
			typeList = typeReader.Types;
		}

		public string CheckTypeChart(Type attacker, string defender)
		{
			string msg = "";
			effectiveness = 1.0;
			if (attacker.Advantages.Contains (defender)) {
				msg = "It's Super Effective!";
				effectiveness = 2.0;
			} else {
				if (attacker.Disadvantage.Contains (defender)) {
					msg = "It's Not Very Effective!";
					effectiveness = 0.5;
				} else {
					if (attacker.NullEffect.Contains (defender)) {
						msg = "This Has No Effect!";
						effectiveness = 0.0;
						}else{
							msg = "Normal Effectiveness";
						}
					}
				}
			return msg;
		}


		protected override void OnNewIntent (Intent intent)
		{
			base.OnNewIntent (intent);
			Intent = intent;

		}
	}
}


