using System;

namespace MileagePro.Models
{
	public class DataPointModel : LayoutModel
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int OdometerReading { get; set; }
		public float GallonsPurchased { get; set; }
		public float TotalCost { get; set; }
		public int DistanceSinceLastFill { get; set; }
		public float PricePerGallon { get; set; }
	}
}