using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Quote
    {
        [Required(ErrorMessage = "NULL id is forbidden")]
        public int Id { get; set; }
        [Required(ErrorMessage = "NULL Text is forbidden")]
        public string Text { get; set; }
        public string Author { get; set; }
        [Required(ErrorMessage = "NULL DateTime is forbidden")]
        public DateTime Date { get; set; }
    }
}
