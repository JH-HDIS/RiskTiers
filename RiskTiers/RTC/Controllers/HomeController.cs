using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RTC.Models; // Ensure this references your model

namespace RTC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Return a new UserResponse model for the initial form
            var model = new UserResponse
            {
                RTCCompletionDate = DateTime.Now, // Set default value for completion date
                DataClassifications = InitializeDataClassifications() // Initialize with pre-defined DataClassifications
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(UserResponse model, string SAFERorSAFEDesktop, string JHPMAP, string JHUOpenSpecimen, string JHUQualtrics, 
                                   string JHUACHREDCap, string SAFESTOR, string DiscoveryHPC, string EnterpriseNetworkStorageNAS, 
                                   string ITJHRITManagedAzureAWS, string OneDrive, string LocalComputer, string NonJHU_REDCap, 
                                   string NonJHUSystem, string DepartmentServer, string OtherComputers, string USB, string JHPCE, 
                                   string JHUARCH, string OtherSolutions)
        {
            // Calculate risk levels based on submitted data
            string riskLevel = CalculateRiskLevel(SAFERorSAFEDesktop, JHPMAP, JHUOpenSpecimen, JHUQualtrics, JHUACHREDCap, SAFESTOR,
                                                  DiscoveryHPC, EnterpriseNetworkStorageNAS, ITJHRITManagedAzureAWS, OneDrive, 
                                                  LocalComputer, NonJHU_REDCap, NonJHUSystem, DepartmentServer, OtherComputers, 
                                                  USB, JHPCE, JHUARCH, OtherSolutions);

            // Pass the risk level back to the view using ViewBag
            ViewBag.RiskLevel = riskLevel;

            // Ensure that the model contains all the necessary data for the entire table
            model.DataClassifications = InitializeDataClassifications();

            // Return the model back to the view to maintain state
            return View(model);
        }

        private string CalculateRiskLevel(string SAFERorSAFEDesktop, string JHPMAP, string JHUOpenSpecimen, string JHUQualtrics,
                                          string JHUACHREDCap, string SAFESTOR, string DiscoveryHPC, string EnterpriseNetworkStorageNAS, 
                                          string ITJHRITManagedAzureAWS, string OneDrive, string LocalComputer, string NonJHU_REDCap, 
                                          string NonJHUSystem, string DepartmentServer, string OtherComputers, string USB, string JHPCE, 
                                          string JHUARCH, string OtherSolutions)
        {
            // Placeholder logic to calculate the risk level based on the selected values
            if (new[] { SAFERorSAFEDesktop, JHPMAP, JHUOpenSpecimen, JHUQualtrics, JHUACHREDCap }.Contains("TextPHI"))
            {
                return "Preferred";
            }
            else if (new[] { ITJHRITManagedAzureAWS, DiscoveryHPC, JHPCE }.Contains("PHIgtLDS"))
            {
                return "Justifiable";
            }
            else if (new[] { DepartmentServer, OtherComputers, USB, JHUARCH }.Contains("LDS"))
            {
                return "ReqReview";
            }
            else if (new[] { NonJHU_REDCap, NonJHUSystem, OtherSolutions }.Contains("NotUsed"))
            {
                return "External";
            }
            else
            {
                return "Need more information";
            }
        }

        // Initialize DataClassifications for the entire form
        private List<DataClassification> InitializeDataClassifications()
        {
            return new List<DataClassification>
            {
                new DataClassification { Option = "2.P.1", Description = "SAFER or SAFE Desktop" },
                new DataClassification { Option = "2.P.2", Description = "JH PMAP" },
                new DataClassification { Option = "2.P.3", Description = "JHU OpenSpecimen" },
                new DataClassification { Option = "2.P.4", Description = "JHU Qualtrics" },
                new DataClassification { Option = "2.P.5", Description = "JHU/ACH REDCap" },
                new DataClassification { Option = "2.P.6", Description = "SAFESTOR" },
                new DataClassification { Option = "2.P.7", Description = "Discovery HPC" },
                new DataClassification { Option = "2.P.8", Description = "Enterprise Network Storage (NAS)" },
                new DataClassification { Option = "2.P.9", Description = "IT@JH RIT-managed Azure or AWS subscription" },
                new DataClassification { Option = "2.J.1", Description = "JH OneDrive / SharePoint / Teams" },
                new DataClassification { Option = "2.J.2", Description = "Local Computer (both JH owned and IT@JH managed)" },
                new DataClassification { Option = "2.E.1", Description = "Non-JHU REDCap" },
                new DataClassification { Option = "2.E.2", Description = "Non-JHU System (e.g., Velos, Medidata RAVE, etc.)" },
                new DataClassification { Option = "2.R.1", Description = "Department Server (not managed by IT@JH)" },
                new DataClassification { Option = "2.R.2", Description = "Other computer(s) or Device(s) owned and managed by study team members" },
                new DataClassification { Option = "2.R.3", Description = "USB/Portable Data Storage Device" },
                new DataClassification { Option = "2.R.4", Description = "Joint High Performance Computing Exchange (JHPCE)" },
                new DataClassification { Option = "2.R.5", Description = "JHU ARCH (formerly MARCC)" },
                new DataClassification { Option = "2.R.6", Description = "Other solution not managed by IT@JH, such as cloud storage (Box, Dropbox, etc.)" }
            };
        }
    }
}