namespace LogicLayer.Models
{
	public interface IDiscount
	{
		decimal CalculateDiscount(int amount, decimal price);
		string ToString();
	}
}
