using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Webkit;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //defining things before OnCreate makes it global
        private Button btn1;
        private Button btn2;
        private SeekBar seek;
        private TextView text_seekbar;
        private WebView web;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            // This two variables are not global; 
            // thus we can create functionality on them by a function out of OnCreate
            var edit = (EditText)FindViewById(Resource.Id.editText1);
            var text = (TextView)FindViewById(Resource.Id.textView1);
            var edit_title = (EditText)FindViewById(Resource.Id.editText2);
            text_seekbar = (TextView)FindViewById(Resource.Id.textView2);


            // putting the text of edit which is a EditText into text which is a TextView
            edit.TextChanged += delegate
            {
                text.Text = edit.Text;
            };

            // putting the text of edit which is a EditText into the Title
            edit_title.TextChanged += delegate
            {
                this.Title = edit_title.Text;
            };


            // connect the defined button to the view button with id 'button1'
            btn1 = (Button)FindViewById(Resource.Id.button1); 
            // defining functionality for the click of btn1
            btn1.Click += Btn1_Click;


            // connect the defined button to the view button with id 'button2'
            btn2 = (Button)FindViewById(Resource.Id.button2);
            // defining functionality for the click of btn2
            btn2.Click += Btn2_Click;

            //  connect with the item with id 'seekBar1'
            seek = (SeekBar)FindViewById(Resource.Id.seekBar1);
            seek.ProgressChanged += Seek_ProgressChanged; //call the function on ProgressChanged property

            //connect to the WebView with id 'webView1'
            web = (WebView)FindViewById(Resource.Id.webView1);

            // connect to a web page over the internet
            web.SetWebViewClient(new WebViewClient()); //set the WebViewClient to receive request
            web.Settings.JavaScriptEnabled = true; //enable the java script prperty whether is enabled or not
            web.LoadUrl("https://www.google.com");

            // connect to a web page in the Assets directory of the project
            // web.LoadUrl("file:///android_asset/index.html"); 


        }

        private void Seek_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            text_seekbar.Text = string.Format("The value of seekbar is {0}", e.Progress); 
        }

        //function for the click of Btn2
        private void Btn2_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "GOLDEN BUTTON", ToastLength.Long).Show();

            // define and connect to the ImageView with id 'imageView1'
            var image = (ImageView)FindViewById(Resource.Id.imageView1);
            image.SetImageResource(Resource.Drawable.p13); //put the image in by clicking the btn2
        }

        //function for the click of Btn1 
        private void Btn1_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "SILVER BUTTON", ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}