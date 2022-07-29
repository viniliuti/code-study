using Microsoft.AspNetCore.Mvc;

namespace dotnet_angular.Controllers.Car;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
	public CarController()
	{ }

	[HttpGet]
	public IActionResult Get()
	{
		return Ok(true);
	}
}