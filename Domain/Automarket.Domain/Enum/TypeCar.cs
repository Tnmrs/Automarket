using System;
using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Легковой автомобиль")]
        PassengerCar = 1,
        [Display(Name = "Седан")]
        Sedan = 2,
        [Display(Name = "Внедорожник")]
        Offroad = 3,
        [Display(Name = "Автобоус")]
        Bus = 4,
        [Display(Name = "Минивен")]
        Minivan = 5,
    }
}


