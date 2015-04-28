using System;

namespace MileagePro.ApiModels
{
	public class DataPoint
	{
		public DateTime Date { get; set; }
		public int OdometerReading { get; set; }
		public float GallonsPurchased { get; set; }
		public float TotalCost { get; set; }
		public int DistanceSinceLastFill { get; set; }
		public float PricePerGallon { get; set; }
	}
}