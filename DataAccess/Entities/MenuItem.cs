using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    [Table("MenuItem")]
    public class MenuItem : BaseEntity
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
