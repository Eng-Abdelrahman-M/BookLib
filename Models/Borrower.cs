using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLib.Models
{
    public class Borrower
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}