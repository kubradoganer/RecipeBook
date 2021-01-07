using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    [Table("RecipeTag")]
    public class RecipeTag : BaseEntity
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
