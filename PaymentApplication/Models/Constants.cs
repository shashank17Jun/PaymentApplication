using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayApp.Models
{
    public class Constants
    {

    }

    public enum ServiceCodes
    {
        MobileRecharge = 1,
        DTHRecharge = 2,
        Electricity = 3,
        CreditCard = 4,
        PostPaid = 5,
        Landline = 6,
        Broadband = 7,
        Gas = 8,
        Water = 9,
        Datacard = 10,
        Insurance = 11,
        MunicipalTax = 12
    }

    public enum PaymentModes
    {
        DebitCard = 1,
        CreditCard = 2,
        InternetBanking = 3,
        BHIMUPI = 4
    }
}