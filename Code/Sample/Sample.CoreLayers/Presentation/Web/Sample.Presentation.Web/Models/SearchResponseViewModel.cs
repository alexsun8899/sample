namespace Sample.Presentation.Web.Models
{
    public class SearchResponseViewModel
    {
        public SearchResponseViewModel(string value)
        {
            this.Result = value;
        }

        public SearchResponseViewModel() { }

        public string Result { get; set; }
    }
}
