using System;
using CheckIn.Entitites.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckIn.Entitites.Validation
{
    public class RequiredList : ValidationAttribute
    {
        //public override bool IsValid(object value, ValidationContext validationContext)
        //{
        //    var list = value as IList<Guest>;

        //    foreach (var element in list)
        //    {
        //        if (element.IsActive == true) {
        //            if (string.IsNullOrWhiteSpace(element.FirstName) || string.IsNullOrWhiteSpace(element.LastName))
        //            {
        //                return  ;
        //            }
        //        }
                
        //    }


        //    return true;
        //}
    }
}
