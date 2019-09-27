using System;
using System.ComponentModel.DataAnnotations;
using CaseStudy.Models;

namespace CaseStudy.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public decimal? AnnualIncome { get; set; }

        public string CardsOffered { get; set; }

    }
}
