using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreTry.DAL
{
    [Table("Colors")]
   public class Color
    {
        [Key]
        public int ID { get; set; }
        public string ColorName { get; set; }

        //Mapping
        public virtual ICollection<User> Users { get; set; }
    }
}
