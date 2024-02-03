using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocateMyCar.Domain.Entities
{
    public class VehicleRequest : BaseModel
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
    }
}
