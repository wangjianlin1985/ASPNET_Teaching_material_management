using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѧ����Ϣҵ���߼���*/
    public class bllYear{
        /*���ѧ����Ϣ*/
        public static bool AddYear(ENTITY.Year year)
        {
            return DAL.dalYear.AddYear(year);
        }

        /*����yearId��ȡĳ��ѧ����Ϣ��¼*/
        public static ENTITY.Year getSomeYear(int yearId)
        {
            return DAL.dalYear.getSomeYear(yearId);
        }

        /*����ѧ����Ϣ*/
        public static bool EditYear(ENTITY.Year year)
        {
            return DAL.dalYear.EditYear(year);
        }

        /*ɾ��ѧ����Ϣ*/
        public static bool DelYear(string p)
        {
            return DAL.dalYear.DelYear(p);
        }

        /*��ѯѧ����Ϣ*/
        public static System.Data.DataSet GetYear(string strWhere)
        {
            return DAL.dalYear.GetYear(strWhere);
        }

        /*����������ҳ��ѯѧ����Ϣ*/
        public static System.Data.DataTable GetYear(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalYear.GetYear(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ѧ����Ϣ*/
        public static System.Data.DataSet getAllYear()
        {
            return DAL.dalYear.getAllYear();
        }
    }
}
