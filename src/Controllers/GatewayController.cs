using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GatewayController : ControllerBase
	{
		private readonly ILogger<GatewayController> _logger;

		public GatewayController(ILogger<GatewayController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetHi")]
		public IActionResult Get()
		{
			return Ok("CRM IS Up And Running!");
		}
	}
}