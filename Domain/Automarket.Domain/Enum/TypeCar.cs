using System;
using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Легковой автомобиль")]
        PassengerCar = 0,
        [Display(Name = "Легковой автомобиль")]
        Sedan = 1,
        [Display(Name = "Легковой автомобиль")]
        Offroad = 2,
        [Display(Name = "Легковой автомобиль")]
        Bus = 3,
        [Display(Name = "Легковой автомобиль")]
        Minivan = 4,
    }
}


