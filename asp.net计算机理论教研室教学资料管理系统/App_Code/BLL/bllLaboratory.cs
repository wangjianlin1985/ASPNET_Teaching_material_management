using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ʵ�鱨��ҵ���߼���*/
    public class bllLaboratory{
        /*���ʵ�鱨��*/
        public static bool AddLaboratory(ENTITY.Laboratory laboratory)
        {
            return DAL.dalLaboratory.AddLaboratory(laboratory);
        }

        /*����laboratoryId��ȡĳ��ʵ�鱨���¼*/
        public static ENTITY.Laboratory getSomeLaboratory(int laboratoryId)
        {
            return DAL.dalLaboratory.getSomeLaboratory(laboratoryId);
        }

        /*����ʵ�鱨��*/
        public static bool EditLaboratory(ENTITY.Laboratory laboratory)
        {
            return DAL.dalLaboratory.EditLaboratory(laboratory);
        }

        /*ɾ��ʵ�鱨��*/
        public static bool DelLaboratory(string p)
        {
            return DAL.dalLaboratory.DelLaboratory(p);
        }

        /*��ѯʵ�鱨��*/
        public static System.Data.DataSet GetLaboratory(string strWhere)
        {
            return DAL.dalLaboratory.GetLaboratory(strWhere);
        }

        /*����������ҳ��ѯʵ�鱨��*/
        public static System.Data.DataTable GetLaboratory(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalLaboratory.GetLaboratory(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ʵ�鱨��*/
        public static System.Data.DataSet getAllLaboratory()
        {
            return DAL.dalLaboratory.getAllLaboratory();
        }
    }
}
