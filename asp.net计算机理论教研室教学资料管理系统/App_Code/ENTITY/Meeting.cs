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
    ///Meeting ��ժҪ˵���������¼ʵ��
    /// </summary>

    public class Meeting
    {
        /*��¼id*/
        private int _meetingId;
        public int meetingId
        {
            get { return _meetingId; }
            set { _meetingId = value; }
        }

        /*��������*/
        private DateTime _meetingDate;
        public DateTime meetingDate
        {
            get { return _meetingDate; }
            set { _meetingDate = value; }
        }

        /*������*/
        private string _fuzeren;
        public string fuzeren
        {
            get { return _fuzeren; }
            set { _fuzeren = value; }
        }

        /*�����¼Ա*/
        private string _hyjly;
        public string hyjly
        {
            get { return _hyjly; }
            set { _hyjly = value; }
        }

        /*��������*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*�λ���Ա*/
        private string _chry;
        public string chry
        {
            get { return _chry; }
            set { _chry = value; }
        }

    }
}
