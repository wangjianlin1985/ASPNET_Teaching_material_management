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
    ///Material ��ժҪ˵������ѧ����ʵ��
    /// </summary>

    public class Material
    {
        /*���ϱ��*/
        private int _materialId;
        public int materialId
        {
            get { return _materialId; }
            set { _materialId = value; }
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

        /*��������*/
        private string _materialName;
        public string materialName
        {
            get { return _materialName; }
            set { _materialName = value; }
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
