using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*试卷业务逻辑层*/
    public class bllTestPaper{
        /*添加试卷*/
        public static bool AddTestPaper(ENTITY.TestPaper testPaper)
        {
            return DAL.dalTestPaper.AddTestPaper(testPaper);
        }

        /*根据paperId获取某条试卷记录*/
        public static ENTITY.TestPaper getSomeTestPaper(int paperId)
        {
            return DAL.dalTestPaper.getSomeTestPaper(paperId);
        }

        /*更新试卷*/
        public static bool EditTestPaper(ENTITY.TestPaper testPaper)
        {
            return DAL.dalTestPaper.EditTestPaper(testPaper);
        }

        /*删除试卷*/
        public static bool DelTestPaper(string p)
        {
            return DAL.dalTestPaper.DelTestPaper(p);
        }

        /*查询试卷*/
        public static System.Data.DataSet GetTestPaper(string strWhere)
        {
            return DAL.dalTestPaper.GetTestPaper(strWhere);
        }

        /*根据条件分页查询试卷*/
        public static System.Data.DataTable GetTestPaper(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTestPaper.GetTestPaper(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的试卷*/
        public static System.Data.DataSet getAllTestPaper()
        {
            return DAL.dalTestPaper.getAllTestPaper();
        }
    }
}
