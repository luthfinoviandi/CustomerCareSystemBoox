using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CusCar.Models
{
    public class ComplainStatusMaster
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int ComplainStatusId { get; set; }

        public string ComplainStatusText { get; set; }
    }
}