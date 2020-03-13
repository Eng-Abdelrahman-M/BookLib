using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLib.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public String AuthorName { get; set; }

        [Required]
        [StringLength(255)]
        public String BookName { get; set; }

        [Required]
        public byte AllNumber { get; set; }

        [Required]
        public byte AvailableNumber{ get; set; }

    }
}