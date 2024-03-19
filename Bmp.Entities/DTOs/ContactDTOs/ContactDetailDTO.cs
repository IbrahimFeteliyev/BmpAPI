﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.ContactDTOs
{
    public class ContactDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
