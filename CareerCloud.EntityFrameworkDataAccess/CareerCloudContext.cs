using Microsoft.EntityFrameworkCore;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
           = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

        protected override void
            OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(MyLoggerFactory).
            UseSqlServer(@"Data Source=LAPTOP-O97JP1BS\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;");
        }
        
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
        #region ApplicantEducation
            modelBuilder.Entity<ApplicantEducationPoco>()
                .HasOne(entity => entity.ApplicantProfiles)
                .WithMany(c => c.ApplicantEducations);

            modelBuilder.Entity<ApplicantEducationPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

        #endregion ApplicantEducation

        #region ApplicantJobApplication
        
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .HasOne(entity => entity.ApplicantProfiles)
                .WithMany(c => c.ApplicantJobApplications);

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .HasOne(entity => entity.CompanyJobs)
                .WithMany(c => c.ApplicantJobApplications);

            modelBuilder.Entity<ApplicantJobApplicationPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

        #endregion ApplicantJobApplication

        #region ApplicantProfilePoco

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(entity => entity.ApplicantEducations)
                .WithOne(c => c.ApplicantProfiles);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasOne(entity => entity.SecurityLogins)
                .WithMany(c => c.ApplicantProfiles);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(entity => entity.ApplicantResumes)
                .WithOne(c => c.ApplicantProfiles);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(entity => entity.ApplicantJobApplications)
                .WithOne(c => c.ApplicantProfiles);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(entity => entity.ApplicantSkills)
                .WithOne(c => c.ApplicantProfiles);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasOne(entity => entity.SystemCountryCodes)
                .WithMany(c => c.ApplicantProfiles);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(entity => entity.ApplicantWorkHistorys)
                .WithOne(c => c.ApplicantProfiles);

            modelBuilder.Entity<ApplicantProfilePoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion ApplicantJobApplication

            #region ApplicantResume
            modelBuilder.Entity<ApplicantResumePoco>()
                .HasOne(entity => entity.ApplicantProfiles)
                .WithMany(c => c.ApplicantResumes);

            #endregion ApplicantResume

            #region ApplicantSkill
            modelBuilder.Entity<ApplicantSkillPoco>()
                .HasOne(entity => entity.ApplicantProfiles)
                .WithMany(c => c.ApplicantSkills);

            modelBuilder.Entity<ApplicantSkillPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion ApplicantSkill

            #region ApplicantWorkHistory
            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                .HasOne(entity => entity.ApplicantProfiles)
                .WithMany(c => c.ApplicantWorkHistorys);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                .HasOne(entity => entity.SystemCountryCodes)
                .WithMany(c => c.ApplicantWorkHistorys);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion ApplicantWorkHistory

            #region CompanyDescription
            modelBuilder.Entity<CompanyDescriptionPoco>()
                .HasOne(entity => entity.CompanyProfiles)
                .WithMany(c => c.CompanyDescriptions);

            modelBuilder.Entity<CompanyDescriptionPoco>()
                .HasOne(entity => entity.SystemLanguageCodes)
                .WithMany(c => c.CompanyDescriptions);

            modelBuilder.Entity<CompanyDescriptionPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion CompanyDescription

            #region CompanyJobDescription

            modelBuilder.Entity<CompanyJobDescriptionPoco>()
                .HasOne(entity => entity.CompanyJobs)
                .WithMany(c => c.CompanyJobDescriptions);

            modelBuilder.Entity<CompanyJobDescriptionPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion CompanyJobDescription

            #region CompanyJobEducation
            modelBuilder.Entity<CompanyJobEducationPoco>()
                .HasOne(entity => entity.CompanyJobs)
                .WithMany(c => c.CompanyJobEducations);

            modelBuilder.Entity<CompanyJobEducationPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion CompanyJobEducation

            #region CompanyJob
            modelBuilder.Entity<CompanyJobPoco>()
                .HasOne(entity => entity.CompanyProfiles)
                .WithMany(c => c.CompanyJobs);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(entity => entity.CompanyJobEducations)
                .WithOne(c => c.CompanyJobs);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(entity => entity.ApplicantJobApplications)
                .WithOne(c => c.CompanyJobs);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(entity => entity.CompanyJobSkills)
                .WithOne(c => c.CompanyJobs);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(entity => entity.CompanyJobDescriptions)
                .WithOne(c => c.CompanyJobs);

            modelBuilder.Entity<CompanyJobPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion CompanyJob

            #region CompanyJobSkill
            modelBuilder.Entity<CompanyJobSkillPoco>()
                .HasOne(entity => entity.CompanyJobs)
                .WithMany(c => c.CompanyJobSkills);

            modelBuilder.Entity<CompanyJobSkillPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion CompanyJobSkillPoco

            #region CompanyLocation
            modelBuilder.Entity<CompanyLocationPoco>()
                .HasOne(entity => entity.CompanyProfiles)
                .WithMany(c => c.CompanyLocations);

            modelBuilder.Entity<CompanyLocationPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion CompanyLocation

            #region CompanyProfile
            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(entity => entity.CompanyDescriptions)
                .WithOne(c => c.CompanyProfiles);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(entity => entity.CompanyJobs)
                .WithOne(c => c.CompanyProfiles);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(entity => entity.CompanyLocations)
                .WithOne(c => c.CompanyProfiles);

            modelBuilder.Entity<CompanyProfilePoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion CompanyProfile

            #region SecurityLogin
            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(entity => entity.ApplicantProfiles)
                .WithOne(c => c.SecurityLogins);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(entity => entity.SecurityLoginsRoles)
                .WithOne(c => c.SecurityLogins);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(entity => entity.SecurityLoginsLogs)
                .WithOne(c => c.SecurityLogins);

            modelBuilder.Entity<SecurityLoginPoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());

            #endregion SecurityLogin

            #region SecurityLoginsLog
            modelBuilder.Entity<SecurityLoginsLogPoco>()
                .HasOne(entity => entity.SecurityLogins)
                .WithMany(c => c.SecurityLoginsLogs);

            #endregion SecurityLoginsLog

            #region SecurityLoginsRole
            modelBuilder.Entity<SecurityLoginsRolePoco>()
                .HasOne(entity => entity.SecurityLogins)
                .WithMany(c => c.SecurityLoginsRoles);

            modelBuilder.Entity<SecurityLoginsRolePoco>()
                .HasOne(entity => entity.SecurityRoles)
                .WithMany(c => c.SecurityLoginsRoles);

            modelBuilder.Entity<SecurityLoginsRolePoco>(
                entity => entity.Property(
                  property => property.TimeStamp).IsRowVersion().IsConcurrencyToken());
            #endregion SecurityLoginsRole

            #region SecurityRole
            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(entity => entity.SecurityLoginsRoles)
                .WithOne(c => c.SecurityRoles);
            #endregion SecurityRole

            #region SystemCountryCode
            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(entity => entity.ApplicantProfiles)
                .WithOne(c => c.SystemCountryCodes);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(entity => entity.ApplicantWorkHistorys)
                .WithOne(c => c.SystemCountryCodes);

            #endregion SystemCountryCode

            #region SystemLanguageCode
            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(entity => entity.CompanyDescriptions)
                .WithOne(c => c.SystemLanguageCodes);

           #endregion SystemLanguageCode


            base.OnModelCreating(modelBuilder);
        
        }


    }
}
