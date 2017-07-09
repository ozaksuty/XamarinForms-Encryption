using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Card.IO;

[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.Camera)]
[assembly: UsesPermission(Android.Manifest.Permission.Vibrate)]

[assembly: UsesFeature("android.hardware.camera", Required = false)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]
[assembly: UsesFeature("android.hardware.camera.flash", Required = false)]

namespace XFAES.Droid
{
    [Activity(Label = "CreditCardScannerActivity")]
    public class CreditCardScannerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var intent = new Intent(this, typeof(CardIOActivity));
            intent.PutExtra(CardIOActivity.ExtraRequireExpiry, true);
            intent.PutExtra(CardIOActivity.ExtraRequireCvv, true);
            intent.PutExtra(CardIOActivity.ExtraRequirePostalCode, false);
            intent.PutExtra(CardIOActivity.ExtraUseCardioLogo, true);

            StartActivityForResult(intent, 101);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (data != null)
            {
                var card = data.GetParcelableExtra(CardIOActivity.ExtraScanResult)
                    .JavaCast<Card.IO.CreditCard>();

                CreditCard scannedCard = new CreditCard
                {
                    Number = card.CardNumber,
                    Name = card.CardholderName,
                    Cvv = card.Cvv,
                    Month = card.ExpiryMonth.ToString(),
                    Year = card.ExpiryYear.ToString()
                };
                Xamarin.Forms.MessagingCenter.Send<App, CreditCard>(
                    (App)Xamarin.Forms.Application.Current, 
                    "card", scannedCard);
                Finish();
            }
        }
    }
}