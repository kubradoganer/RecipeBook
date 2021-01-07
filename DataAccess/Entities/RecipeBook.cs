using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    [Table("RecipeBook")]
    public class RecipeBook: BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<RecipeBookItem> RecipeBookItems { get; set; }
    }
}
