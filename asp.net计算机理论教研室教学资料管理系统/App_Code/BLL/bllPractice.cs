using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ʵϰ����ҵ���߼���*/
    public class bllPractice{
        /*���ʵϰ����*/
        public static bool AddPractice(ENTITY.Practice practice)
        {
            return DAL.dalPractice.AddPractice(practice);
        }

        /*����practiceId��ȡĳ��ʵϰ�����¼*/
        public static ENTITY.Practice getSomePractice(int practiceId)
        {
            return DAL.dalPractice.getSomePractice(practiceId);
        }

        /*����ʵϰ����*/
        public static bool EditPractice(ENTITY.Practice practice)
        {
            return DAL.dalPractice.EditPractice(practice);
        }

        /*ɾ��ʵϰ����*/
        public static bool DelPractice(string p)
        {
            return DAL.dalPractice.DelPractice(p);
        }

        /*��ѯʵϰ����*/
        public static System.Data.DataSet GetPractice(string strWhere)
        {
            return DAL.dalPractice.GetPractice(strWhere);
        }

        /*����������ҳ��ѯʵϰ����*/
        public static System.Data.DataTable GetPractice(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPractice.GetPractice(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ʵϰ����*/
        public static System.Data.DataSet getAllPractice()
        {
            return DAL.dalPractice.getAllPractice();
        }
    }
}
