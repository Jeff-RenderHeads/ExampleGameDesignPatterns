using System;
using System.Security.AccessControl;
using System.Linq;

namespace DesignPatterns
{
    public class CarBehaviour : IFactoryBehaviour
    {
        public CarBehaviour()
        {
        }

        public bool CanManufacture(List<Resource> listOfInputs)
        {
            return true;
        }

        public List<Resource> Manufacture(List<Resource> selectedInputs)
        {
            Console.WriteLine($"[{this.GetType()}] Manufacturing");

            return new List<Resource>() { Resource.Car};
        }

        public List<Resource> Run(List<Resource> listOfInputs)
        {
            Console.WriteLine($"[{this.GetType()}] Running");
            List<Resource> outputs = new List<Resource>();

            if (CanManufacture(listOfInputs))
            {
                List<Resource> selectedInputs = new List<Resource>();
                Resource resource = listOfInputs.FirstOrDefault(Resource.None);
                selectedInputs.Add(resource);
                listOfInputs.Remove(resource);
                outputs.AddRange(Manufacture(selectedInputs));
            }

            if (outputs.Count == 0)
            {
                Resource r = Resource.None;
                outputs.Add(r);
            }
            return outputs;
        }
    }
}

