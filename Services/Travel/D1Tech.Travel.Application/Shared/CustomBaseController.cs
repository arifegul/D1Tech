﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace D1Tech.Travel.Application.Shared
{
	public class CustomBaseController : ControllerBase
    {
		public ActionResult CreateActionResultInstance<T>(Response<T> response)
		{
			return new ObjectResult(response)
			{
				StatusCode = response.StatusCode
			};
		}
	}
}
