#pragma warning disable S3400

namespace InheritanceVehicle
{
    public class Car : Vehicle
    {
        public Car(string name, int maxSpeed)
            : base(name, maxSpeed)
        {
        }

        public void ChangeName(string newName)
        {
            this.Name = newName;
        }

        public string GetName()
        {
            return this.Name;
        }

        public virtual string Start()
        {
            return "The car has started.";
        }

        public virtual string Stop()
        {
            return "The car has stopped.";
        }

        public virtual string Accelerate()
        {
            return "The car is accelerating.";
        }

        public virtual string Decelerate()
        {
            return "The car is decelerating.";
        }

        public virtual string Drive()
        {
            return "Driven";
        }
    }
}
