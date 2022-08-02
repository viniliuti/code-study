namespace dotnet_angular.Constants;

public static class CarConstant
{
	private static List<Entities.Car> baseCars = new()
	{
		new Entities.Car
		{
			Id = 1,
			Make = "Audi",
			Model = "R8",
			Year = 2018,
			Doors = 2,
			Color = "Red",
			Price = 79995
		},
		new Entities.Car
		{
			Id = 2,
			Make = "Tesla",
			Model = "3",
			Year = 2018,
			Doors = 4,
			Color = "Black",
			Price = 54995
		},
		new Entities.Car
		{
			Id = 3,
			Make = "Porsche",
			Model = " 911 991",
			Year = 2020,
			Doors = 2,
			Color = "White",
			Price = 155000
		},
		new Entities.Car
		{
			Id = 4,
			Make = "Mercedes-Benz",
			Model = "GLE 63S",
			Year = 2021,
			Doors = 5,
			Color = "Blue",
			Price = 83995,
			ShowPrice = true
		},
		new Entities.Car
		{
			Id = 5,
			Make = "BMW",
			Model = "X6 M",
			Year = 2020,
			Doors = 5,
			Color = "Silver",
			Price = 62995
		},
	};

	private static List<Entities.Car>? toUpdateCars { get; set; }

	public static List<Entities.Car> cars => toUpdateCars ?? baseCars;

	static CarConstant()
	{
		toUpdateCars = new List<Entities.Car>();
		baseCars.ForEach((item) =>
		{
			toUpdateCars.Add(new Entities.Car()
			{
				Id = item.Id,
				Make = item.Make,
				Model = item.Model,
				Year = item.Year,
				Doors = item.Doors,
				Color = item.Color,
				Price = item.Price,
				ShowPrice = item.ShowPrice
			});
		});
	}

	public static void ResetBaseCars()
	{
		toUpdateCars = new List<Entities.Car>();
		baseCars.ForEach((item) =>
		{
			toUpdateCars.Add(new Entities.Car()
			{
				Id = item.Id,
				Make = item.Make,
				Model = item.Model,
				Year = item.Year,
				Doors = item.Doors,
				Color = item.Color,
				Price = item.Price,
				ShowPrice = item.ShowPrice
			});
		});
	}

	public static void UpdateCar(int id, Entities.Car updatedCar)
	{
		var currentCar = toUpdateCars!
			.Where(w => w.Id == id).FirstOrDefault();

		if (currentCar == null)
			return;

		currentCar.Make = updatedCar.Make;
		currentCar.Model = updatedCar.Model;
		currentCar.Year = updatedCar.Year;
		currentCar.Doors = updatedCar.Doors;
		currentCar.Color = updatedCar.Color;
		currentCar.Price = updatedCar.Price;
		currentCar.ShowPrice = updatedCar.ShowPrice;
	}

	public static void DeleteCar(int id)
	{
		var toRemoveCar = toUpdateCars!
			.Where(w => w.Id == id).FirstOrDefault();

		if (toRemoveCar == null)
			return;

		toUpdateCars!
			.Remove(toRemoveCar);
	}
	public static void AddCar(Entities.Car newCar)
	{
		toUpdateCars!.Add(newCar);
	}

}
