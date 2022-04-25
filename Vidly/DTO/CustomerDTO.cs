﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }

        public DateTime? CustomerBirthDate { get; set; }
    }
}