using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    [Table("RecipeType")]
    public class RecipeType: BaseEntity
    {
        public string Name { get; set; }
    }
}
