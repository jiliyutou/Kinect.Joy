using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Kinect.Joy.Share
{
    using NetDimension.Weibo;

    public class WeiboShare
    {
        private static string AppKey = Properties.Settings.Default.AppKey;
        private static string AppSecret = Properties.Settings.Default.AppSecrect;
        private static string CallbackUrl = Properties.Settings.Default.CallbackUrl;
        private static string AccessToken = Properties.Settings.Default.AccessToken;
        private static string UserId = Properties.Settings.Default.UserId;
        private static string Password = Properties.Settings.Default.Password;
        
        private static OAuth oAuth = null;

        public WeiboShare()
        {
            if (null == oAuth && !IsNullOrEmpty())
            {
                oAuth = new OAuth(Properties.Settings.Default.AppKey, Properties.Settings.Default.AppSecrect, Properties.Settings.Default.CallbackUrl);
            }
        }

        /// <summary>
        /// Call this function before function Share2Weibo
        /// </summary>
        /// <returns></returns>
        public LoginType Login()
        {
            LoginType ret = LoginType.AuthFailed;
            try
            {
                ret = oAuth.ClientLogin(UserId, Password) ? LoginType.Success : LoginType.LoginFailed;
            }
            catch (Exception e)
            {
            }
            return ret;
        }

        private bool IsNullOrEmpty()
        {
            if (string.IsNullOrEmpty(AppKey) || string.IsNullOrEmpty(AppSecret) || string.IsNullOrEmpty(CallbackUrl)
                || string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Password))
                return true;
            return false;
        }

        private byte[] GetPictureData(string imagePath)
        {
            System.IO.FileStream fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open);
            byte[] byteData = new byte[fs.Length];
            fs.Read(byteData, 0, byteData.Length);
            fs.Close();
            return byteData;
            
        }

        /// <summary>
        /// Share Kinect image to Sina Weibo
        /// </summary>
        /// <param name="imagePath">Image path</param>
        /// <param name="Content">Text description for Image</param>
        public void Share2Weibo(String imagePath="",String Content="")
        {
            if (oAuth != null)
            {
                Client Sina = new Client(oAuth);
                string uid = Sina.API.Entity.Account.GetUID();
                var entity_userInfo = Sina.API.Entity.Users.Show(uid);
                if (string.IsNullOrEmpty(Content))
                    Content = string.Format("#Kinect for Windows 创新应用开发全国挑战赛# 我是{0}，来自{1}，我在{2}用KinectJoy发布分享了本条微博，欢迎关注\"2013码上Kinect\"~~ http://www.microsoft.com/zh-cn/kinectforwindows/campaign/trainning.aspx", entity_userInfo.ScreenName, entity_userInfo.Location, DateTime.Now.ToLongTimeString());
                if (string.IsNullOrEmpty(imagePath))
                {
                    var StatusInfo = Sina.API.Entity.Statuses.Update(Content);
                }
                else
                {
                    var StatusInfo = Sina.API.Entity.Statuses.Upload(Content, GetPictureData(imagePath));
                }
            }
        }   
    }
}
