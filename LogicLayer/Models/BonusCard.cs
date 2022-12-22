namespace LogicLayer.Models
{
	public class BonusCard
	{
		private int id;
		private int amountOfPoints;
        public BonusCard(int id, int amountOfPoints)
        {
            this.id = id;
            this.amountOfPoints = amountOfPoints;
        }
		public int Id
		{
			get { return this.id; }
		}

		public int AmountOfPoints
		{
			get { return this.amountOfPoints; }
			set { this.amountOfPoints = value; }
		}
	}
}
