using System.Collections.Generic;

namespace MileagePro.Models
{
	public class DataPointListModel : LayoutModel
	{
		public DataPointListModel()
		{
			DataPoints = new List<DataPointModel>();
		}

		public DataPointListModel(List<DataPointModel> dataPoints)
		{
			DataPoints = dataPoints;
		}

		public List<DataPointModel> DataPoints { get; private set; }
	}
}