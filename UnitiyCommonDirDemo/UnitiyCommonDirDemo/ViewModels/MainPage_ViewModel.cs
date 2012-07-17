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

using System.Collections.ObjectModel;
using UnitiyCommon;
using System.Collections.Generic;

namespace UnitiyCommonDirDemo.ViewModels
{
    public class MainPage_ViewModel:BasicViewModel
    {
        ObservableCollection<CatalogInfo> catalogInfoCol = new ObservableCollection<CatalogInfo>();
        public ObservableCollection<CatalogInfo> CatalogInfoCol
        {
            get { return this.catalogInfoCol; }
            set
            {
                this.catalogInfoCol = value;
                base.NotifyPropertyChangedEventHandler("CatalogInfoCol");
            }
        }

        ObservableCollection<CommentInfo> commentInfoCol = new ObservableCollection<CommentInfo>();
        public ObservableCollection<CommentInfo> CommentInfoCol
        {
            get { return this.commentInfoCol; }
            set
            {
                this.commentInfoCol = value;
                base.NotifyPropertyChangedEventHandler("CommentInfoCol");
            }
        }

        public void LoadCatalogDefaultData()
        {
            #region Static DAta
            //this.catalogInfoCol.Clear();
            //this.catalogInfoCol.Add(new CatalogInfo() { CatalogName="Music & Video",CatalogComment="For Everyone Catalog" });
            //this.catalogInfoCol.Add(new CatalogInfo() { CatalogName = "Book References", CatalogComment = "just For Child" });
            #endregion

            #region Async Request DAta
            CommentAPI.GetAllNewsCommentOperator("http://t1.gstatic.com/images?q=tbn:ANd9GcSBn3tT0aIzgEd5HQl3d2HkGWpalkFd68qv75Ru1v_EUguHDtjf5g");
            CommentAPI.LoadCommentDataComplated += CommentAPI_LoadCommentDataComplated;
            #endregion
        }

        
        void CommentAPI_LoadCommentDataComplated(List<CommentInfo> commentList, Exception se)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (commentList != null && se == null)
                {
                    if (commentList.Count > 0)
                    {
                        this.commentInfoCol.Clear();
                        commentList.ForEach(x => { this.commentInfoCol.Add(x); }); //看不懂
                    }
                }
                else
                    MessageBox.Show(se.Message, "Exception MEssage", MessageBoxButton.OK);
            });
        }



        public string catalogTitle;
        public string CatalogTitle
        {
            get { return this.catalogTitle; }
            set
            {
                this.catalogTitle = value;
                base.NotifyPropertyChangedEventHandler("CatalogTitle");
            }
        }

     

    }

    public class CatalogInfo
    {
        public string CatalogName{get;set;}
        public string CatalogComment{get;set;}
    }
}
