using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using TDD.CleanArchitecture.Exceptions;
using TDD.CleanArchitecture.Service;

namespace TDD.CleanArchitecture.Controllers
{
    public class ScholarshipController : Controller
    {
        IApplScholarshipService _service;

        public ScholarshipController(IApplScholarshipService service)
        {
            this._service = service;
        }


        public IActionResult Apply(ApplicationForm applicationForm)
        {
            try
            {
                _service.Apply(applicationForm);
            }
            catch (StudentNotExistException e)
            {
                var content = Content("987");
                content.StatusCode = StatusCodes.Status400BadRequest;
                return content;
            }
            catch (ScholarshipNotExistException e)
            {
                var content = Content("369");
                content.StatusCode = StatusCodes.Status400BadRequest;
                return content;
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
