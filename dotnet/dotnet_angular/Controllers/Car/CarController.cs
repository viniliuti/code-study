using dotnet_angular.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_angular.Controllers.Car;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
	private CarService _carService;
	public CarController()
	{
		_carService = new CarService();
	}

	[HttpGet]
	public IActionResult Get()
	{
		System.Console.WriteLine("caius");
		return Ok(_carService.GetCars());
	}
}