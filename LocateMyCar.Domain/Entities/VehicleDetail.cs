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
    [Table("VehicleDetails")]
    public class VehicleDetail: BaseModel
    {
        [Key]
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

        public int VehicleId { get; set; } 
        public  Vehicle Vehicle { get; set; }
    }
}
