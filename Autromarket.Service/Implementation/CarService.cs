using System;
using Automarket.Data.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Response;
using Autromarket.Service.Interfaces;

namespace Autromarket.Service.Implementation
{
    public class CarService : ICarService

    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<Car>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.Get(id);

                if (car == null)
                {
                    baseResponse.Description = "Пользователь не найден";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InteranlServiceError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {//Получаем обьект, если не равен null, то удаляем его

            var baseResponse = new BaseResponse<bool>
            {
                Data = true
            };

            try
            {
                //Получаем обьект по id
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseResponse.Description = "Пользователь не найден";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _carRepository.Delete(car);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InteranlServiceError
                };

            }
        }


        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.GetByName(name);
                if (car == null)
                {
                    baseResponse.Description = "Пользователь не найден";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetByName] : {ex.Message}",
                    StatusCode = StatusCode.InteranlServiceError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
        {
            var baseResponse = new BaseResponse<IEnumerable<Car>>();
            try
            {
                var cars = await _carRepository.Select();
                if (cars.Count == 0)
                {
                    baseResponse.Description = ("Найдено 0 элементов");
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = cars;
                baseResponse.StatusCode = StatusCode.OK; //элементы из базы данных
                return baseResponse;
            }

            catch( Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InteranlServiceError
                };
            }
        }
    }
}

