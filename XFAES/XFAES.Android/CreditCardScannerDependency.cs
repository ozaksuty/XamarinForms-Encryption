using Android.Content;
using System;
using Xamarin.Forms;
using XFAES.Droid;

[assembly: Dependency(
    typeof(CreditCardScannerDependency))]
namespace XFAES.Droid
{
    public class CreditCardScannerDependency : ICreditCardScanner
    {
        public void Scan()
        {
            Intent intent = new Intent(Forms.Context,
                typeof(CreditCardScannerActivity));
            Forms.Context.StartActivity(intent);
        }
    }
}