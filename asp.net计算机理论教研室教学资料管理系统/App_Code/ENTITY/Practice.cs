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
    ///Practice ��ժҪ˵����ʵϰ����ʵ��
    /// </summary>

    public class Practice
    {
        /*��¼id*/
        private int _practiceId;
        public int practiceId
        {
            get { return _practiceId; }
            set { _practiceId = value; }
        }

        /*ѧ��*/
        private int _yearObj;
        public int yearObj
        {
            get { return _yearObj; }
            set { _yearObj = value; }
        }

        /*ѧ������*/
        private string _studentName;
        public string studentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        /*ʵϰ��λ*/
        private string _sxdw;
        public string sxdw
        {
            get { return _sxdw; }
            set { _sxdw = value; }
        }

        /*ʵϰ����*/
        private DateTime _sxrq;
        public DateTime sxrq
        {
            get { return _sxrq; }
            set { _sxrq = value; }
        }

        /*ָ����ʦ*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

    }
}
