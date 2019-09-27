using System;
using System.ComponentModel.DataAnnotations;
using CaseStudy.Models;

namespace CaseStudy.Models
{
    public class ResultsModel
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CreditCards[] CardsAvailable { get; set; }

    
    }
}
