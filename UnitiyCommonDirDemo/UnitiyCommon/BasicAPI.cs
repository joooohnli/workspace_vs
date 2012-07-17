using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace UnitiyCommon
{
    public class BasicAPI
    {
        /// <summary>
        /// Transport WebRequest Operator
        /// </summary>
        /// <param name="postType">Post Type</param>
        /// <param name="uri">Request Uri</param>
        /// <param name="currentCallBack">AsyncCallBack Function</param>
        public static void TransportWebRequestOperator(string postType, string uri,AsyncCallback currentCallBack)
        {
            if (!string.IsNullOrEmpty(uri))
            {
                WebRequest currentWebRequest = HttpWebRequest.Create(new Uri(uri, UriKind.RelativeOrAbsolute));
                if (currentWebRequest != null)
                {
                    if (!string.IsNullOrEmpty(postType))
                        currentWebRequest.Method = postType;
                    else
                        currentWebRequest.Method = "POST";
                    IAsyncResult asyncCallBackResult = currentWebRequest.BeginGetResponse(currentCallBack, currentWebRequest);
                }
            }
        }


        /// <summary>
        /// Transport WebClient Request Operator
        /// </summary>
        /// <param name="uri">Request URi</param>
        /// <param name="openReaderEvent">OpenReadComplate Event</param>
        public static void TransportClientRequestOperaotr(string uri, OpenReadCompletedEventHandler openReaderEvent)
        {
            if (!string.IsNullOrEmpty(uri))
            {
                WebClient currentClient = new WebClient();
                currentClient.OpenReadAsync(new Uri(uri, UriKind.RelativeOrAbsolute));
                currentClient.OpenReadCompleted += openReaderEvent;
            }            
        }



      
    }
}
