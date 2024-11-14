using LAb_1;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class CarTest
        {
            [TestMethod]
            [DataRow("USA", true)]
            [DataRow("UK", false)]
            [DataRow("", false)]
            [DataRow("Ukraine", true)]
            public void CountryTest(string test_country, bool expected)
            {
                // Arrange
                Car car = new Car();

                // Act
                if (expected)
                {
                    Car.Country = test_country;

                    // Assert
                    Assert.AreEqual(test_country, Car.Country);
                }
                else
                {
                    // Assert
                    Assert.ThrowsException<ArgumentNullException>(() => Car.Country = test_country);
                }
            }

            [TestMethod]
            [DataRow("ModelX", true)]
            [DataRow("AB", false)]
            [DataRow("", false)]
            [DataRow("Tesla", true)]
            public void NameModelTest(string nameModel, bool expected)
            {
                // Arrange
                Car car = new Car();

                // Act
                if (expected)
                {
                    car.NameModel = nameModel;

                    // Assert
                    Assert.AreEqual(nameModel, car.NameModel);
                }
                else
                {
                    // Assert
                    Assert.ThrowsException<ArgumentNullException>(() => car.NameModel = nameModel);
                }
            }

            [TestMethod]
            [DataRow(BrandCar.FORD, true)]
            [DataRow((BrandCar)999, false)]
            public void BrandTest(BrandCar brand, bool expected)
            {
                // Arrange
                Car car = new Car();

                // Act
                if (expected)
                {
                    car.Brand = brand;

                    // Assert
                    Assert.AreEqual(brand, car.Brand);
                }
                else
                {
                    // Assert
                    Assert.ThrowsException<ArgumentException>(() => car.Brand = brand);
                }
            }

            [TestMethod]
            [DataRow(ColorCar.RED, true)]
            [DataRow(ColorCar.UNKNOWN, true)]
            [DataRow((ColorCar)999, false)]
            public void ColorTest(ColorCar color, bool expected)
            {
                // Arrange
                Car car = new Car();

                // Act
                if (expected)
                {
                    car.Color = color;

                    // Assert
                    Assert.AreEqual(color, car.Color);
                }
                else
                {
                    // Assert
                    Assert.ThrowsException<ArgumentException>(() => car.Color = color);
                }
            }


            [TestMethod]
            [DataRow(300, true)]
            [DataRow(0, false)]
            [DataRow(600, false)]
            [DataRow(500, true)]
            public void MaxSpeedTest(int maxSpeed, bool expected)
            {
                // Arrange
                Car car = new Car();

                // Act
                if (expected)
                {
                    car.MaxSpeed = maxSpeed;

                    // Assert
                    Assert.AreEqual(maxSpeed, car.MaxSpeed);
                }
                else
                {
                    // Assert
                    Assert.ThrowsException<ArgumentOutOfRangeException>(() => car.MaxSpeed = maxSpeed);
                }
            }

            [TestMethod]
            [DataRow(2500f, true)]
            [DataRow(-1f, false)]
            [DataRow(6000f, false)]
            [DataRow(5000f, true)]
            public void WeightTest(float weight, bool expected)
            {
                // Arrange
                Car car = new Car();

                // Act
                if (expected)
                {
                    car.Weight = weight;

                    // Assert
                    Assert.AreEqual(weight, car.Weight);
                }
                else
                {
                    // Assert
                    Assert.ThrowsException<ArgumentOutOfRangeException>(() => car.Weight = weight);
                }
            }

            [TestMethod]
            [DataRow((short)999, true)]
            [DataRow((short)-1, false)]
            [DataRow((short)10000, false)]
            [DataRow((short)1, true)]
            public void NumberTest(short number, bool expected)
            {
                // Arrange
                Car car = new Car();

                // Act
                if (expected)
                {
                    car.Number = number;

                    // Assert
                    Assert.AreEqual(number, car.Number);
                }
                else
                {
                    // Assert
                    Assert.ThrowsException<ArgumentOutOfRangeException>(() => car.Number = number);
                }
            }

            [TestMethod]
            [DataRow((short)50, true)]
            [DataRow((short)-1, true)]
            [DataRow((short)100, true)]
            [DataRow((short)0, true)]
            public void FuelTest(short fuel, bool expected)
            {
                // Arrange
                Car car = new Car();

                // Act
                car.Fuel = fuel;

                // Assert
                Assert.AreEqual(fuel, car.Fuel);
            }
            [TestMethod]
            [DataRow("AutoName/FORD/RED/180/1234/1400",true)]
            [DataRow("AutoName, FORD, RED, 180, 1234, 1400",true)]
            [DataRow("AutoName-FORD-RED-180-1234-1400", false)]
            [DataRow("AutoName/FORD/RED/180/1234",false)]
            [DataRow("AutoName/FORD/RED", true)]
            [DataRow("AutoName, FORD, RED", true)]
            [DataRow("AutoName-FORD-RED",false)]
            [DataRow(" ", false)]
            [DataRow("AutoName/FORD", false)]
            public void ParseTest(string input, bool expected)
            {
                // Arrange
                // Act & Assert
                if (expected)
                {
                    var car = Car.Parse(input);
                    Assert.IsNotNull(car);
                }
                else
                {
                    Assert.ThrowsException<FormatException>(() => Car.Parse(input));
                }
            }

           
          
            [TestMethod]
            [DataRow("AutoName/FORD/RED/180/1234/1400",true)]
            [DataRow("AutoName, FORD, RED, 180, 1234, 1400",true)]
            [DataRow("AutoName-FORD-RED-180-1234-1400", false)]
            [DataRow("",  false)]
            [DataRow("AutoName/FORD/RED/180/1234", false)]
            [DataRow("AutoName/FORD/RED",  true)]
            [DataRow("AutoName, FORD, RED",  true)]
            [DataRow("AutoName-FORD-RED", false)]
            [DataRow("", false)]
            [DataRow("AutoName/FORD", false)]
           public void TryParseTest(string input, bool expected)
            {
                // Arrange
                Car car;

                // Act
                var result = Car.TryParse(input,  out car);

                // Assert
                Assert.AreEqual(expected, result);
                if (expected)
                {
                    Assert.IsNotNull(car);
                }
                else
                {
                    Assert.IsNull(car);
                }
            }

            [TestMethod]
           public void EngineStartWorkTest()
            {
                // Arrange
                Car car = new Car();
                car.Fuel = 10;

                // Act
                car.EngineStartWork();

                // Assert
                Assert.IsTrue(car.EngineIsRunning);
            }

            [TestMethod]
           public void EngineStartWork_NoFuelTest()
            {
                // Arrange
                Car car = new Car();
                car.Fuel = 0;

                // Act & Assert
                Assert.ThrowsException<Exception>(() => car.EngineStartWork());
            }

            [TestMethod]
           public void EngineStopWorkTest()
            {
                // Arrange
                Car car = new Car();
                car.Fuel = 10;
                car.EngineStartWork();

                // Act
                car.EngineStopWork();

                // Assert
                Assert.IsFalse(car.EngineIsRunning);
            }

            [TestMethod]
            [DataRow((short)1, true)]
            [DataRow((short)2, true)]
            [DataRow((short)3, true)]
            [DataRow((short)4, true)]
            [DataRow((short)0, false)]
           public void StartTravelTest(short distance, bool expected)
            {
                // Arrange
                Car car = new Car();
                car.Fuel = 50;

                // Act & Assert
                if (expected)
                {
                    car.EngineStartTravel(distance);
                    Assert.AreEqual(distance, car.Distance);
                }
                else
                {
                    Assert.ThrowsException<ArgumentOutOfRangeException>(() => car.EngineStartTravel(distance));
                }
            }

        }
    }
}




