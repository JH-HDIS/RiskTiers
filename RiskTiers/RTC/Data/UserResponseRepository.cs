using RTC.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;


namespace RTC.Data
{
    public class ResearchRepository
    {
        private readonly string _connectionString;

        public ResearchRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserResponse> GetResearchData(string userRole)
        {
            List<UserResponse> researchDataList = new();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_slct_Risk_Tier_Calculation_ALL", conn)) // Assume the stored procedure is GetResearchData
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@UserRole", userRole);
                    
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserResponse researchData = new()
                            {
                                Id = reader["IRB_Application_Number"].ToString(),
                                StudyName = reader["IRB_Application_Number"].ToString() + " Study Name",
                                PrincipalInvestigator = reader["PI_Last_Name"].ToString() + ", " + reader["PI_First_Name"].ToString(),
                                Status = reader["tier_calculator_completed_yn?"].ToString(),
                                StartDate = reader["RTC_Completion_Date"].ToString(),
                                //EndDate = (DateTime)reader["EndDate"]
                            };
                            researchDataList.Add(researchData);
                        }
                    }
                }
            }
            return researchDataList;
        }

        public UserResponse GetResearchDataDetails(string irbNum)
        {
            UserResponse researchData = new UserResponse();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_slct_Risk_Tier_Calculation", conn)) // Assume the stored procedure is GetResearchDetailsById
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IRB_Application_Number", "IRB00257227");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                           {
                            researchData = new UserResponse
                            {
                                Id = (string)reader["IRB_Application_Number"],
                                //StudyName = reader["IRB_Application_Number"].ToString() + " Study Name",
                                //PrincipalInvestigator = reader["PI_Last_Name"].ToString() + ", " + reader["PI_First_Name"].ToString(),
                                PIFirstName = reader["PI_First_Name"].ToString(),
                                PILastName = reader["PI_Last_Name"].ToString(),
                                //Status = reader["tier_calculator_completed_yn?"].ToString(),
                                //StartDate = (DateTime)reader["RTC_Completion_Date"],
                                //EndDate = (DateTime)reader["RTC_Completion_Date"],
                                //PPIJHED = reader["PI_JHED"].ToString(),
                                //PIEmailAddress = reader["PI_Email_Address"].ToString(),
                                //StudyContactFirstName = reader["Study_Contact_First_Name"].ToString(),
                                //StudyContactLastName = reader["Study_Contact_Last_name"].ToString(),
                                //StudyContactJHED = reader["Study_Contact_JHED"].ToString(),
                                //StudyContactEmailAddress = reader["Study_Contact_Email_Address"].ToString(),
                                //InvolvesSensitiveHealthInfo = reader["sensitive_health_information_required_yn?"].ToString(),
                                //Expected_Enroll_Count = reader["expected_enrollee_count"].ToString(),
                                //AllActivitiesCoveredByConsent = reader["covered_by_consent_yn?"].ToString()

                            };
                        }
                    }
                }
            }
            return researchData ?? new UserResponse();

        }

        public void UpdateResearchData(UserResponse data)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_upsert_Risk_Tier_Calculation", conn)) // Assume the stored procedure is UpdateResearchData
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IRB_Application_Number", data.Id);
                    cmd.Parameters.AddWithValue("@PI_First_Name", data.PIFirstName);
                    cmd.Parameters.AddWithValue("@PI_Last_Name", data.PILastName);
                    cmd.Parameters.AddWithValue("@PI_JHED", data.PIJHED);
                    cmd.Parameters.AddWithValue("@PI_Email_Address", data.PIEmailAddress);
                    cmd.Parameters.AddWithValue("@Study_Contact_First_Name", data.StudyContactFirstName);
                    cmd.Parameters.AddWithValue("@Study_Contact_JHED", data.StudyContactJHED);
                    cmd.Parameters.AddWithValue("@Study_Contact_Last_Name", data.StudyContactLastName);
                    cmd.Parameters.AddWithValue("@Study_contact_Email_Address", data.StudyContactEmailAddress);
                    cmd.Parameters.AddWithValue("@sensitive_health_information_required_yn", data.InvolvesSensitiveHealthInfo);
                    cmd.Parameters.AddWithValue("@expected_enrollee_count", data.NumberOfPeopleOrRecords);
                    cmd.Parameters.AddWithValue("@covered_by_consent_yn", data.AllActivitiesCoveredByConsent);
                    cmd.Parameters.AddWithValue("@tier_calculator_completed_yn", "Y");    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}