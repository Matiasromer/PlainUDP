using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string RegistrationNr { get; set; }

        public Car()
        {
            
        }
        public Car(string model, string color, string registrationNr)
        {
            Model = model;
            Color = color;
            RegistrationNr = registrationNr;
        }

        public override string ToString()
        {
            return $"{nameof(Model)}: {Model}, {nameof(Color)}: {Color}, {nameof(RegistrationNr)}: {RegistrationNr}, ";
        }
    }
}
