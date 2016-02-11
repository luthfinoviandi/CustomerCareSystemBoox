using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CusCar.Models
{
    public class ComplainDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int ComplainDetailId { get; set; }

        public int ComplainId { get; set; }

        public int UserId { get; set; }

        public string ComplainDetailText { get; set; }
    }
}