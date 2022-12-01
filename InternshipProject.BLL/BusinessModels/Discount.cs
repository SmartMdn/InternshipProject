namespace InternshipProject.BLL.BusinessModels;

public class Discount
{
    public Discount(decimal val)
    {
        Value = val;
    }

    private decimal Value { get; }

    public decimal GetDiscountedPrice(decimal sum)
    {
        if (DateTime.Now.Day == 1) return sum - sum * Value;

        return sum;
    }
}