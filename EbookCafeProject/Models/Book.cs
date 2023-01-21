using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace EbookCafeProject.Models
{
    public class Book
    {
        public int BookID { get; set; }

        //[StringLength(60, MinimumLength = 3)]
        public string BookTitle { get; set; }
        public string BookWriter { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        //[Required]
        //[StringLength(30)]
        public string BookCategory { get; set; }

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal BookPrice { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        //[StringLength(5)] 
        public string Discount { get; set; }
        //public string BookDiscount { get; set; }

    }

    //public class BookDBContext : DbContext
    //{
    //    public DbSet<Book> Books { get; set; }
    //}

}