using Sample.AppService.ReceiverService.AbstractBase.ReceiverRetriever;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Sample.AppService.ReceiverService.Google
{
    public class GoogleReceiverRetriever : ReceiverRetrieverBase
    {

        public override void ConfigClient()
        {

        }

        public override string RetrieveRawData(string search)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
                using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream(), Encoding.ASCII))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                //use generic exception handler 
            }
            return result;
        }
    }
}
