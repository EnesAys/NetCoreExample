using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreTry.DAL
{
    [Table("Users")]
   public class User
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        [Phone]
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name ="Favori Renk")]
        public int ColorID { get; set; }
        //Mapping

        [ForeignKey("ColorID")]
        public virtual Color Color { get; set; }
    }
}
