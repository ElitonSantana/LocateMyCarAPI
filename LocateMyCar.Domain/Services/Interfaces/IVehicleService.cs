using LocateMyCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocateMyCar.Domain.Services.Interfaces
{
    public interface IVehicleService
    {
        MessageResponse<List<Vehicle>> GetAll();
        MessageResponse<Vehicle> GetById(int Id);
        MessageResponse<object> Create(VehicleRequest vehicle);
        MessageResponse<object> Update(VehicleRequest vehicle);
        MessageResponse<object> Delete(int Id);
        MessageResponse<List<VehicleVM>> GetTopVehiclesOlders(); 

        MessageResponse<VehicleDetail> GetVehicleDetailById(int Id);
        MessageResponse<object> CreateVehicleDetail(VehicleDetailRequest vehicle);
        MessageResponse<object> UpdateVehicleDetail(VehicleDetailRequest vehicle);
        MessageResponse<object> DeleteVehicleDetail(int Id);
    }
}
