﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigLibrary.Models
{
    public class Storage
    {
        [Key]
        public Guid Id { get; set; }  = Guid.NewGuid();
        [Required]  
        public string Name { get; set; } = string.Empty;
        [Required]
        public  string Type { get; set; } = "string";   // aksi belirtilmezse type str
        [Required]
        public string Value { get; set; } = string.Empty; // value str tutulacak. getValue yapıldığında Type'ına göre convert edilecek

        public bool IsActive { get; set; } = true; 

        [Required]
        public string ApplicationName { get; set; } = string.Empty;

        public DateTime LastModified { get; set; } = DateTime.Now;

        //todo :zamanın kalır user eklersen ModifiedBy eklersin
    } 
}
