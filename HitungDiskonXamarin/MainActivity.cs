using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace HitungDiskonXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // inisialisasi komponen
            EditText txtJmlBarang = FindViewById<EditText>(Resource.Id.txtJmlBarang);
            EditText txtHargaSatuan = FindViewById<EditText>(Resource.Id.txtHargaSatuan);
            EditText txtDiskon = FindViewById<EditText>(Resource.Id.txtDiskon);

            TextView lblJmlBarang = FindViewById<TextView>(Resource.Id.lblJmlBarang);
            TextView lblHargaSatuan = FindViewById<TextView>(Resource.Id.lblHargaSatuan);
            TextView lblTotalSebelumDiskon = FindViewById<TextView>(Resource.Id.lblTotalSebelumDiskon);
            TextView lblTotalSetelahDiskon = FindViewById<TextView>(Resource.Id.lblTotalSetelahDiskon);
            TextView lblDiskon = FindViewById<TextView>(Resource.Id.lblDiskon);

            Button btnHitung = FindViewById<Button>(Resource.Id.btnHitung);

            btnHitung.Click += delegate
            {
                try
                {
                    double jumlahBarang = double.Parse(txtJmlBarang.Text);
                    double hargaSatuan = double.Parse(txtHargaSatuan.Text);
                    double diskon = double.Parse(txtDiskon.Text);

                    double totalBeliSebelumDiskon;
                    double totalBeliSetelahDiskon;

                    if (jumlahBarang <= 0 || hargaSatuan <= 0 || hargaSatuan <= 0)
                    {
                        Toast.MakeText(Application.Context, "Cek Kembali ada penginputan salah !!", ToastLength.Long).Show();
                        return;
                    }

                    totalBeliSebelumDiskon = jumlahBarang * hargaSatuan;
                    totalBeliSetelahDiskon = totalBeliSebelumDiskon -((jumlahBarang * hargaSatuan) * (diskon / 100));

                    // hasil
                    lblJmlBarang.Text = "Jumlah Barang : " + jumlahBarang.ToString();
                    lblHargaSatuan.Text = "Harga Satuan : " + hargaSatuan.ToString();
                    lblDiskon.Text = "Diskon : " + diskon.ToString();
                    lblTotalSebelumDiskon.Text = totalBeliSebelumDiskon.ToString();
                    lblTotalSetelahDiskon.Text = totalBeliSetelahDiskon.ToString();
                }
                catch (System.Exception)
                {
                    throw;
                }
                

            };
        }
    }
}