using System;
using System.Collections.Generic;
using RTC.Controllers; // Ensure this namespace is correct

namespace RTC.Logic
{
    public class DataClassifier
    {
        public string ClassifyData(DataClassification data)
        {
            if (data.DataLeavingJHM)
            {
                if (data.PHILDS)
                {
                    return "Tier C";
                }
                else if (data.PHI || data.PII || data.LDS || data.PersonNoPHI || data.Counts)
                {
                    return "Tier A";
                }
                else
                {
                    return "Tier C";
                }
            }
            else
            {
                if (data.LDS || data.PersonNoPHI || data.Counts)
                {
                    return "Tier B";
                }
                else
                {
                    return "Tier C";
                }
            }
        }

        public string GetRiskTier(string toolCategory)
        {
            var riskTierMapping = new Dictionary<string, string>
            {
                { "P", "Preferred" },
                { "J", "Justifiable" },
                { "R", "ReqReview" },
                { "Z", "Forbidden" }
            };

            return riskTierMapping.ContainsKey(toolCategory) ? riskTierMapping[toolCategory] : "Unknown";
        }

        public string DetermineColor(string tier)
        {
            var colorMapping = new Dictionary<string, string>
            {
                { "Tier A", "Green" },
                { "Tier B", "Yellow" },
                { "Tier C", "Red" }
            };

            return colorMapping.ContainsKey(tier) ? colorMapping[tier] : "Unknown";
        }
    }
}
