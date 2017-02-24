using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views;
using System;
using Android.Content;

namespace AndroidListView_CustomerAdapter
{
    [Activity(Label = "AndroidListView_CustomerAdapter", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<string> mItems;
        private ListView mlistView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            mlistView = FindViewById<ListView>(Resource.Id.listView1);

            mItems = new List<string>();
            mItems.Add("Name1");
            mItems.Add("Name2");
            mItems.Add("Name3");

            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

            string indexerTest = adapter[1];
            mlistView.Adapter = adapter;

        }
    }

    class MyListViewAdapter : BaseAdapter<string>
    {
        private List<string> mItems;
        private Context mContext;

        public MyListViewAdapter(Context context, List<string> items)
        {
            mItems = items;
            mContext = context;
        }
        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView textName = row.FindViewById<TextView>(Resource.Id.textName);
            textName.Text = mItems[position];

            return row;
        }
    }
}

