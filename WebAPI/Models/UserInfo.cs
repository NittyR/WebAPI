using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("tUserInfo")]
    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }
        public string Name_Eng { get; set; }
        public string Surname_Eng { get; set; }
        public int CompanyTaxID { get; set; }
        public string CompanyName { get; set; }
        public string Address_Eng { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
