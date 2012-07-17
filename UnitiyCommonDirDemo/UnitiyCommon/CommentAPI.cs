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

using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Windows.Media.Imaging;

namespace UnitiyCommon
{
    public class CommentAPI:BasicAPI
    {
        public delegate void CommentData(List<CommentInfo> commentList, Exception se);
        public static event CommentData LoadCommentDataComplated;

        /// <summary>
        /// This Method Simulate asynchronous request 
        /// </summary>
        /// <param name="uri">Request Download Image Uri</param>
        public static void GetAllNewsCommentOperator(object uri)
        {
            if (!string.IsNullOrEmpty(uri.ToString()))
            {
                //Single Subscribe
                LoadCommentDataComplated = null;
                BasicAPI.TransportWebRequestOperator("POST", uri.ToString(), RequestComent_CallBack);
            }
        }

        static void RequestComent_CallBack(IAsyncResult result)
        {
            try
            {
                HttpWebRequest currentRequest = result.AsyncState as HttpWebRequest;
                WebResponse currentResponse = currentRequest.EndGetResponse(result);
                if (currentResponse != null)
                {
                    //Update State
                    IsComplated = true;
                    CommentInfo downloadComment = new CommentInfo()
                    {
                        CommentName = "Comment Image",
                        CommentImageUri=currentRequest.RequestUri.AbsoluteUri,
                        CommentImageData = currentResponse.GetResponseStream()
                    };
                    
                    List<CommentInfo> commentList = new List<CommentInfo>(){downloadComment};
                    if (LoadCommentDataComplated != null)
                        LoadCommentDataComplated(commentList, null);
                }

            }
            catch (Exception se)
            {
                if (LoadCommentDataComplated != null)
                    LoadCommentDataComplated(null, se);
            }
        }


        public static bool IsComplated { get; private set; }
        public void UpdateAsync()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(GetAllNewsCommentOperator);//它是怎样调用GetAllNewsCommentOperator(url);
                                                                                    //url是如何传进去的？？
        }



        /// <summary>
        /// This Method Simulate asynchronous request 
        /// </summary>
        public static void SimulateAsyncRequestData()
        {
            List<CommentInfo> simualteAsyncData = new List<CommentInfo>() 
            {
                new CommentInfo(){ CommentName="DuoMi"},
                new CommentInfo(){CommentName="Photo"},
                new CommentInfo(){CommentName="Common Use"}
            };

            if (LoadCommentDataComplated != null)
                LoadCommentDataComplated(simualteAsyncData, null);
        }

    }

    public class CommentInfo
    {
        public string CommentImageUri{get;set;}
        public string CommentName{get;set;}
        public Stream CommentImageData { get; set; }
    }
}
