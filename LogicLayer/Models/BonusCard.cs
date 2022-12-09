namespace LogicLayer.Models
{
	public class BonusCard
	{
		private int id;
		private int? amountOfPoints;
        public BonusCard(int id, int? amountOfPoints)
        {
            this.id = id;
            this.amountOfPoints = amountOfPoints;
        }

        public int ConvertPointsToEuros()
		{
			throw new System.NotImplementedException();
		}

		public int MaxEuros()
		{
			throw new System.NotImplementedException();
		}

		public void AddPointsFromEuros()
		{
			throw new System.NotImplementedException();
		}
		public int Id
		{
			get { return this.id; }
		}

		public int? AmountOfPoints
		{
			get { return this.amountOfPoints; }
			set { this.amountOfPoints = value; }
		}
	}
}
