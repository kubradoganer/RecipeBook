using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    [Table("IngredientType")]
    public class IngredientType : BaseEntity
    {
        public string Name { get; set; }
    }
}
