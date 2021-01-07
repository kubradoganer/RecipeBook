using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    [Table("RecipeBookItem")]
    public class RecipeBookItem : BaseEntity
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeBookId { get; set; }
        public RecipeBook RecipeBook { get; set; }

    }
}
