namespace XFAES
{
    public interface ICreditCardCryptor
    {
        CreditCard AESEncryption(CreditCard card);
        CreditCard AESDecryption(CreditCard card);
    }
}