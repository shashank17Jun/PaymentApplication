using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace PayApp.Models{

    public class ServicesContext : DbContext
    {
        public ServicesContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Services> PaymentServices { get; set; }
        public DbSet<MobileCircles> MobileCircleList { get; set; }
        public DbSet<MobileOperators> MobileOperatorList { get; set; }
    }

    [Table("Services")]
    public class Services
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public decimal ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string ServiceLogo { get; set; }
        public bool Status { get; set; }
        public string DisplayName { get; set; }
    }

    [Table("MobileCircles")]
    public class MobileCircles
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public decimal MobileCircleID { get; set; }
        public string MobileCircle { get; set; }
    }

    [Table("MobileOperators")]
    public class MobileOperators
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public decimal OperatorID { get; set; }
        public string OperatorName { get; set; }
    }

    public class MobileRechargeModel {

        public MobileRechargeModel()
        {
           
        }

        [Required]
        [StringLength(10, ErrorMessage = "Mobile Number should be of 10 character digit", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage="Please select Mobile Operator")]
        [Display(Name = "Mobile Operator")]
        public string MobileOperator { get; set; }

        //public IEnumerable<MobileOperators> MobileOperatorList { get; set; }


        [Required(ErrorMessage = "Please select Mobile Circle")]
        [Display(Name = "Mobile Circle")]
        public string MobileCircle { get; set; }

        //public IEnumerable<MobileCircles> MobileCircleList { get; set; }

        [Required]       
        [DataType(DataType.Currency)]
        [Display(Name = "Amount")]
        public string Amount { get; set; }
    }
}