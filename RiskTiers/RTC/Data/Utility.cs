using RTC.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace ClinicalResearchApp.Data
{
    public class Utility
    {
        
        public Utility()
        {
        }

        public static string CalculateTier(string[,] array, string dataLeavingJHM, string numRecords, string consentYN, string humanDataSharingLevel, string involvesSensitiveHealthInfo, string dataSharingAgreement)
        {
            
            string toolType = "";
            string rowId = "";
            string colPos = "";
            string dataLeaving = dataLeavingJHM;
            string numRec = numRecords;
            string consent = consentYN;
            string hDataSharingLevel = humanDataSharingLevel;
            string involvesSensitiveHealth = involvesSensitiveHealthInfo;
            string dataSharing = dataSharingAgreement;
            Console.WriteLine($"The dataLeavingJHM is: {dataLeaving}"); 
            Console.WriteLine($"The involvesSensitiveHealthInfo is: {involvesSensitiveHealth}");
            Console.WriteLine($"The numRecords is: {numRec}");
            Console.WriteLine($"The consentYN is: {consent}");
            Console.WriteLine($"The humanDataSharingLevel is: {hDataSharingLevel}");   

            List<string> tiers = new List<string>();

            int arySize = array.GetLength(0);
            // Initialize the variable to track the lowest score.
            // Start with a high value to ensure any actual row sum will be lower.
            String lowestTier = "";

            // Loop over each row
            for (int i = 0; i < arySize; i++)
            {
                
                // Loop over each element in the row
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0) {
                        toolType = array[i, j].Substring(2,1); // Add the element to the row sum
                        rowId = array[i, j];
                        Console.WriteLine($"The toolType is: {toolType}");
                    }
                    if (j == 1) {
                        colPos = array[i, j]; // Add the element to the row sum
                        Console.WriteLine($"The colPos is: {toolType}");
                    
                        // Calculate Tier for the row
                        if (toolType == "P")
                        {   if (dataLeaving == "N") 
                            {
                                tiers.Add("Tier A");
                            }
                            else
                            {
                                if (colPos == "1" || colPos == "2") 
                                {
                                    tiers.Add("Tier C");
                                }
                                else
                                {
                                    if (numRec == "2") 
                                    {
                                        tiers.Add("Tier C");
                                    }
                                    else
                                    {
                                        tiers.Add("Tier B");
                                    }
                                }
                            }
                        }

                        if (toolType == "J")
                        {   if ((colPos ==  "C4" || colPos == "C5" || colPos == "C6") && involvesSensitiveHealth == "N")
                            {
                            tiers.Add("Tier A");
                            }
                            else
                            {
                            if (consent == "Y") 
                                {
                                tiers.Add("Tier A");
                                }
                            else
                                {
                                    if (colPos == "C1" || colPos == "C2")
                                    {
                                        if (numRec == "0") {
                                            if (dataLeaving == "N") 
                                            {
                                                tiers.Add("Tier B");
                                            }
                                            else
                                            {
                                                tiers.Add("Tier C");
                                            }
                                        }
                                        else
                                        {
                                            tiers.Add("Tier C");
                                        }
                                    }
                                }
                            }
                        }
                        if (toolType == "R")
                        {   
                            if ((colPos ==  "C4" || colPos == "C5" || colPos == "C6") && involvesSensitiveHealth == "N")
                            {
                            tiers.Add("Tier B");
                            }
                            else
                            {
                                if (rowId == "2.R.2") {
                                    tiers.Add("Tier X");
                                }
                                else {
                                    tiers.Add("Tier C");
                                }
                            }
                        }
                        if (toolType == "E")
                        {   
                            if (dataSharing == "N")
                            {
                                tiers.Add("Tier C");
                            }
                        }
                    }
                }
            } // End of loop over each row


            // Loop over each row sum to find the lowest score
            for (int i = 0; i < tiers.Count; i++)
                {
                    if ((tiers[i] == "Tier X") && (lowestTier == "Tier C" || lowestTier == "Tier B" || lowestTier == "Tier A")) {
                        lowestTier = "Tier X";
                    }
                    if ((tiers[i] == "Tier C") && (lowestTier == "Tier B" || lowestTier == "Tier A")) {
                        lowestTier = "Tier C";
                    }
                    if ((tiers[i] == "Tier B") && (lowestTier == "Tier A")) {
                        lowestTier = "Tier B";
                    }
                    if ((tiers[i] == "Tier A") && (lowestTier == "")) {
                        lowestTier = "Tier A";
                    }
                }
            if (lowestTier == "") {
                lowestTier = "Not enough info to calculate Tier";
            }
            return lowestTier; // Return the lowest score found
        } 
    }

}
