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
    ///Year ��ժҪ˵����ѧ����Ϣʵ��
    /// </summary>

    public class Year
    {
        /*ѧ��id*/
        private int _yearId;
        public int yearId
        {
            get { return _yearId; }
            set { _yearId = value; }
        }

        /*ѧ������*/
        private string _yearName;
        public string yearName
        {
            get { return _yearName; }
            set { _yearName = value; }
        }

    }
}
