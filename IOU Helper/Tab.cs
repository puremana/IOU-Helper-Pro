using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace IOU_Helper
{
    public class Tab
    {
        private string _kongUsername;
        private string _kongID;
        private string _kongToken;
        private static string _code;
        private WebKit.WebKitBrowser _client;

        public Tab(string kongUsername, string kongID, string kongToken, WebKit.WebKitBrowser client)
        {
            _kongUsername = kongUsername;
            _kongID = kongID;
            _kongToken = kongToken;
            _client = client;
        }

        public override string ToString()
        {
            return _kongUsername + "," + _kongID + "," + _kongToken;
        }

        public System.Uri URL()
        {
            System.Uri uri = new System.Uri("http://chat.kongregate.com/gamez/0022/7576/live/iou.swf?kongregate_username=" + _kongUsername + "&kongregate_user_id=" + _kongID + "&kongregate_game_auth_token=" + _kongToken + "&kongregate_api_path=http%3A%2F%2Fchat.kongregate.com%2Fflash%2FAPI_AS3_" + _code + ".swf");
            return uri;
        }

        public WebKit.WebKitBrowser getClient() 
        {
            return _client;
        }

        public string getUsername()
        {
            return _kongUsername;
        }

        public static void setCode(string code) 
        {
            _code = code;
        }
    }
}
