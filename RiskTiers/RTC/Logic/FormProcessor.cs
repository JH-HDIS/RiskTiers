using System;
using System.Collections.Generic;
using RTC.Controllers; // Ensure this namespace is correct
using RTC.Logic; // Ensure this namespace is correct

namespace RTC.Logic
{
    public class FormProcessor
    {
        public void HandleFormSubmission(Dictionary<string, object> formData)
        {
            var data = ExtractRelevantData(formData);
            var classifier = new DataClassifier();

            var tier = classifier.ClassifyData(data);
            var riskTier = classifier.GetRiskTier(data.ToolCategory ?? "DefaultCategory");
            var color = classifier.DetermineColor(tier);

            SaveClassificationResult(tier, riskTier, color);
        }

        private DataClassification ExtractRelevantData(Dictionary<string, object> formData)
        {
            return new DataClassification
            {
                DataLeavingJHM = formData.ContainsKey("data_leaving_jhm") && Convert.ToBoolean(formData["data_leaving_jhm"]),
                PHILDS = formData.ContainsKey("phi_lds") && Convert.ToBoolean(formData["phi_lds"]),
                PHI = formData.ContainsKey("phi") && Convert.ToBoolean(formData["phi"]),
                PII = formData.ContainsKey("pii") && Convert.ToBoolean(formData["pii"]),
                LDS = formData.ContainsKey("lds") && Convert.ToBoolean(formData["lds"]),
                PersonNoPHI = formData.ContainsKey("person_no_phi") && Convert.ToBoolean(formData["person_no_phi"]),
                Counts = formData.ContainsKey("counts") && Convert.ToBoolean(formData["counts"]),
                ToolCategory = formData.ContainsKey("tool_category") ? formData["tool_category"]?.ToString() ?? "DefaultCategory" : "DefaultCategory",
                ResourceCategory = formData.ContainsKey("resource_category") ? formData["resource_category"]?.ToString() ?? string.Empty : string.Empty
            };
        }

        private void SaveClassificationResult(string tier, string riskTier, string color)
        {
            // Save the result to the database or any storage
            Console.WriteLine($"Saved: Tier - {tier}, Risk Tier - {riskTier}, Color - {color}");
        }
    }
}
