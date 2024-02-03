using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocateMyCar.Domain.Entities
{
    public class VehicleDetailRequest : BaseModel
    {
        public int VehicleDetailId { get; set; }

        /// <summary>
        /// Ano
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Potência
        /// </summary>
        public decimal VehiclePower { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Quantidade de portas
        /// </summary>
        public int VehicleDoors { get; set; }

        /// <summary>
        /// Imagem do veiculo
        /// </summary>
        public string ImageURL { get; set; }

        /// <summary>
        /// FK para Vehicle
        /// </summary>
        public int VehicleId { get; set; }
    }
}
