﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Polished_Version.Classes
{
    public class ApplicantUser
    {
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string JobTitle { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string Applicant_Photo { get; set; }

        //public ICollection<ApplicantUser> FriendsOf { get; set; } = new List<ApplicantUser>();
        //public ICollection<ApplicantUser> Connected_Applicants { get; set; } = new List<ApplicantUser>();

        //public static List<ApplicantUser> Applicants = new List<ApplicantUser>();
        public ApplicantUser() { }

        public ApplicantUser(int id, string fname, string lname, string email,
            string jobTitle, string phoneNumber, string address, string gender, string password)
        {
            Id = id;
            First_Name = fname;
            Last_Name = lname;
            Email = email;
            JobTitle = jobTitle;
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
            Password = password;
        }

        public override string ToString()
        {
            return $"{First_Name} {Last_Name} - {JobTitle}";
        }

        public static void SetUserDetails(ApplicantUser userProfile, ApplicantUser selectedUser)
        {
            userProfile.First_Name = selectedUser.First_Name;
            userProfile.Last_Name = selectedUser.Last_Name;
            // Assign other properties as needed.
        }
    }
}
