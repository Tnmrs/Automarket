using System;
using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Легковой автомобиль")]
        PassengerCar = 0,
        [Display(Name = "Седан")]
        Sedan = 1,
        [Display(Name = "Внедорожник")]
        Offroad = 2,
        [Display(Name = "Автобоус")]
        Bus = 3,
        [Display(Name = "Минивен")]
        Minivan = 4,
    }
}


