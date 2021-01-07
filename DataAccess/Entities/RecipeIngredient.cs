using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    [Table("RecipeIngredient")]
    public class RecipeIngredient: BaseEntity
    {
        public int IngredientTypeId { get; set; }
        public IngredientType IngredientType { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int MeasurementTypeId { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public decimal Amount { get; set; }
    }
}
