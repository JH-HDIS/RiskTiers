using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RTC.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace RTC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Create a list of DataClassification objects
            var dataClassifications = new List<DataClassification>
            {
                // P - Preferred Data Storage Options
                new DataClassification 
                { 
                    DataLeavingJHM = true, 
                    PHILDS = false, 
                    PHI = true, 
                    PII = false, 
                    LDS = false, 
                    PersonNoPHI = false, 
                    Counts = false, 
                    SAFERorSAFEDesktop = true, 
                    JHPMAP = false, 
                    JHUPhoenix = false, 
                    JHUOpenSpecimen = false, 
                    JHUQualtrics = false, 
                    JHUACHREDCap = false, 
                    SAFESTOR = false, 
                    DiscoveryHPC = false, 
                    EnterpriseNetworkStorageNAS = false, 
                    ITJHRITManagedAzureAWS = false, 
                    ToolCategory = "P", 
                    ResourceCategory = "Preferred" 
                },

                // J - Justifiable Data Storage Options
                new DataClassification 
                { 
                    DataLeavingJHM = false, 
                    PHILDS = true, 
                    PHI = false, 
                    PII = true, 
                    LDS = true, 
                    PersonNoPHI = true, 
                    Counts = true, 
                    SAFERorSAFEDesktop = false, 
                    JHPMAP = true, 
                    JHUPhoenix = false, 
                    JHUOpenSpecimen = false, 
                    JHUQualtrics = true, 
                    JHUACHREDCap = false, 
                    SAFESTOR = true, 
                    DiscoveryHPC = false, 
                    EnterpriseNetworkStorageNAS = true, 
                    ITJHRITManagedAzureAWS = false, 
                    ToolCategory = "J", 
                    ResourceCategory = "Justifiable" 
                },

                // R - Data Storage Options Requiring Review
                new DataClassification 
                { 
                    DataLeavingJHM = true, 
                    PHILDS = false, 
                    PHI = true, 
                    PII = false, 
                    LDS = false, 
                    PersonNoPHI = false, 
                    Counts = false, 
                    SAFERorSAFEDesktop = false, 
                    JHPMAP = false, 
                    JHUPhoenix = false, 
                    JHUOpenSpecimen = false, 
                    JHUQualtrics = false, 
                    JHUACHREDCap = false, 
                    SAFESTOR = false, 
                    DiscoveryHPC = true, 
                    EnterpriseNetworkStorageNAS = false, 
                    ITJHRITManagedAzureAWS = true, 
                    ToolCategory = "R", 
                    ResourceCategory = "ReqReview" 
                },

                // E - External Data Storage Tools
                new DataClassification 
                { 
                    DataLeavingJHM = false, 
                    PHILDS = true, 
                    PHI = true, 
                    PII = true, 
                    LDS = false, 
                    PersonNoPHI = true, 
                    Counts = true, 
                    SAFERorSAFEDesktop = false, 
                    JHPMAP = false, 
                    JHUPhoenix = true, 
                    JHUOpenSpecimen = false, 
                    JHUQualtrics = true, 
                    JHUACHREDCap = false, 
                    SAFESTOR = false, 
                    DiscoveryHPC = false, 
                    EnterpriseNetworkStorageNAS = false, 
                    ITJHRITManagedAzureAWS = false, 
                    ToolCategory = "E", 
                    ResourceCategory = "External" 
                }
            };

            // Assign the list of DataClassification objects to the DataClassifications property of the UserResponse object
            var model = new UserResponse
            {
                RTCCompletionDate = DateTime.Now,  // Optionally set the default date
                DataClassifications = dataClassifications // Initialize with pre-defined DataClassifications
            };

            return View(model); // Pass the model to the view
        }

        [HttpPost]
        public IActionResult Index(UserResponse model)
        {
            if (ModelState.IsValid)
            {
                // Process the model here, e.g., save it to the database
                // Example: _context.UserResponses.Add(model);
                //          _context.SaveChanges();

                // Redirect to a confirmation page or show a success message
                return RedirectToAction("Success");
            }

            // If the model is not valid, return the same view with the model to display validation errors
            return View(model);
        }

        public IActionResult Success()
        {
            return View(); // Display a success page
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
