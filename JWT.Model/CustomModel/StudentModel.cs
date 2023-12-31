﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Model.CustomModel
{
    public class StudentModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }


    public class UpdateStudentModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Contact { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public int? DepartmentId { get; set; }
        [Required]
        public int? CountryId { get; set; }
        [Required]
        public int? StateId { get; set; }
        [Required]
        public int? CityId { get; set; }
        public string? ProfilePic { get; set; }
    
    }

}
