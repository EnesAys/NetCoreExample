using System;  
using System.ComponentModel.DataAnnotations;  
  
namespace vsCodeMovie.Models  
{  
    public class Movie  
    {  
        [Key]
        public int Id { get; set; }  

        [Required]  
        public string Name { get; set; }  

        [Required]  
        [Display(Name="Gösterim Tarihi")]
        public DateTime Impression_Date { get; set; }  

        [EmailAddress]
        public string Mail { get; set; }
    }  
}  