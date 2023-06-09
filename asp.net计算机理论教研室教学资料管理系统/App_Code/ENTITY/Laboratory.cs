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
    ///Laboratory 的摘要说明：实验报告实体
    /// </summary>

    public class Laboratory
    {
        /*记录id*/
        private int _laboratoryId;
        public int laboratoryId
        {
            get { return _laboratoryId; }
            set { _laboratoryId = value; }
        }

        /*学年*/
        private int _yearObj;
        public int yearObj
        {
            get { return _yearObj; }
            set { _yearObj = value; }
        }

        /*学期*/
        private string _team;
        public string team
        {
            get { return _team; }
            set { _team = value; }
        }

        /*实验名称*/
        private string _symc;
        public string symc
        {
            get { return _symc; }
            set { _symc = value; }
        }

        /*实验室*/
        private string _sys;
        public string sys
        {
            get { return _sys; }
            set { _sys = value; }
        }

        /*任课老师*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*实验日期*/
        private DateTime _syrq;
        public DateTime syrq
        {
            get { return _syrq; }
            set { _syrq = value; }
        }

    }
}
