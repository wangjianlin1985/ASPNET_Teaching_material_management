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
    ///CourseReport 的摘要说明：课程设计报告实体
    /// </summary>

    public class CourseReport
    {
        /*编号*/
        private int _reportId;
        public int reportId
        {
            get { return _reportId; }
            set { _reportId = value; }
        }

        /*学年*/
        private int _yearObj;
        public int yearObj
        {
            get { return _yearObj; }
            set { _yearObj = value; }
        }

        /*学期*/
        private string _termInfo;
        public string termInfo
        {
            get { return _termInfo; }
            set { _termInfo = value; }
        }

        /*课程编号*/
        private string _courseNo;
        public string courseNo
        {
            get { return _courseNo; }
            set { _courseNo = value; }
        }

        /*课程名称*/
        private string _courseName;
        public string courseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        /*任课老师*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*任课班级*/
        private string _className;
        public string className
        {
            get { return _className; }
            set { _className = value; }
        }

        /*份数*/
        private int _fenshu;
        public int fenshu
        {
            get { return _fenshu; }
            set { _fenshu = value; }
        }

        /*归档日期*/
        private DateTime _putDate;
        public DateTime putDate
        {
            get { return _putDate; }
            set { _putDate = value; }
        }

        /*存放位置*/
        private string _putPlace;
        public string putPlace
        {
            get { return _putPlace; }
            set { _putPlace = value; }
        }

        /*经手人*/
        private string _handMan;
        public string handMan
        {
            get { return _handMan; }
            set { _handMan = value; }
        }

    }
}
