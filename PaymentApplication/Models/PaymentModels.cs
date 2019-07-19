using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace PayApp.Models 
{

    public class PaymentContext : DbContext
    {
        public PaymentContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<PaymentMethods> PaymentMethods { get; set; }
    }

    [Table("PaymentMethods")]
    public class PaymentMethods
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public decimal PaymentModeId { get; set; }
        public string PaymentMethod { get; set; }
    }

    public class DebitCardModel
    {
        [Required]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Required]        
        [Display(Name = "Expiry Month")]
        public string ExpriryMonth { get; set; }

        [Required]
        [Display(Name = "Expiry Year")]
        public string ExpiryYear { get; set; }

        [Required]        
        [Display(Name = "CVV")]
        public int CVV { get; set; }

        [Required]
        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; }

        public string Amount { get; set; }
    }
}