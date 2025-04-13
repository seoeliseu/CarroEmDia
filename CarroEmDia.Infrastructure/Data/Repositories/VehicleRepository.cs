using CarroEmDia.Domain.Entities;
using CarroEmDia.Domain.Repositories;
using CarroEmDia.Infrastructure.Data.Context;

namespace CarroEmDia.Infrastructure.Data.Repositories
{
    public class VehicleRepository(CarroEmDiaDbContext context) : Repository<Vehicle>(context), IVehicleRepository
    {

    }
}
