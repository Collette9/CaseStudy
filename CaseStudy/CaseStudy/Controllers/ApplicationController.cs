using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaseStudy.Data;
using CaseStudy.Models;

namespace CaseStudy.Controllers
{

    public class ApplicationController : Controller
    {

        private readonly AppUserContext _context;
        private readonly CardContext _contextCard;

        public ApplicationController(AppUserContext context, CardContext contextCard)
        {
            _context = context;
            _contextCard = contextCard;
        }



        public IActionResult Index()
        {
            return View();
        }


        // GET: Application/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Application/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,AnnualIncome")] Users users)
        {
            
          
            // Checking if the user is above 18 years of age
            if ((DateTime.Now.Year - users.DateOfBirth.Year) < 18)
            {
                return RedirectToAction("Denied");
            }


            // checking if the fields on the form have actually been filled out, returning the user to the previous page if it has not
            if (ModelState.IsValid && users.FirstName != null && users.LastName != null && users.DateOfBirth != null && users.AnnualIncome != null)
            {
                {

                    _context.Add(users);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Results", new { id = users.Id });
                }

            }



            return View(users);
        }


        // GET: Application/Results/5
        public async Task<IActionResult> Results(int? id)
        {
            //containting the variables needed to display results
            

            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);

            if (users == null)
            {
                return NotFound();
            }

            //creates a resultsmodel model to hold all the data needed for displaying results
            ResultsModel resultsmodel = new ResultsModel();

            resultsmodel.FirstName = users.FirstName;
            resultsmodel.LastName = users.LastName;


            // ordered list of credit cards by their APR rates
            var Items = await _contextCard.CreditCards.OrderBy(m => m.APR).ToListAsync();


            // removing credit cards the user is not eligable for
            Items.RemoveAll(t => t.IncomeNeeded > users.AnnualIncome);

            
            //Adding cards that the user has been offered to their database entry
            for (int i = 0; i < Items.Count; i++)
            {
                users.CardsOffered = users.CardsOffered + (Items[i].Name) + ",";
            }

            // saving changes in the user database
            await _context.SaveChangesAsync();

            resultsmodel.CardsAvailable = Items.ToArray();

          

            return View(resultsmodel);
        }



        public async Task<IActionResult> CardViewAsync(int id)
        {

            var CardToView = await _contextCard.CreditCards.FirstOrDefaultAsync(m => m.Id == id);

            return View(CardToView);
        }


    }
}