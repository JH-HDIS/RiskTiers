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
                // Add more DataClassification objects as needed
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
                }
            };

            // Assign the list of DataClassification objects to the DataClassifications property of the UserResponse object
            var model = new UserResponse
            {
                RTCCompletionDate = DateTime.Now,
                IRBApplicationNumber = "123456",
                PIFirstName = "John",
                PILastName = "Doe",
                PIJHED = "jdoe",
                PIEmailAddress = "jdoe@example.com",
                StudyContactFirstName = "Jane",
                StudyContactLastName = "Smith",
                StudyContactJHED = "jsmith",
                StudyContactEmailAddress = "jsmith@example.com",
                InvolvesSensitiveHealthInfo = true,
                NumberOfPeopleOrRecords = 1,
                HumanDataSharingLevel = 0,
                AllActivitiesCoveredByConsent = true,
                DataClassifications = dataClassifications // Assigning the data classifications here
            };

            return View(model);
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
