using System;

namespace CRM.Application
{
    public class EntityViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
