using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyASPCoreProject.Models
{
    public class Student
    {
        public int Nim { get; set; }

        [Required]
        [StringLength(25)]
        public string Nama { get; set; }

        [Required]
        [Display(Name ="Address")]
        public string Alamat { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telp { get; set; }

        [Range(1,150)]
        public int Umur { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"(http://|)(www\.)?([^\.]+)\.(\w{2}|(com|net|org|edu|int|mil|gov|arpa|biz|aero|name|coop|info|pro|museum))$",ErrorMessage = "Format website not match")]
        public string Website { get; set; }
    }
}
