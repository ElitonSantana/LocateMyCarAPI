using LocateMyCar.Domain.Entities;
using LocateMyCar.Domain.Services.Interfaces;
using Newtonsoft.Json;

namespace LocateMyCar.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<VehicleDetail> _vehicleDetailRepository;
        public VehicleService(IRepository<Vehicle> vehicleRepository, IRepository<VehicleDetail> vehicleDetailRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleDetailRepository = vehicleDetailRepository;
        }

        #region :: Vehicle ::

        public MessageResponse<object> Create(VehicleRequest vehicle)
        {
            try
            {
                var entity = new Vehicle();
                entity.Brand = vehicle.Brand;
                entity.Model = vehicle.Model;
                entity.Type = vehicle.Type;
                entity.ImageURL = vehicle.ImageURL;

                _vehicleRepository.Create(entity);
                return new MessageResponse<object> { Success = true, Message = "Veiculo adicionado com sucesso!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em {nameof(Create)} vehicle {JsonConvert.SerializeObject(vehicle)} ex {ex.Message}");
                return new MessageResponse<object> { Message = $"Ocorreu um erro para adicionar o veiculo." };
            }

        }

        public MessageResponse<List<Vehicle>> GetAll()
        {
            var list = _vehicleRepository.GetAll(include: x => x.VehicleDetails);
            if (list != null && list.Any())
                return new MessageResponse<List<Vehicle>> { Success = true, Entity = list.ToList() };
            else
                return new MessageResponse<List<Vehicle>> { Message = "Nenhum veículo foi encontrado!" };
        }

        public MessageResponse<Vehicle> GetById(int Id)
        {
            var response = _vehicleRepository.GetById(where: x => x.VehicleId == Id, include: x => x.VehicleDetails);
            if (response != null)
                return new MessageResponse<Vehicle> { Success = true, Entity = response };
            else
                return new MessageResponse<Vehicle> { Message = "Registro não encontrado!" };
        }

        public MessageResponse<object> Update(VehicleRequest vehicle)
        {
            try
            {
                var entity = _vehicleRepository.GetById(where: x => x.VehicleId == vehicle.VehicleId);
                if (entity != null)
                {
                    entity.Brand = vehicle.Brand;
                    entity.Model = vehicle.Model;
                    entity.Type = vehicle.Type;
                    entity.ImageURL = vehicle.ImageURL;
                    _vehicleRepository.Update(entity);

                    return new MessageResponse<object> { Success = true, Message = "Veículo atualizado!" };
                }
                else
                    return new MessageResponse<object> { Message = "Veículo não encontrado!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em {nameof(Update)} vehicle {JsonConvert.SerializeObject(vehicle)} ex {ex.Message}");
                return new MessageResponse<object> { Message = $"Ocorreu um erro para atualizar o veiculo." };
            }
        }

        public MessageResponse<object> Delete(int Id)
        {
            try
            {
                var entity = _vehicleRepository.GetById(where: x => x.VehicleId == Id, include: x=> x.VehicleDetails);
                if (entity.VehicleDetails != null && entity.VehicleDetails.Any())
                    return new MessageResponse<object> { Message = "Você precisa remover as versões do veiculo primeiro, para depois apagar o veiculo!" };
                else if (entity != null)
                {
                    _vehicleRepository.Delete(Id);
                    return new MessageResponse<object> { Success = true, Message = "Veículo removido com sucesso!" };
                }
                else
                    return new MessageResponse<object> { Message = "Veículo não encontrado!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em {nameof(Delete)} vehicleId {Id} ex {ex.Message}");
                return new MessageResponse<object> { Message = $"Ocorreu um erro para remover o veiculo." };
            }
        }

        public MessageResponse<List<VehicleVM>> GetTopVehiclesOlders()
        {
            var list = _vehicleRepository.GetTopVehiclesOlders();
            if (list != null && list.Any())
                return new MessageResponse<List<VehicleVM>> { Success = true, Entity = list };
            else
                return new MessageResponse<List<VehicleVM>> { Message = "Nenhum veículo foi encontrado!" };
        }

        #endregion

        #region :: VehicleDetails ::

        public MessageResponse<VehicleDetail> GetVehicleDetailById(int Id)
        {
            var response = _vehicleDetailRepository.GetById(where: x => x.VehicleDetailId == Id);
            if (response != null)
                return new MessageResponse<VehicleDetail> { Success = true, Entity = response };
            else
                return new MessageResponse<VehicleDetail> { Message = "Registro não encontrado!" };
        }

        public MessageResponse<object> CreateVehicleDetail(VehicleDetailRequest vehicleDetail)
        {
            var vehicleExistent = _vehicleRepository.GetById(where: x => x.VehicleId == vehicleDetail.VehicleId);

            if (vehicleExistent != null)
            {
                var entity = new VehicleDetail();
                entity.Year = vehicleDetail.Year;
                entity.Price = vehicleDetail.Price;
                entity.VehicleDoors = vehicleDetail.VehicleDoors;
                entity.VehiclePower = vehicleDetail.VehiclePower;
                entity.ImageURL = vehicleDetail.ImageURL;
                entity.VehicleId = vehicleDetail.VehicleId;

                _vehicleDetailRepository.Create(entity);
                return new MessageResponse<object> { Success = true, Message = "Versão do veiculo adicionada com sucesso!" };
            }
            else
            {
                Console.WriteLine($"Erro em {nameof(CreateVehicleDetail)} não existe o veiculo de VehicleId {vehicleDetail.VehicleId} vehicleDetail {JsonConvert.SerializeObject(vehicleDetail)}");
                return new MessageResponse<object> { Message = "Veiculo informado inválido." };
            }
        }

        public MessageResponse<object> UpdateVehicleDetail(VehicleDetailRequest vehicleDetail)
        {
            try
            {
                var entity = _vehicleDetailRepository.GetById(where: x => x.VehicleDetailId == vehicleDetail.VehicleDetailId);
                if (entity != null)
                {
                    entity.Year = vehicleDetail.Year;
                    entity.Price = vehicleDetail.Price;
                    entity.VehicleDoors = vehicleDetail.VehicleDoors;
                    entity.VehiclePower = vehicleDetail.VehiclePower;
                    entity.ImageURL = vehicleDetail.ImageURL;
                    entity.VehicleId = vehicleDetail.VehicleId;

                    _vehicleDetailRepository.Update(entity);
                    return new MessageResponse<object> { Success = true, Message = "Versão do veículo atualizado!" };
                }
                else
                    return new MessageResponse<object> { Message = "Versão do veículo não encontrado!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em {nameof(UpdateVehicleDetail)} vehicleDetail {JsonConvert.SerializeObject(vehicleDetail)} ex {ex.Message}");
                return new MessageResponse<object> { Message = $"Ocorreu um erro para atualizar a versão do veículo." };
            }
        }

        public MessageResponse<object> DeleteVehicleDetail(int Id)
        {
            try
            {
                var entity = _vehicleDetailRepository.GetById(where: x => x.VehicleDetailId == Id);
                if (entity != null)
                {
                    _vehicleDetailRepository.Delete(Id);
                    return new MessageResponse<object> { Success = true, Message = "Versão do veículo removido com sucesso!" };
                }
                else
                    return new MessageResponse<object> { Message = "Versão do veículo não encontrado!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em {nameof(DeleteVehicleDetail)} vehicleDetailId {Id} ex {ex.Message}");
                return new MessageResponse<object> { Message = $"Ocorreu um erro para remover a versão do veículo." };
            }
        }

        #endregion
    }
}
