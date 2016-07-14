using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Presentation.Web.Models
{
    public class SearchRequestViewModel
    {
        public SearchRequestViewModel() { }
        public SearchRequestViewModel(string keyword, string domain)
        {
            this.Keyword = keyword;
            this.Domain = domain;
        }

        public string Keyword { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Url(ErrorMessage = "Please enter a valid url")]
        public string Domain { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public int Range { get; set; }
    }
}
