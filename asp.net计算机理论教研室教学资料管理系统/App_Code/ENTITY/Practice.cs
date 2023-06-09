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
    ///Practice 的摘要说明：实习报告实体
    /// </summary>

    public class Practice
    {
        /*记录id*/
        private int _practiceId;
        public int practiceId
        {
            get { return _practiceId; }
            set { _practiceId = value; }
        }

        /*学年*/
        private int _yearObj;
        public int yearObj
        {
            get { return _yearObj; }
            set { _yearObj = value; }
        }

        /*学生姓名*/
        private string _studentName;
        public string studentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        /*实习单位*/
        private string _sxdw;
        public string sxdw
        {
            get { return _sxdw; }
            set { _sxdw = value; }
        }

        /*实习日期*/
        private DateTime _sxrq;
        public DateTime sxrq
        {
            get { return _sxrq; }
            set { _sxrq = value; }
        }

        /*指导老师*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

    }
}
