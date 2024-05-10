using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Domain.Entities
{
    public class Skill(string description) : BaseEntity
    {
        public string Description { get; private set; } = description;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
