namespace LogicLayer.Models
{
	public interface IDiscount
	{
		decimal CalculateDiscount(int Amount, decimal Price);
		string ToString();
	}
}
