using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotaGrid.model
{
    [Table("MainAttributes")]

    public class Mainattribute
    {
        [Required]
        [ConcurrencyCheck]
        public int MainattributeId { get; set; }
        
        public string MainAttributeType { get; set; }
        public ICollection<Hero> Heroes { get; set; }
    }
}
