

  namespace  howto_multiple_inheritance

 { 

public class Domicile
    {
        private int _SquareFeet;
        public int SquareFeet
        {
            get { return _SquareFeet; }
            set { _SquareFeet = value; }
        }
    }


public class HouseBoat : Domicile, IVehicle
    {
        // Inherits the SquareFeet property from Domicile.

        // Delegate IVehicle features to a Vehicle object.
        private Vehicle _Vehicle = new Vehicle();
        public int MaxSpeed
        {
            get { return _Vehicle.MaxSpeed; }
            set { _Vehicle.MaxSpeed = value; }
        }
    }


public interface IVehicle
    {
        // Define a MaxSpeed property.
        int MaxSpeed { get; set; }
    }


public class Vehicle : IVehicle
    {
        // Implement IVehicle.MaxSpeed
        private int _MaxSpeed;
        public int MaxSpeed
        {
            get { return _MaxSpeed; }
            set { _MaxSpeed = value; }
        }
    }

}