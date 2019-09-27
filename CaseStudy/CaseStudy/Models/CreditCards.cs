using System;
using System.ComponentModel.DataAnnotations;
using CaseStudy.Models;

namespace CaseStudy.Models
{
    public class CreditCards
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int APR { get; set; }

        public Decimal IncomeNeeded { get; set; }

        public string TextDescription { get; set; }

        public string ImageURL { get; set; }

    }
}

