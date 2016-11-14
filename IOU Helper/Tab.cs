using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace IOU_Helper
{
    public class Tab : ICloneable
    {
        private string _kongUsername;
        private string _kongID;
        private string _kongToken;
        private static string _code;
        private static string _gameVersion;
        private WebKit.WebKitBrowser _client;
        private TabPage _tabpage;
        private Boolean _isTest;
        private int _port;

        //Kongregate Tab Creation
        public Tab(string kongUsername, string kongID, string kongToken, WebKit.WebKitBrowser client)
        {
            _kongUsername = kongUsername;
            _kongID = kongID;
            _kongToken = kongToken;
            _client = client;
        }

        //IOURPG Tab Creation
        public Tab(WebKit.WebKitBrowser client, TabPage tabpage)
        {
            _kongUsername = "IOURPG";
            _client = client;
            _tabpage = tabpage;
        }

        public override string ToString()
        {
            return _kongUsername + "," + _kongID + "," + _kongToken;
        }

        public System.Uri URL()
        {
            System.Uri uri = new System.Uri("http://chat.kongregate.com/gamez/0022/7576/live/iou.swf?" + _gameVersion + "&kongregate_username=" + _kongUsername + "&kongregate_user_id=" + _kongID + "&kongregate_game_auth_token=" + _kongToken + "&kongregate_api_path=http%3A%2F%2Fchat.kongregate.com%2Fflash%2FAPI_AS3_" + _code + ".swf");
            return uri;
        }

        public WebKit.WebKitBrowser getClient() 
        {
            return _client;
        }

        public void setClient(WebKit.WebKitBrowser client)
        {
            _client = client;
        }

        public string getUsername()
        {
            return _kongUsername;
        }

        public TabPage getTabPage()
        {
            return _tabpage;
        }

        public static void setCodes(string code, string gameVersion) 
        {
            _code = code;
            _gameVersion = gameVersion;
        }

        public void reloadIOURPG()
        {
            _client.Url = new System.Uri("http://scripts.iouscripts.com/iou.swf");
        }

        public void reloadTestIOURPG()
        {
            _client.Url = new System.Uri("http://iourpg.com/test.swf");
        }

        public System.Uri getTestURL()
        {
            System.Uri uri = new System.Uri("http://iourpg.com/test.swf?" + _gameVersion + "&kongregate_username=" + _kongUsername + "&kongregate_user_id=" + _kongID + "&kongregate_game_auth_token=" + _kongToken + "&kongregate_api_path=http%3A%2F%2Fchat.kongregate.com%2Fflash%2FAPI_AS3_" + _code + ".swf");
            _port = uri.Port;
            return uri;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void setIsTest(Boolean boolean)
        {
            _isTest = boolean;
        }
        public Boolean getIsTest()
        {
            return _isTest;
        }

    }
}
