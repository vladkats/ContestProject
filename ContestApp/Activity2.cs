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

namespace ContestApp
{
	[Activity (Label = "Carreer Assistant", Icon="@drawable/logo")]			
	public class Activity2 : Activity
	{

		TextView name, salary, phone, email, jobPosition, date, gender;
		EditText letter;
		Button response;
		int count;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.ActivityLayout2);

			name = FindViewById<TextView> (Resource.Id.name);
			name.Text = Intent.GetStringExtra ("Name");
			date = FindViewById<TextView> (Resource.Id.date);
			date.Text = Intent.GetStringExtra ("Date");
			gender = FindViewById<TextView> (Resource.Id.gender);
			gender.Text = Intent.GetStringExtra ("Gender");
			jobPosition = FindViewById<TextView> (Resource.Id.jobPosition);
			jobPosition.Text = Intent.GetStringExtra ("JobPosition");
			salary = FindViewById<TextView> (Resource.Id.salary);
			salary.Text = Intent.GetStringExtra ("Salary");
			phone = FindViewById<TextView> (Resource.Id.phone);
			phone.Text = Intent.GetStringExtra ("Phone");
			email = FindViewById<TextView> (Resource.Id.email);
			email.Text = Intent.GetStringExtra ("Email");

			letter = FindViewById<EditText> (Resource.Id.letter);

			response = FindViewById<Button> (Resource.Id.btn_send);

			response.Click += response_Clicked;

			// Create your application here
		}

		private void response_Clicked (object sender, EventArgs e)
		{   
			count = 0;
			Intent intent = new Intent (this, typeof (Activity1));
			Bundle extras = new Bundle ();

			extras.PutString ("answer", letter.Text);
			extras.PutString("id", count.ToString());
			intent.PutExtras (extras);
			count++;
			StartActivity (intent);
		}
	}
}

