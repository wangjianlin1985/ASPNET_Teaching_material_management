using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��ѧ����ҵ���߼���*/
    public class bllTeaching{
        /*��ӽ�ѧ����*/
        public static bool AddTeaching(ENTITY.Teaching teaching)
        {
            return DAL.dalTeaching.AddTeaching(teaching);
        }

        /*����teachingId��ȡĳ����ѧ������¼*/
        public static ENTITY.Teaching getSomeTeaching(int teachingId)
        {
            return DAL.dalTeaching.getSomeTeaching(teachingId);
        }

        /*���½�ѧ����*/
        public static bool EditTeaching(ENTITY.Teaching teaching)
        {
            return DAL.dalTeaching.EditTeaching(teaching);
        }

        /*ɾ����ѧ����*/
        public static bool DelTeaching(string p)
        {
            return DAL.dalTeaching.DelTeaching(p);
        }

        /*��ѯ��ѧ����*/
        public static System.Data.DataSet GetTeaching(string strWhere)
        {
            return DAL.dalTeaching.GetTeaching(strWhere);
        }

        /*����������ҳ��ѯ��ѧ����*/
        public static System.Data.DataTable GetTeaching(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTeaching.GetTeaching(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĽ�ѧ����*/
        public static System.Data.DataSet getAllTeaching()
        {
            return DAL.dalTeaching.getAllTeaching();
        }
    }
}
