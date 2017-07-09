using System;
using UIKit;
using Xamarin.Forms;
using XFAES.iOS;

[assembly: Dependency(
    typeof(CreditCardScannerDependency))]
namespace XFAES.iOS
{
    public class CreditCardScannerDependency : ICreditCardScanner
    {
        public void Scan()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            //window = new UIWindow(UIScreen.MainScreen.Bounds);
            window.RootViewController = new CreditCardViewController();
            window.MakeKeyAndVisible();
        }
    }
}