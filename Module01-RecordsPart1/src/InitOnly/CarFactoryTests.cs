using Xunit;

namespace InitOnly
{
    /// <summary>
    /// TODO:
    /// 1. Add missing constrain requirement to the <see cref="ICar.CreateCar"/> to use object initializer
    /// 2. Implement ICar interface on the <see cref="Toyota"/> class
    /// 3. Implement car immutability by introducing `init` accessors to the properties
    /// </summary>
    public class CarFactoryTests
    {
        [Theory]
        [InlineData("Supra", 340)]
        public void CreatesCarWithValues(string name, int hp)
        {
            var car = CarFactory.CreateCar<Toyota>(name, hp);

            Assert.NotNull(car);
            Assert.Equal(name, car.Name);
            Assert.Equal(hp, car.HorsePower);
        }
    }

    class CarFactory
    {
        public static ICar CreateCar<TCar>(string name, int horsePower) where TCar : ICar, new()
        {
            var car = new TCar
            {
                Name = name,
                HorsePower = horsePower
            };
            return car;
        }
    }

    class Toyota : ICar
    {
        public string Name { get; init; }
        public int HorsePower { get; init; }
    }

    interface ICar
    {
        string Name { get; init; }

        int HorsePower { get; init; }
    }
}
