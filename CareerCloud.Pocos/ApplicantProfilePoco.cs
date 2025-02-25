﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CareerCloud.Pocos
{[Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }
        [Column("Current_Salary")]
        public decimal? CurrentSalary { get; set; }
        [Column("Current_Rate")]
        public decimal? CurrentRate { get; set; }
        public string Currency { get; set; }
        [Column("Country_Code")]
        public string Country { get; set; }
        [Column("State_Province_Code")]
        public string Province { get; set; }
        [Column("Street_Address")]
        public string Street { get; set; }
        [Column("City_Town")]
        public string City { get; set; }
        [Column("Zip_Postal_Code")]
        public string PostalCode { get; set; }
        [Column("Time_Stamp")]
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        public ICollection <ApplicantEducationPoco> ApplicantEducations { get; set; }
        [ForeignKey("Login")]
        public virtual SecurityLoginPoco SecurityLogins { get; set; }
        public ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        public ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        [ForeignKey("Country")]
        public virtual SystemCountryCodePoco SystemCountryCodes { get; set; }
       
    }
}
