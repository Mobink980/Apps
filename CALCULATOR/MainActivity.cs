using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace CALCULATOR
{
    [Activity(Label = "CALCULATOR", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button num1, num2, num3, num4, num5, num6, num7, num8, num9, num0, point, plus, minus, equal, divide, multi, clear;
        private TextView txtview;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            num0 = (Button)FindViewById(Resource.Id.btn0);
            num1 = (Button)FindViewById(Resource.Id.btn1);
            num2 = (Button)FindViewById(Resource.Id.btn2);
            num3 = (Button)FindViewById(Resource.Id.btn3);
            num4 = (Button)FindViewById(Resource.Id.btn4);
            num5 = (Button)FindViewById(Resource.Id.btn5);
            num6 = (Button)FindViewById(Resource.Id.btn6);
            num7 = (Button)FindViewById(Resource.Id.btn7);
            num8 = (Button)FindViewById(Resource.Id.btn8);
            num9 = (Button)FindViewById(Resource.Id.btn9);
            point = (Button)FindViewById(Resource.Id.btnpoint);
            plus = (Button)FindViewById(Resource.Id.btnplus);
            minus = (Button)FindViewById(Resource.Id.btnminus);
            multi = (Button)FindViewById(Resource.Id.btnmult);
            divide = (Button)FindViewById(Resource.Id.btndivide);
            equal = (Button)FindViewById(Resource.Id.btnequal);
            clear = (Button)FindViewById(Resource.Id.btnclear);
            txtview = (TextView)FindViewById(Resource.Id.textnum);


            num0.Click += Num_Click;
            num1.Click += Num_Click;
            num2.Click += Num_Click;
            num3.Click += Num_Click;
            num4.Click += Num_Click;
            num5.Click += Num_Click;
            num6.Click += Num_Click;
            num7.Click += Num_Click;
            num8.Click += Num_Click;
            num9.Click += Num_Click;
            point.Click += Num_Click;

            plus.Click += operator_Click;
            minus.Click += operator_Click;
            multi.Click += operator_Click;
            divide.Click += operator_Click;

            equal.Click += Equal_Click;

            clear.Click += Clear_Click;

        }

        private void Clear_Click(object sender, System.EventArgs e)
        {
            txtview.Text = "";
        }

        private void Equal_Click(object sender, System.EventArgs e)
        {
            if (op == "+")
            {
                txtview.Text = (numFirst + double.Parse(txtview.Text)).ToString();
            } 
            else if (op == "-")
            {
                txtview.Text = (numFirst - double.Parse(txtview.Text)).ToString();
            }
            else if (op == "x")
            {
                txtview.Text = (numFirst * double.Parse(txtview.Text)).ToString();
            }
            else if (op == "÷")
            {
                txtview.Text = (numFirst / double.Parse(txtview.Text)).ToString();
            }
        }

        private void operator_Click(object sender, System.EventArgs e)
        {
            numFirst = double.Parse(txtview.Text); //Save the entered text in numfirst variable
            txtview.Text = ""; //empty the txtview
            op = ((Button)sender).Text; //save the text of the operator in the string op
        }

        string op; //saves the operator
        double numFirst; //saves the first entered number

        private void Num_Click(object sender, System.EventArgs e)
        {
            // Append the text of the sender button to the text of the txtview
            if (((Button)sender).Text == ".")
            {
                if (!txtview.Text.Contains('.')){
                    txtview.Text += "."; //add point only if the text doesn't contain it before
                }
                else
                {
                    txtview.Text += ""; //do nothing
                }
            }
            else
            {
                txtview.Text += ((Button)sender).Text;
            }
            
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}