using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueML.Services;
using IssueML.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IssueML.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuePredictController : ControllerBase
    {
        private IIssuePredictService isuePredictService;

        public IssuePredictController(IIssuePredictService issuePredictService)
        {
            this.isuePredictService = issuePredictService;
        }

        [HttpPost]
        public ActionResult PredictIssueSementPost(string str)
        {
            //return this.isuePredictService.PredictIssueBySement(str);
            return Content(JSONUtils.SerializeObject(this.isuePredictService.PredictIssueBySement(str)), "application/json", System.Text.Encoding.UTF8);
        }

        [HttpGet]
        public ActionResult PredictIssueSementGet(string str)
        {
            //return Content("", "application/json", System.Text.Encoding.UTF8);
            return Content(JSONUtils.SerializeObject(this.isuePredictService.PredictIssueBySement(str)), "application/json", System.Text.Encoding.UTF8);
        }
    }
}