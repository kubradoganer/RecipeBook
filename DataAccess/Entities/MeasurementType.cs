using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    [Table("MeasurementType")]
    public class MeasurementType : BaseEntity
    {
        public string Name { get; set; }
    }
}
