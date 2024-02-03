using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LocateMyCar.Domain.Entities
{
    [Table("Vehicles")]
    public class Vehicle : BaseModel
    {
        public int VehicleId { get; set; }
        /// <summary>
        /// Marca
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Modelo
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Tipo de veiculo
        /// </summary>
        public EVehicleType Type { get; set; }

        /// <summary>
        /// Imagem do veiculo
        /// </summary>
        public string ImageURL { get; set; }


        /// <summary>
        /// Itens do veiculo
        /// Ano, Preço, Potência, Quantidade de portas e etc... 
        /// </summary>
        public ICollection<VehicleDetail> VehicleDetails { get; set; }
    }

    public enum EVehicleType
    {
        Car = 1,
        Motorcycle = 2,
        Truck = 3,
        Bus = 4,
        Bicycle = 5
    }
}
