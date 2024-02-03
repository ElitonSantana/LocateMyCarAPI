using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocateMyCar.Domain.Entities
{
    public class MessageResponse<T> where T : class
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public T Entity { get; set; }
    }
}
