using System.Web;

namespace Sample.ApplicationServices.Modules.Receiver
{
    using AppService.ReceiverService.AbstractBase.ReceiverLogic;
    using AppService.ReceiverService.AbstractBase.ReceiverRetriever;
    using AppService.ReceiverService.AbstractBase.ReceiverSource;
    using Sample.CrossCutting.DTO;
    using System;

    public class ReceiverAppService : IReceiverAppService
    {
        readonly IReceiverLogic _receiverLogic;
        readonly IReceiverRetriever _receiverRetriever;
        readonly IReceiverSource _receiverSource;

        public ReceiverAppService(IReceiverLogic receiverLogic, IReceiverRetriever receiverRetriever, IReceiverSource receiverSource)
        {
            _receiverLogic = receiverLogic;
            _receiverRetriever = receiverRetriever;
            _receiverSource = receiverSource;
        }

        //public ResponseDTO<string> RetrieveData(SearchDTO dto)
        //{
        //    var response = new ResponseDTO<string>();
        //    try
        //    {
        //        string raw = "http://www.google.com.au/search?num=100&q={0}";
        //        string search = string.Format(raw, HttpUtility.UrlEncode(dto.Keyword));
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
        //        using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
        //        {
        //            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream(), Encoding.ASCII))
        //            {
        //                string html = reader.ReadToEnd();
        //                var url = new Uri(string.Format("https://{0}", dto.Domain));
        //                response.Result = FindPosition(html, url).ToString();
        //            }
        //        }

        //        response.IsCompleted = true;
        //        response.HasError = false;
        //    }
        //    catch (Exception e)
        //    {
        //        response.IsCompleted = false;
        //        response.HasError = true;
        //        response.IsErrorProcessed = true;
        //        response.ErrorMessage = e.Message;
        //    }
        //    return response;
        //}

        //private static int FindPosition(string html, Uri url)
        //{
        //    //string lookup = "(<h3 class=\"r\"><a href=\"/url\\?q=)(\\w+[a-zA-Z0-9.\\-?=/:]*)";
        //    string lookup = "<h3 class=\"r\"><a href=\"/.*?\\?q=(.*?)\">(.*?)</a>";

        //    MatchCollection matches = Regex.Matches(html, lookup);
        //    for (int i = 0; i < matches.Count; i++)
        //    {
        //        string match = matches[i].Groups[2].Value;
        //        if (match.Contains(url.Host))
        //            return i + 1;
        //    }
        //    return 0;
        //}

        public ResponseDTO<string> RetrieveData(string keyword)
        {
            var response = new ResponseDTO<string>();
            try
            {
                var dataProvider = _receiverSource.ConfigSource();
                var queryBuilder = _receiverLogic.ConfigStdSearchCriteria();
                var api = dataProvider + queryBuilder;
                var search = string.Format(api, HttpUtility.UrlEncode(keyword));
                var result = _receiverRetriever.RetrieveRawData(search);
                response.Result = result;
                response.IsCompleted = true;
                response.HasError = false;
            }
            catch (Exception ex)
            {
                response.IsCompleted = false;
                response.HasError = true;
                response.IsErrorProcessed = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

    }
}
