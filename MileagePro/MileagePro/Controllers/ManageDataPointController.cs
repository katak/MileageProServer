using System.Linq;
using System.Web.Mvc;
using MileagePro.Models;
using MileagePro.SL.Contracts;
using MileagePro.SL.Services;

namespace MileagePro.Controllers
{
	public class ManageDataPointController : Controller
	{
		private readonly DataPointService dataPointService;

		public ManageDataPointController()
		{
			dataPointService = new DataPointService(MvcApplication.DocumentStore);
		}

		// GET: DataPoint
		public ActionResult Index()
		{
			var dataPoints = dataPointService.GetDataPoints().ToList();

			var dataPointModels = dataPoints.Select(point => new DataPointModel
			{
				Id = point.Id,
				Date = point.Date,
				OdometerReading = point.OdometerReading,
				TotalCost = point.TotalCost,
				GallonsPurchased = point.GallonsPurchased,
				PricePerGallon = point.PricePerGallon,
				DistanceSinceLastFill = point.DistanceSinceLastFill
			}).ToList();

			var model = new DataPointListModel(dataPointModels);

			return View(model);
		}

		// GET: DataPoint/Details/5
		public ActionResult Details(int id)
		{
			var dataPoint = dataPointService.GetDataPoint(id);

			var dataPointModel = new DataPointModel
			{
				Id = dataPoint.Id,
				Date = dataPoint.Date,
				OdometerReading = dataPoint.OdometerReading,
				TotalCost = dataPoint.TotalCost,
				GallonsPurchased = dataPoint.GallonsPurchased,
				PricePerGallon = dataPoint.PricePerGallon,
				DistanceSinceLastFill = dataPoint.DistanceSinceLastFill
			};

			return View(dataPointModel);
		}

		// GET: DataPoint/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: DataPoint/Create
		[HttpPost]
		public ActionResult Create(DataPointModel dataPoint)
		{
			try
			{
				var contract = new MileageDataPoint
				{
					OdometerReading = dataPoint.OdometerReading,
					TotalCost = dataPoint.TotalCost,
					GallonsPurchased = dataPoint.GallonsPurchased
				};

				dataPointService.CreateDataPoint(contract);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: DataPoint/Edit/5
		public ActionResult Edit(int id)
		{
			var dataPoint = dataPointService.GetDataPoint(id);

			var dataPointModel = new DataPointModel
			{
				Date = dataPoint.Date,
				OdometerReading = dataPoint.OdometerReading,
				TotalCost = dataPoint.TotalCost,
				GallonsPurchased = dataPoint.GallonsPurchased,
				PricePerGallon = dataPoint.PricePerGallon,
				DistanceSinceLastFill = dataPoint.DistanceSinceLastFill
			};

			return View(dataPointModel);
		}

		// POST: DataPoint/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, DataPointModel dataPoint)
		{
			try
			{
				var contract = new MileageDataPoint
				{
					OdometerReading = dataPoint.OdometerReading,
					TotalCost = dataPoint.TotalCost,
					GallonsPurchased = dataPoint.GallonsPurchased,
					PricePerGallon = dataPoint.GallonsPurchased / dataPoint.TotalCost,
					DistanceSinceLastFill = dataPoint.DistanceSinceLastFill,
					Date = dataPoint.Date
				};

				dataPointService.EditDataPoint(id, contract);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: DataPoint/Delete/5
		public ActionResult Delete(int id)
		{
			dataPointService.DeleteDataPoint(id);

			return RedirectToAction("Index");
		}
	}
}
