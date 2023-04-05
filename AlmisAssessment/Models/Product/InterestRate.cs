namespace AlmisAssessment.Models.Product
{
    public class InterestRate
    {
        public decimal Amount { get; set; }

        public InterestRate(decimal amount)
        {
            Amount = amount;
        }
    }
}