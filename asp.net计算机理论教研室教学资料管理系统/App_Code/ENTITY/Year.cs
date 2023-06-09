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
    ///Year 的摘要说明：学年信息实体
    /// </summary>

    public class Year
    {
        /*学年id*/
        private int _yearId;
        public int yearId
        {
            get { return _yearId; }
            set { _yearId = value; }
        }

        /*学年名称*/
        private string _yearName;
        public string yearName
        {
            get { return _yearName; }
            set { _yearName = value; }
        }

    }
}
