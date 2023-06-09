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
    ///Score 的摘要说明：成绩实体
    /// </summary>

    public class Score
    {
        /*记录id*/
        private int _scoreId;
        public int scoreId
        {
            get { return _scoreId; }
            set { _scoreId = value; }
        }

        /*学年*/
        private int _yearObj;
        public int yearObj
        {
            get { return _yearObj; }
            set { _yearObj = value; }
        }

        /*学期*/
        private string _teamInfo;
        public string teamInfo
        {
            get { return _teamInfo; }
            set { _teamInfo = value; }
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

        /*学生学号*/
        private string _studentNo;
        public string studentNo
        {
            get { return _studentNo; }
            set { _studentNo = value; }
        }

        /*学生姓名*/
        private string _studentName;
        public string studentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        /*学生成绩*/
        private float _chengji;
        public float chengji
        {
            get { return _chengji; }
            set { _chengji = value; }
        }

    }
}
