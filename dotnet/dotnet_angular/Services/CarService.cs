using dotnet_angular.Constants;

namespace dotnet_angular.Services;

public class CarService
{

	public List<Entities.Car> GetCars()
	{
		return CarConstant.cars;
	}

	public void ResetBaseCars()
	{
		CarConstant.ResetBaseCars();
	}

	public bool UpdateCar(int id, Entities.Car updatedCar)
	{
		CarConstant.UpdateCar(id, updatedCar);

		return true;
	}

	public bool DeleteCar(int id)
	{
		CarConstant.DeleteCar(id);

		return true;
	}

	public Entities.Car AddCar(Entities.Car newCar)
	{
		CarConstant.AddCar(newCar);

		return CarConstant.cars!.MaxBy(max => max.Id);
	}
}