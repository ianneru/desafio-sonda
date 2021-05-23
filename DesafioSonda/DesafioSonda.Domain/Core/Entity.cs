using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioSonda.Domain.Core
{
    public abstract class Entity
    {
        public Entity()
        {
            _errors = new List<string>();
        }
        [Key]
        public Guid Identificador { get; set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();

        public abstract bool isValid();
    }
}
