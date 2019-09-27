using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using CaseStudy.Data;

namespace CaseStudy.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CardContext(
                serviceProvider.GetRequiredService<DbContextOptions<CardContext>>()))
            {
                // Look for any cards.
                if (context.CreditCards.Any())
                {
                    return;   // DB has been seeded
                }

                context.CreditCards.AddRange(
                    new CreditCards
                    {
                        Name = "BarclayCard",
                        APR = 15,
                        IncomeNeeded = 30000.00M,
                        TextDescription = "A flexible card you can use for balance transfers and purchases.",
                        ImageURL = "https://www.barclays.co.uk/content/dam/lifestyle-images/personal/credit-cards/ccard_forward_16_9.full.high_quality.png"

                    },

                    new CreditCards
                    {
                        Name = "Vanquis",
                        APR = 24,
                        IncomeNeeded = 0.00M,
                        TextDescription = "Start building your credit rating today!",
                        ImageURL = "https://www.payvanquis.co.uk/Content/Blue_Visual_rgb.png"
                    },

                    new CreditCards
                    {
                        Name = "Premium",
                        APR = 14,
                        IncomeNeeded = 40000.00M,
                        TextDescription = "The Premium choice!",
                        ImageURL = "https://www.barclays.co.uk/content/dam/lifestyle-images/personal/credit-cards/ccard_forward_16_9.full.high_quality.png"
                    },

                    new CreditCards
                    {
                        Name = "SuperPremium",
                        APR = 15,
                        IncomeNeeded = 60000.00M,
                        TextDescription = "The more Premium choice!",
                        ImageURL = "https://www.barclays.co.uk/content/dam/lifestyle-images/personal/credit-cards/ccard_forward_16_9.full.high_quality.png"
                    },

                    new CreditCards
                    {
                        Name = "UltraPremium",
                        APR = 15,
                        IncomeNeeded = 100000.00M,
                        TextDescription = "The most Premium choice!",
                        ImageURL = "https://www.barclays.co.uk/content/dam/lifestyle-images/personal/credit-cards/ccard_forward_16_9.full.high_quality.png"
                    }


                );
                context.SaveChanges();
            }
        }



    }
}
