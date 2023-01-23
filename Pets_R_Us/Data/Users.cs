﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pets_R_Us.Data
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Suburb { get; set; }

        public int PostCode { get; set; }

        public string PetName { get; set; }

        public string PetBreed { get; set; }

        public int PetAge { get; set; }

        public bool PetGender { get; set; }

        [ForeignKey("PetImageTableId")]
        public PetImageTable PetImageTable { get; set; }

        public int PetImageTableId { get; set; }
    }
}
