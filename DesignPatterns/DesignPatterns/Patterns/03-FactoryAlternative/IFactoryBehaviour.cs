using System;
namespace DesignPatterns
{
    public interface IFactoryBehaviour
    {
        public bool CanManufacture(List<Resource> listOfInputs);
        public List<Resource> Manufacture(List<Resource> selectedInputs);
        public List<Resource> Run(List<Resource> listOfInputs);
    }
}

