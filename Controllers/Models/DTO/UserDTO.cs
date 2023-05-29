using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controller.Models.DTO
{
    public class UserDTO
    {

        public string Username { get; set; }

        public string Password { get; set; }

    }
}

