namespace InheritanceVehicle
{
    public class Vehicle
    {
        private readonly int maxSpeed;
        private string name;

        public Vehicle(string name, int maxSpeed)
        {
            this.name = name == null ? throw new ArgumentOutOfRangeException(nameof(name)) : name;
            this.maxSpeed = maxSpeed < 0 ? throw new ArgumentOutOfRangeException(nameof(maxSpeed)) : maxSpeed;
        }

        public int MaxSpeed
        {
            get => this.maxSpeed;
        }

        protected string Name
        {
            get => this.name;
            set => this.name = value == null ? throw new ArgumentOutOfRangeException(nameof(value)) : value;
        }
    }
}
