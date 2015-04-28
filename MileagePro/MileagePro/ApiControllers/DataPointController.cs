using System.Linq;
using System.Web.Http;
using MileagePro.ApiModels;
using MileagePro.SL.Interfaces;
using MileagePro.SL.Services;

namespace MileagePro.ApiControllers
{
	public class DataPointController : ApiController
	{
		private readonly IDataPointService dataPointService;

		public DataPointController()
		{
			dataPointService = new DataPointService(MvcApplication.DocumentStore);
		}

		public DataPointController(IDataPointService dataPointService)
		{
			this.dataPointService = dataPointService;
		}

		[HttpGet]
		public IHttpActionResult GetById(int id)
		{
			var contract = dataPointService.GetDataPoint(id);

			var model = new DataPoint
			{
				OdometerReading = contract.OdometerReading,
				DistanceSinceLastFill = contract.DistanceSinceLastFill,
				Date = contract.Date,
				GallonsPurchased = contract.GallonsPurchased,
				PricePerGallon = contract.PricePerGallon,
				TotalCost = contract.TotalCost,
			};

			return Ok(model);
		}

		[HttpGet]
		public IHttpActionResult GetAll()
		{
			var contracts = dataPointService.GetDataPoints();

			var models = contracts.Select(x => new DataPoint(x)).ToList();
			return Ok(models);
		}
	}
}