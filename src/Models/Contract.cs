namespace src.Models;

public class Contract
{
    public Contract()
    {
        this.CreatedAt = DateTime.Now;
        this.Value = 0;
        this.TokenId = "000000";
        this.Paid = false;
    }

    public Contract(string TokenId, double Value)
    {
        this.CreatedAt = DateTime.Now;
        this.TokenId = TokenId;
        this.Value = Value;
        this.Paid = false;
    }

    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string TokenId { get; set; }
    public double Value { get; set; }
    public bool Paid { get; set; }
    public int PersonId { get; set; }
}