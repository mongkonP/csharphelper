
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_define_interface

 { 

public class Car : IVehicle
    {
        // Implement IVehicle.MaxSpeed explicitly.
        private int _MaxSpeed;
    public   int MaxSpeed
        {
            get { return _MaxSpeed; }
            set { _MaxSpeed = value; }
        }

        // Implement IVehicle.Mpg implicitly.
        private float _Mpg;
        public float Mpg
        {
            get { return _Mpg; }
            set { _Mpg = value; }
        }

        // Add a new property.
        private int _NumCupholders;
        public int NumCupholders
        {
            get { return _NumCupholders; }
            set { _NumCupholders = value; }
        }
    }

    public interface IVehicle
    {
         int MaxSpeed { get; set; }
        float Mpg { get; set; }
    }

}