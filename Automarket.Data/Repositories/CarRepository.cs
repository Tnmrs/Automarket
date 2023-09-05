using System;
using Automarket.Data.Interfaces;
using Automarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Automarket.Data.Repositories
{
	public class CarRepository : ICarRepository
	{
        private readonly ApplicationDbContext _db;
		public CarRepository(ApplicationDbContext db)
		{
            _db = db;
		}

        public async Task<bool> Create(Car entity)
        {
            await _db.Cars.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Car entity)
        {
            _db.Cars.Remove(entity);
            await _db.SaveChangesAsync();
            return true; 
        }

        public async Task<Car> Get(int id)
        {
           return await _db.Cars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Car> GetByName(string name)
        {
            return await _db.Cars.FirstOrDefaultAsync(x => x.Name == name);
        }


        //Car ICarRepository.GetByName(string name)
        //{
        //    throw new NotImplementedException();
        //}

        public  async Task<List<Car>> Select()
        {
            return await _db.Cars.ToListAsync(); 
        }

    }
}

