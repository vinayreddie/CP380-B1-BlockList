namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {
        public string User { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public int Amount { get; set; }
        public string Item { get; set; }
        // TODO
        public Payload(string user, TransactionTypes TransactionTypes, int amount, string item)
        {
            User = user;
            TransactionType = TransactionTypes;
            Amount = amount;
            Item = item;
        }
    }
}
