using System;
using System.Collections.Generic;
using System.Linq;
using MileagePro.SL.Contracts;
using MileagePro.SL.Indexes;
using MileagePro.SL.Interfaces;
using Raven.Client;

namespace MileagePro.SL.Services
{
	public class DataPointService : IDataPointService
	{
		private readonly IDocumentStore store;

		public DataPointService(IDocumentStore documentStore)
		{
			store = documentStore;
		}

		/// <summary>
		/// Gets a data point by id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public MileageDataPoint GetDataPoint(int id)
		{
			using (var session = store.OpenSession())
			{
				var dataPoint = session.Query<MileageDataPoint, DataPointByIdIndex>().FirstOrDefault(x => x.Id == id);

				return dataPoint;
			}
		}

		/// <summary>
		/// Gets all data points.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<MileageDataPoint> GetDataPoints()
		{
			List<MileageDataPoint> dataPoints;

			using (var session = store.OpenSession())
			{
				dataPoints = session.Query<MileageDataPoint>().ToList();
			}

			return dataPoints;
		}

		/// <summary>
		/// Creates a data point.
		/// </summary>
		/// <param name="dataPoint">The data point.</param>
		public void CreateDataPoint(MileageDataPoint dataPoint)
		{
			using (var session = store.OpenSession())
			{
				dataPoint.Date = DateTime.Now;

				// dataPoint.OdometerReading = previous datapoint's odometer reading - current reading 
				// (need to check if there is a previous datapoint)
				dataPoint.DistanceSinceLastFill = 500;

				dataPoint.PricePerGallon = dataPoint.TotalCost / dataPoint.GallonsPurchased;

				session.Store(dataPoint);
				session.SaveChanges();
			}
		}

		/// <summary>
		/// Edits the data point.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="dataPoint">The data point.</param>
		public void EditDataPoint(int id, MileageDataPoint dataPoint)
		{
			using (var session = store.OpenSession())
			{
				var index = string.Format("MileageDataPoints/{0}", id);
				var loadedDataPoint = session.Load<MileageDataPoint>(index);

				loadedDataPoint.OdometerReading = dataPoint.OdometerReading;
				loadedDataPoint.TotalCost = dataPoint.TotalCost;
				loadedDataPoint.GallonsPurchased = dataPoint.GallonsPurchased;
				loadedDataPoint.PricePerGallon = dataPoint.PricePerGallon;
				loadedDataPoint.DistanceSinceLastFill = dataPoint.DistanceSinceLastFill;
				loadedDataPoint.Date = dataPoint.Date;

				session.SaveChanges();
			}
		}

		/// <summary>
		/// Deletes the data point.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public void DeleteDataPoint(int id)
		{
			using (var session = store.OpenSession())
			{
				var dataPoint = session.Query<MileageDataPoint, DataPointByIdIndex>().FirstOrDefault(x => x.Id == id);

				if (dataPoint == null) return;
				session.Delete(dataPoint);
				session.SaveChanges();
			}
		}
	}
}
