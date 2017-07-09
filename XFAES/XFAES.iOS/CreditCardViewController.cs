using Card.IO;
using MonoTouch.Dialog;
using System;
using UIKit;

namespace XFAES.iOS
{
    public class CreditCardViewController : DialogViewController, ICardIOPaymentViewControllerDelegate
    {
        public CreditCardViewController() : base(UITableViewStyle.Plain, new RootElement("card.io"), false)
		{
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            elemCardNumber = new StyledStringElement("xxxx xxxx xxxx xxxx");

            Root = new RootElement("card.io") {
                new Section {
                    elemCardNumber,
                    new StyledStringElement("Credit Card", () => {
                        paymentViewController = new CardIOPaymentViewController (this);

                        NavigationController.PresentViewController(paymentViewController, true, null);
                    }) { Accessory = UITableViewCellAccessory.DisclosureIndicator }
                }
            };
        }
        CardIOPaymentViewController paymentViewController;

        StyledStringElement elemCardNumber;
        public void UserDidCancelPaymentViewController(CardIOPaymentViewController paymentViewController)
        {
            paymentViewController.DismissViewController(true, null);
        }

        public void UserDidProvideCreditCardInfo(CreditCardInfo cardInfo, CardIOPaymentViewController paymentViewController)
        {
            if (cardInfo == null)
            {
                elemCardNumber.Caption = "xxxx xxxx xxxx xxxx";
                Console.WriteLine("Cancelled");
            }
            else
            {
                elemCardNumber.Caption = cardInfo.CardNumber;
            }

            ReloadData();

            paymentViewController.DismissViewController(true, null);
        }
    }
}