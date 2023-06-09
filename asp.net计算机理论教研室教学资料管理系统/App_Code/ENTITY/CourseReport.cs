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
    ///CourseReport ��ժҪ˵�����γ���Ʊ���ʵ��
    /// </summary>

    public class CourseReport
    {
        /*���*/
        private int _reportId;
        public int reportId
        {
            get { return _reportId; }
            set { _reportId = value; }
        }

        /*ѧ��*/
        private int _yearObj;
        public int yearObj
        {
            get { return _yearObj; }
            set { _yearObj = value; }
        }

        /*ѧ��*/
        private string _termInfo;
        public string termInfo
        {
            get { return _termInfo; }
            set { _termInfo = value; }
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

        /*����*/
        private int _fenshu;
        public int fenshu
        {
            get { return _fenshu; }
            set { _fenshu = value; }
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
