using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTEngine
{
    public abstract class ExtendedController : ControllerBase
    {
        protected void AddModelError(ArgumentException ex)
        {
            var message = ex.GetMessageWithoutParamName();

            if (string.IsNullOrEmpty(ex.ParamName))
            {
                ModelState.AddModelError("erro", ex.Message);
            }
            else
            {
                ModelState.AddModelError(ex.ParamName, message);
            }
        }

        protected void AddModelError(ApplicationException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
        }

        protected void AddModelError(Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
        }
    }
}
