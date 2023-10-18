namespace NewWPFBank.Classes
{
    public interface IAccount
    {
        int UserAccountOwner { get; set; }
        int AccountNumber { get; }
        double Balance { get; set; }
    }

}
