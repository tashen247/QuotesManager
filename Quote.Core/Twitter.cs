using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Twitterizer;
using System.Web;



namespace Quote.CoreServices
{
    public class Twitter
    {
        public void LogIntoTwitter()
        {
            var oauth_consumer_key = ConfigurationManager.AppSettings["consumerKey"];
            var oauth_consumer_secret = ConfigurationManager.AppSettings["consumerSecret"];

            if (HttpContext.Current.Request["oauth_token"] == null)
            {
                OAuthTokenResponse reqToken = OAuthUtility.GetRequestToken(
                oauth_consumer_key,
                oauth_consumer_secret,
                "http://localhost:49710/Post.aspx");
                //post.aspx is my next page to Login.aspx on which I hve a textbox to post a tweet
                HttpContext.Current.Response.Redirect(string.Format("http://twitter.com/oauth/authorize?oauth_token={0}",
                    reqToken.Token));
            }
        }

        public bool Tweet(string tweet)
        {
            var oauth_consumer_key = ConfigurationManager.AppSettings["consumerKey"];
            var oauth_consumer_secret = ConfigurationManager.AppSettings["consumerSecret"];
            string requestToken = HttpContext.Current.Request["oauth_token"].ToString();
            string pin = HttpContext.Current.Request["oauth_verifier"].ToString();
            bool success = false;

            var tokens = OAuthUtility.GetAccessToken(
                oauth_consumer_key,
                oauth_consumer_secret,
                requestToken,
                pin);

            OAuthTokens accesstoken = new OAuthTokens()
            {
                AccessToken = tokens.Token,
                AccessTokenSecret = tokens.TokenSecret,
                ConsumerKey = oauth_consumer_key,
                ConsumerSecret = oauth_consumer_secret
            };

            //TwitterResponse<TwitterStatus> response = TwitterStatus.Update(
            //    accesstoken,
            //    txtcomment.Text.Trim());

            TwitterResponse<TwitterStatus> response = TwitterStatus.Update(accesstoken, tweet, new StatusUpdateOptions() { UseSSL = true, APIBaseAddress = "http://api.twitter.com/1.1/" });


            if (response.Result == RequestResult.Success)
            {
                success = true; ;
            }

            return success;
        }
    }
}
