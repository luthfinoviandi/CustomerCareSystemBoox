using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CusCar.Models
{
    public class Complain
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ComplainId { get; set; }

        public int UserId { get; set; }

        public string ComplainSubject { get; set; }

        public string ComplainText { get; set; }

        public int ComplainStatusId { get; set; }
    }
}