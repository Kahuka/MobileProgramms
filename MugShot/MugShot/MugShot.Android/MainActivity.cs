using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MugShot.Droid
{
    [Activity(Label = "MugShot", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            LoadApplication(new App());

            var SearchBtn = FindViewById<Button>(Resource.Id.searchButton);
            var LastNameText = FindViewById<EditText>(Resource.Id.lastNameText);
            var FirstNameText = FindViewById<EditText>(Resource.Id.firstNameText);
            var RecordView = FindViewById<ListView>(Resource.Id.recrodView);
            SearchBtn.Click += async delegate
            {
                string lastname = LastNameText.Text;
                string firstname = FirstNameText.Text;
                string queryString = "https://www.JailBase.com/api/1/search/?source_id=az-mcso&last_name=" + lastname + "&first_name=" + firstname;
                var data = await DataService.GetRecord(queryString);
                RecordView.Adapter = new RecordAdapter(this, data.records);

            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}