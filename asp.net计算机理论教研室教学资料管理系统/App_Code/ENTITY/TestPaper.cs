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
    ///TestPaper ��ժҪ˵�����Ծ�ʵ��
    /// </summary>

    public class TestPaper
    {
        /*���*/
        private int _paperId;
        public int paperId
        {
            get { return _paperId; }
            set { _paperId = value; }
        }

        /*ѧ��*/
        private int _yearObj;
        public int yearObj
        {
            get { return _yearObj; }
            set { _yearObj = value; }
        }

        /*ѧ��*/
        private string _teamInfo;
        public string teamInfo
        {
            get { return _teamInfo; }
            set { _teamInfo = value; }
        }

        /*�γ̱��*/
        private string _courseNo;
        public string courseNo
        {
            get { return _courseNo; }
            set { _courseNo = value; }
        }

        /*�γ�����*/
        private string _courseName;
        public string courseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        /*�ο���ʦ*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*�οΰ༶*/
        private string _className;
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        /*��������*/
        private string _examType;
        public string examType
        {
            get { return _examType; }
            set { _examType = value; }
        }

        /*�鵵����*/
        private DateTime _putDate;
        public DateTime putDate
        {
            get { return _putDate; }
            set { _putDate = value; }
        }

        /*���λ��*/
        private string _putPlace;
        public string putPlace
        {
            get { return _putPlace; }
            set { _putPlace = value; }
        }

        /*������*/
        private string _handMan;
        public string handMan
        {
            get { return _handMan; }
            set { _handMan = value; }
        }

    }
}
