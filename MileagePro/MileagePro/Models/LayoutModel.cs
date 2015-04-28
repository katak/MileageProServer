namespace MileagePro.Models
{
	public class LayoutModel
	{
		public LayoutModel()
		{
			Version = typeof(LayoutModel).Assembly.GetName().Version.ToString();
		}

		public string Version { get; set; }
	}
}