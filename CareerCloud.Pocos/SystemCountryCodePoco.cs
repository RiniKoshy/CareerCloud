﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
    public class SystemCountryCodePoco
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
    }
}
