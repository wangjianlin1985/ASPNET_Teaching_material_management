using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��ѧ����ҵ���߼���*/
    public class bllMaterial{
        /*��ӽ�ѧ����*/
        public static bool AddMaterial(ENTITY.Material material)
        {
            return DAL.dalMaterial.AddMaterial(material);
        }

        /*����materialId��ȡĳ����ѧ���ϼ�¼*/
        public static ENTITY.Material getSomeMaterial(int materialId)
        {
            return DAL.dalMaterial.getSomeMaterial(materialId);
        }

        /*���½�ѧ����*/
        public static bool EditMaterial(ENTITY.Material material)
        {
            return DAL.dalMaterial.EditMaterial(material);
        }

        /*ɾ����ѧ����*/
        public static bool DelMaterial(string p)
        {
            return DAL.dalMaterial.DelMaterial(p);
        }

        /*��ѯ��ѧ����*/
        public static System.Data.DataSet GetMaterial(string strWhere)
        {
            return DAL.dalMaterial.GetMaterial(strWhere);
        }

        /*����������ҳ��ѯ��ѧ����*/
        public static System.Data.DataTable GetMaterial(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalMaterial.GetMaterial(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĽ�ѧ����*/
        public static System.Data.DataSet getAllMaterial()
        {
            return DAL.dalMaterial.getAllMaterial();
        }
    }
}
