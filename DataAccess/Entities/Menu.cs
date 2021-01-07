using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    [Table("Menu")]
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
