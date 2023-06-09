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
    ///Material 的摘要说明：教学资料实体
    /// </summary>

    public class Material
    {
        /*资料编号*/
        private int _materialId;
        public int materialId
        {
            get { return _materialId; }
            set { _materialId = value; }
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

        /*资料名称*/
        private string _materialName;
        public string materialName
        {
            get { return _materialName; }
            set { _materialName = value; }
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
