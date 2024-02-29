using System.Reflection;
using NUnit.Framework;

namespace InheritanceVehicle.Tests
{
    [TestFixture]
    public class CarTests
    {
        private const string CarClassName = "car";
        private const string VehicleClassName = "vehicle";
        private Type carType;

        [SetUp]
        public void Initialize()
        {
            var assembly = typeof(Stub).Assembly;
            this.carType = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(CarClassName, StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public void Car_Class_Is_Created()
        {
            Assert.IsNotNull(this.carType, "'Car' class is not created.");
        }

        [Test]
        public void Car_Inherits_Vehicle()
        {
            var carInstance = Activator.CreateInstance(this.carType, string.Empty, 0);
            var vehicleType = typeof(Stub).Assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(VehicleClassName, StringComparison.OrdinalIgnoreCase));

            Assert.IsInstanceOf(vehicleType, carInstance, "'Car' type does NOT inherit 'Vehicle' type.");
        }

        [Test]
        public void Set_Name_Method_Is_Defined()
        {
            var method = this.carType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .FirstOrDefault(m =>
                {
                    var parameters = m.GetParameters();
                    if (m.ReturnType == typeof(void) && parameters?.FirstOrDefault()?.ParameterType == typeof(string))
                    {
                        return true;
                    }

                    return false;
                });

            Assert.IsNotNull(method, "Method which changes 'Car' name is NOT define or it does NOT contain correct parameters.");
        }

        [Test]
        public void Get_Name_Method_Is_Defined()
        {
            var method = this.carType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .FirstOrDefault(m =>
                {
                    if (m.ReturnType == typeof(string) && m.GetParameters().Length == 0)
                    {
                        return true;
                    }

                    return false;
                });

            Assert.IsNotNull(method, "Method which retrieves 'Car' name is NOT define or it is's return type is NOT correct.");
        }

        [Test]
        public void Get_Car_Name()
        {
            var name = "Toyota";
            var newName = "BMW";
            var age = 5;
            var carInstance = Activator.CreateInstance(this.carType, name, age);

            var setNameMethod = this.carType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .FirstOrDefault(m =>
                {
                    var parameters = m.GetParameters();
                    if (m.ReturnType == typeof(void) && parameters?.FirstOrDefault()?.ParameterType == typeof(string))
                    {
                        return true;
                    }

                    return false;
                });

            var getNameMethod = this.carType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .FirstOrDefault(m =>
                {
                    if (m.ReturnType == typeof(string) && m.GetParameters().Length == 0)
                    {
                        return true;
                    }

                    return false;
                });

            setNameMethod.Invoke(carInstance, new[] { newName });

            var carName = getNameMethod.Invoke(carInstance, Array.Empty<object>());

            Assert.AreEqual(
                newName,
                carName,
                $"'{getNameMethod.Name}' method does NOT return correct value or '{setNameMethod.Name}' method does NOT change car name correctly.");
        }

        [Test]
        public void TestCarConst()
        {
            Car car = new Car("Test Car", 100);
            Assert.AreEqual("Test Car", car.GetName());
            Assert.AreEqual(100, car.MaxSpeed);
        }

        [Test]
        public void TestCarChangeName()
        {
            Car car = new Car("Test Car", 100);
            car.ChangeName("New Car Name");
            Assert.AreEqual("New Car Name", car.GetName());
        }

        [Test]
        public void TestCarStart()
        {
            Car car = new Car("Test Car", 100);
            Assert.AreEqual("The car has started.", car.Start(), $"'{car.Start()}' method does not return correct value.");
        }

        [Test]
        public void TestCarStop()
        {
            Car car = new Car("Test Car", 100);
            Assert.AreEqual("The car has stopped.", car.Stop(), $"'{car.Stop()}' method does bot return correct value.");
        }

        [Test]
        public void TestCarDrive()
        {
            Car car = new Car("Test Car", 100);
            Assert.AreEqual("Driven", car.Drive(), $"'{car.Drive()}' method does not return correct value.");
        }

        [Test]
        public void TestCarAccelerate()
        {
            Car car = new Car("Test Car", 100);
            Assert.AreEqual("The car is accelerating.", car.Accelerate(), $"'{car.Accelerate()}' method does not return correct value.");
        }

        [Test]
        public void TestCarDecelerate()
        {
            Car car = new Car("Test Car", 100);
            Assert.AreEqual("The car is decelerating.", car.Decelerate(), $"'{car.Decelerate()}' method does not return correct value.");
        }

        [Test]
        public void Properties_WithNullName_ThrowsException()
        {
            Car car = new Car("Test Car", 100);
            Assert.Throws<ArgumentOutOfRangeException>(() => car.ChangeName(null));
        }
    }
}
