using System.Linq;
using MileagePro.SL.Contracts;
using Raven.Client.Indexes;

namespace MileagePro.SL.Indexes
{
	public class DataPointByIdIndex : AbstractIndexCreationTask<MileageDataPoint>
	{
		public DataPointByIdIndex()
		{
			Map = dataPoints => from dataPoint in dataPoints
								select new
								{
									dataPoint.Id
								};
		}
	}
}