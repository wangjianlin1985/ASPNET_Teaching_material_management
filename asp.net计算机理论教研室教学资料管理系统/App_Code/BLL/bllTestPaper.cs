using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�Ծ�ҵ���߼���*/
    public class bllTestPaper{
        /*����Ծ�*/
        public static bool AddTestPaper(ENTITY.TestPaper testPaper)
        {
            return DAL.dalTestPaper.AddTestPaper(testPaper);
        }

        /*����paperId��ȡĳ���Ծ��¼*/
        public static ENTITY.TestPaper getSomeTestPaper(int paperId)
        {
            return DAL.dalTestPaper.getSomeTestPaper(paperId);
        }

        /*�����Ծ�*/
        public static bool EditTestPaper(ENTITY.TestPaper testPaper)
        {
            return DAL.dalTestPaper.EditTestPaper(testPaper);
        }

        /*ɾ���Ծ�*/
        public static bool DelTestPaper(string p)
        {
            return DAL.dalTestPaper.DelTestPaper(p);
        }

        /*��ѯ�Ծ�*/
        public static System.Data.DataSet GetTestPaper(string strWhere)
        {
            return DAL.dalTestPaper.GetTestPaper(strWhere);
        }

        /*����������ҳ��ѯ�Ծ�*/
        public static System.Data.DataTable GetTestPaper(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTestPaper.GetTestPaper(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��Ծ�*/
        public static System.Data.DataSet getAllTestPaper()
        {
            return DAL.dalTestPaper.getAllTestPaper();
        }
    }
}
