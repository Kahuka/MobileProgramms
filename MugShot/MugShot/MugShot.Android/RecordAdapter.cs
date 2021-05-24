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
using FFImageLoading;
using MugShot.Model;

namespace MugShot.Droid
{
    class RecordAdapter : BaseAdapter<Record>
    {
        List<Record> _items;
        Activity _context;

        public RecordAdapter(Activity context, List<Record> items) : base()
        {
            this._context = context;
            this._items = items;
        }

        public override Record this[int position]
        {
            get { return _items[position]; }
        }
        public override int Count
        {
            get { return _items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;

        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            var mugshot = item.mugshot;
            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.record_layout, null);

            var charges = "";
 

            foreach(string charge in item.charges)
            {
                charges += ", " + charge;
            };



            view.FindViewById<TextView>(Resource.Id.countyState).Text = "State: " + item.county_state;
            view.FindViewById<TextView>(Resource.Id.name).Text = "Name: " + item.name;
            view.FindViewById<TextView>(Resource.Id.charges).Text = "Charges: " + charges;
            view.FindViewById<TextView>(Resource.Id.id).Text = "ID: " + item.id;
            view.FindViewById<TextView>(Resource.Id.source).Text = "Source: " + item.source;
            view.FindViewById<TextView>(Resource.Id.bookDateForm).Text = "Book date: " + item.book_date_formatted;
            view.FindViewById<TextView>(Resource.Id.moreInfo).Text = "More info: " + item.more_info_url;
            var imageView = view.FindViewById<ImageView>(Resource.Id.mugshot);

            ImageService.Instance.LoadUrl(mugshot).Into(imageView);
            return view;
        }
    }
}