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
    ///Score ��ժҪ˵�����ɼ�ʵ��
    /// </summary>

    public class Score
    {
        /*��¼id*/
        private int _scoreId;
        public int scoreId
        {
            get { return _scoreId; }
            set { _scoreId = value; }
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

        /*ѧ��ѧ��*/
        private string _studentNo;
        public string studentNo
        {
            get { return _studentNo; }
            set { _studentNo = value; }
        }

        /*ѧ������*/
        private string _studentName;
        public string studentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        /*ѧ���ɼ�*/
        private float _chengji;
        public float chengji
        {
            get { return _chengji; }
            set { _chengji = value; }
        }

    }
}
