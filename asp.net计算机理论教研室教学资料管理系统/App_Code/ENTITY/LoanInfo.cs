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
    ///LoanInfo ��ժҪ˵�������Ͻ���ʵ��
    /// </summary>

    public class LoanInfo
    {
        /*��¼id*/
        private int _loadId;
        public int loadId
        {
            get { return _loadId; }
            set { _loadId = value; }
        }

        /*��������*/
        private int _materialObj;
        public int materialObj
        {
            get { return _materialObj; }
            set { _materialObj = value; }
        }

        /*������*/
        private string _teacherObj;
        public string teacherObj
        {
            get { return _teacherObj; }
            set { _teacherObj = value; }
        }

        /*��������*/
        private DateTime _borrowDate;
        public DateTime borrowDate
        {
            get { return _borrowDate; }
            set { _borrowDate = value; }
        }

        /*��������*/
        private string _qixian;
        public string qixian
        {
            get { return _qixian; }
            set { _qixian = value; }
        }

        /*�黹����*/
        private string _returnDate;
        public string returnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }

        /*��ע*/
        private string _memo;
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

    }
}
