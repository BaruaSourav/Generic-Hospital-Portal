using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HMSv2.Models.ViewModel
{
    public class Prescription
    {
        [Key]
        public int DiagnosisID { get; set; }
        public string Symptoms { get; set; }
        public string DiagnosisProvided {get;set;}
        public DateTime DateOfDiagnosis { get; set; }
        public string FUrequired { get; set; }
        public DateTime FUdate { get; set; }
        public int AdminBy { get; set; }
        public int Bill { get; set; }
        public string Mode { get; set; }
        public string CardNo { get; set; }


    }
}