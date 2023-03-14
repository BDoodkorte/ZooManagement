using System;
using ZooManagement.Models;

namespace ZooManagement.Models
{
    public class AnimalResponse
    {
        private readonly AnimalDetail _animal;

        public AnimalResponse(AnimalDetail animal)
        {
            _animal = animal;
        }
        
        public int Id => _animal.Id;
    public string Name =>  _animal.Name;
    public string Sex =>  _animal.Sex;
    public string DOB =>  _animal.DOB;
    public string DateAcquired =>  _animal.DateAcquired;
    public AnimalType Type =>  _animal.Type;
    }
}