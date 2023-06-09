using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///Meeting 的摘要说明：会议记录实体
    /// </summary>

    public class Meeting
    {
        /*记录id*/
        private int _meetingId;
        public int meetingId
        {
            get { return _meetingId; }
            set { _meetingId = value; }
        }

        /*开会日期*/
        private DateTime _meetingDate;
        public DateTime meetingDate
        {
            get { return _meetingDate; }
            set { _meetingDate = value; }
        }

        /*负责人*/
        private string _fuzeren;
        public string fuzeren
        {
            get { return _fuzeren; }
            set { _fuzeren = value; }
        }

        /*会议记录员*/
        private string _hyjly;
        public string hyjly
        {
            get { return _hyjly; }
            set { _hyjly = value; }
        }

        /*会议内容*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*参会人员*/
        private string _chry;
        public string chry
        {
            get { return _chry; }
            set { _chry = value; }
        }

    }
}
