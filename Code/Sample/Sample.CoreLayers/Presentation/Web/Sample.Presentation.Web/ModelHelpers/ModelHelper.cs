namespace Sample.Presentation.Web.ModelHelpers
{
    using Components.SvcRefLib.Core.Core;
    using Models;

    public static class ModelHelper
    {
        //In this project, searchDto and model have same data members. This method can be replaced by AutoMapper or ValueInject.
        public static SearchDTO ConvertSearchViewModelToDTO(SearchRequestViewModel model)
        {
            var dto = new SearchDTO();
            dto.Keyword = model.Keyword;
            dto.Country = model.Country;
            dto.Domain = model.Domain;
            dto.Language = model.Language;
            dto.Range = model.Range;
            return dto;
        }
    }
}