namespace NewWPFBank.Classes
{
    public interface IAccount
    {
        int UserAccountOwner { get; set; }
        string AccountNumber { get; }
        double Balance { get; set; }
    }

}
