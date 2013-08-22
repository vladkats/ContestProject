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
    [Activity(Label = "Career Assistant", MainLauncher = true, Icon = "@drawable/logo")]
    public class Activity1 : Activity
    {

        private ListView _answerList;
        private IList<Answer> _answer;
        EditText name, salary, phone, email, jobPosition;

        Spinner gender;
        Button submit;
        ArrayAdapter<String> aas;
        string text;
        string index;
        Answer ans;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.ActionBar);
            if (Intent.GetStringExtra("id") == null)
            {
                SetContentView(Resource.Layout.ActivityLayout1);
                name = FindViewById<EditText>(Resource.Id.name);
                salary = FindViewById<EditText>(Resource.Id.salary);
                phone = FindViewById<EditText>(Resource.Id.phone);
                email = FindViewById<EditText>(Resource.Id.email);
                gender = FindViewById<Spinner>(Resource.Id.gender);
                jobPosition = FindViewById<EditText>(Resource.Id.jobPosition);
                aas = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);
                gender.Adapter = aas;
                aas.Add(String.Empty);
                aas.Add("Мужской");
                aas.Add("Женский");
                gender.ItemSelected += sp_ItemSelected;
                submit = FindViewById<Button>(Resource.Id.submit);
                submit.Click += button_Clicked;
            }

            else
            {

                SetContentView(Resource.Layout.activityLayoutDialog);
                dialogWindow();

                index = Intent.GetStringExtra("id");
                int id = 0;


                id = int.Parse(index);
                ans = new Answer();
                ans.id = id;
                ans.text = Intent.GetStringExtra("answer");

                _answerList = FindViewById<ListView>(Resource.Id.answers);
                _answerList.Visibility = ViewStates.Visible;
                _answer = new List<Answer>();
                _answer.Add(ans);
                _answerList.Adapter = new answerListAdapter(this, _answer);

                EditText backLetter = FindViewById<EditText>(Resource.Id.backLetter);
                Button sendBack = FindViewById<Button>(Resource.Id.btn_sendBack);
                int count = 1;
                sendBack.Click += delegate
                {
                    Answer answer = new Answer();
                    answer.id = count;
                    answer.text = backLetter.Text;
                    _answer.Add(answer);
                    _answerList.Adapter = new answerListAdapter(this, _answer);
                    backLetter.Text = String.Empty;
                    count++;
                };
            }
        }


        private void button_Clicked(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Activity2));
            Bundle extras = new Bundle();
            extras.PutString("Name", name.Text);
            extras.PutString("Salary", salary.Text);
            extras.PutString("JobPosition", jobPosition.Text);
            extras.PutString("Phone", phone.Text);
            extras.PutString("Email", email.Text);
            extras.PutString("Gender", text);
            DatePicker date = FindViewById<DatePicker>(Resource.Id.date);
            extras.PutString("Date", (date.DayOfMonth + 1).ToString() + "." + date.Month.ToString() + "." + date.Year.ToString());
            intent.PutExtras(extras);
            StartActivity(intent);
        }

        private void sp_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            text = Convert.ToString(aas.GetItem(e.Position));
        }

        private void dialogWindow()
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alertDialog = builder.Create();
            alertDialog.SetMessage("Вам пришло письмо от работодателя");
            alertDialog.SetButton("Просмотреть диалог", (sender, e) =>
            {
                alertDialog.Dismiss();
            });
            alertDialog.Show();

        }

    }
}


