namespace Sample.Presentation.Web.Models
{
    public class SearchIndexViewModel
    {
        public SearchIndexViewModel()
        {
            SearchRequestViewModel = new SearchRequestViewModel();
            SearchResponseViewModel = new SearchResponseViewModel();
        }

        public SearchIndexViewModel(string keyword, string domain)
        {
            SearchRequestViewModel = new SearchRequestViewModel(keyword, domain);
            SearchResponseViewModel = new SearchResponseViewModel();
        }

        public SearchRequestViewModel SearchRequestViewModel { get; set; }

        public SearchResponseViewModel SearchResponseViewModel { get; set; }
    }
}
