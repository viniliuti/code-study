namespace dotnet_angular.Entities;

public class Car
{
	public int Id { get; set; }
	public string Make { get; set; }
	public string Model { get; set; }
	public int Year { get; set; }
	public int Doors { get; set; }
	public string Color { get; set; }
	public decimal Price { get; set; }
	public bool ShowPrice { get; set; }

	public Car()
	{
		Make = string.Empty;
		Model = string.Empty;
		Color = string.Empty;
	}
}
