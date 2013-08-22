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

// Адаптер для отображения списка писем
namespace ContestApp
{
    public class answerListAdapter : BaseAdapter<Answer>
    {
        private readonly Activity _context;
        private readonly IList<Answer> _answer;

        public answerListAdapter(Activity context, IList<Answer> answer)
        {
            _context = context;
            _answer = answer;
        }


        public override long GetItemId(int position)
        {
            return _answer[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? _context.LayoutInflater.Inflate
                (Resource.Layout.answerListItem, null);
            view.FindViewById<TextView>(Resource.Id.text).Text = _answer[position].text;
            return view;
        }

        public override int Count
        {
            get { return _answer == null ? 0 : _answer.Count; }
        }

        public override Answer this[int position]
        {
            get { return _answer[position]; }
        }
    }
}

