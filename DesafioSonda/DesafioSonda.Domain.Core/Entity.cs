using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioSonda.Domain.Core
{
    public class Entity
    {
        [Key]
        public Guid Identificador { get; set; }
    }
}
