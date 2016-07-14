using System.Web.Mvc;

namespace Sample.Presentation.Web.Controllers
{
    using Components.SvcRefLib.Core.Core;
    using CrossCutting.Common.ConfigObjects.Constants;
    using ModelHelpers;
    using Models;
    using System;

    public class HomeController : BaseController
    {
        readonly ICoreService _coreService;

        public HomeController(ICoreService coreService)
        {
            _coreService = coreService;
        }

        [HandleError]
        public ActionResult Index()
        {
            var model = new SearchIndexViewModel(Constants.GOOGLE_SEARCH_KEYWORD, Constants.GOOGLE_SEARCH_DOMAIN);
            return View(model);
        }

        [HandleError]
        [HttpPost]
        public ActionResult GetKeywordPosition(SearchRequestViewModel model)
        {
            var dto = ModelHelper.ConvertSearchViewModelToDTO(model);

            var data = _coreService.GetKeywordPosition(dto);
            if (data.IsCompleted && !data.HasError)
            {
                var response = new SearchResponseViewModel(data.Result);
                return PartialView("_PartialSearchResponseView", response);
            }
            else
            {
                throw new Exception();
            }
               
        }


    }
}