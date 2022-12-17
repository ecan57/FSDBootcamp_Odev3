using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev3_API.Models
{
    public abstract class BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UptatedAt { get; set; }
        public int UptatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
