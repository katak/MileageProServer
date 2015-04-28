using System;
using MileagePro.SL.Contracts;

namespace MileagePro.ApiModels
{
	public class DataPoint
	{
		public DataPoint() { }
		
		public DataPoint(MileageDataPoint contract)
		{
			if (contract == null) throw new ArgumentNullException("contract");

			Date = contract.Date;
			OdometerReading = contract.OdometerReading;
			GallonsPurchased = contract.GallonsPurchased;
			TotalCost = contract.TotalCost;
			DistanceSinceLastFill = contract.DistanceSinceLastFill;
			PricePerGallon = contract.PricePerGallon;
		}

		public DateTime Date { get; set; }
		public int OdometerReading { get; set; }
		public float GallonsPurchased { get; set; }
		public float TotalCost { get; set; }
		public int DistanceSinceLastFill { get; set; }
		public float PricePerGallon { get; set; }
	}
}