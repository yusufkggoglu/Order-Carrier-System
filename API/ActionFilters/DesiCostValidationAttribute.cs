using Entities.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Entities.Models;
using AutoMapper.Configuration;

namespace API.ActionFilters
{
    public class DesiCostValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Dto
            var carrier = (BaseCarrierConfigurationDto)context.ActionArguments;

            if (carrier.CarrierMinDesi >= carrier.CarrierMaxDesi)
            {
               context.Result= new BadRequestObjectResult("Max Desi Cost must be greater than Min Desi Cost.");
            }
        }
    }
}
