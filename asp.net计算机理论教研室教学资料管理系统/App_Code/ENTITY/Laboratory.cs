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
    ///Laboratory ��ժҪ˵����ʵ�鱨��ʵ��
    /// </summary>

    public class Laboratory
    {
        /*��¼id*/
        private int _laboratoryId;
        public int laboratoryId
        {
            get { return _laboratoryId; }
            set { _laboratoryId = value; }
        }

        /*ѧ��*/
        private int _yearObj;
        public int yearObj
        {
            get { return _yearObj; }
            set { _yearObj = value; }
        }

        /*ѧ��*/
        private string _team;
        public string team
        {
            get { return _team; }
            set { _team = value; }
        }

        /*ʵ������*/
        private string _symc;
        public string symc
        {
            get { return _symc; }
            set { _symc = value; }
        }

        /*ʵ����*/
        private string _sys;
        public string sys
        {
            get { return _sys; }
            set { _sys = value; }
        }

        /*�ο���ʦ*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*ʵ������*/
        private DateTime _syrq;
        public DateTime syrq
        {
            get { return _syrq; }
            set { _syrq = value; }
        }

    }
}
