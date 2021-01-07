using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataAccess.Entities
{
    [Table("Recipe")]
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public int RecipeTypeId { get; set; }
        public RecipeType RecipeType { get; set; }
        public int CreatedUserId { get; set; }
        public User CreatedUser { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
        public List<RecipeTag> RecipeTags { get; set; }
        [NotMapped]
        public ICollection<Tag> Tags
        {
            get
            {
                return RecipeTags.Select(i => i.Tag).ToList();
            }
            set
            {
                RecipeTags = new List<RecipeTag>();
                foreach (var item in value)
                {
                    RecipeTags.Add(new RecipeTag() { TagId = item.Id });
                }
            }
        }
    }
}
