using System.Collections.Generic;
using MileagePro.SL.Contracts;

namespace MileagePro.SL.Interfaces
{
	public interface IDataPointService
	{
		/// <summary>
		/// Gets a data point by id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		MileageDataPoint GetDataPoint(int id);
		
		/// <summary>
		/// Gets all data points.
		/// </summary>
		/// <returns></returns>
		IEnumerable<MileageDataPoint> GetDataPoints();
		
		/// <summary>
		/// Creates a data point.
		/// </summary>
		/// <param name="dataPoint">The data point.</param>
		void CreateDataPoint(MileageDataPoint dataPoint);
	
		/// <summary>
		/// Edits the data point.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="dataPoint">The data point.</param>
		void EditDataPoint(int id, MileageDataPoint dataPoint);

		/// <summary>
		/// Deletes the data point.
		/// </summary>
		/// <param name="id">The identifier.</param>
		void DeleteDataPoint(int id);
	}
}