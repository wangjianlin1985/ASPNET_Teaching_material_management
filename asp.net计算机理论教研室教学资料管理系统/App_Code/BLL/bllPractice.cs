using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*实习报告业务逻辑层*/
    public class bllPractice{
        /*添加实习报告*/
        public static bool AddPractice(ENTITY.Practice practice)
        {
            return DAL.dalPractice.AddPractice(practice);
        }

        /*根据practiceId获取某条实习报告记录*/
        public static ENTITY.Practice getSomePractice(int practiceId)
        {
            return DAL.dalPractice.getSomePractice(practiceId);
        }

        /*更新实习报告*/
        public static bool EditPractice(ENTITY.Practice practice)
        {
            return DAL.dalPractice.EditPractice(practice);
        }

        /*删除实习报告*/
        public static bool DelPractice(string p)
        {
            return DAL.dalPractice.DelPractice(p);
        }

        /*查询实习报告*/
        public static System.Data.DataSet GetPractice(string strWhere)
        {
            return DAL.dalPractice.GetPractice(strWhere);
        }

        /*根据条件分页查询实习报告*/
        public static System.Data.DataTable GetPractice(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPractice.GetPractice(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的实习报告*/
        public static System.Data.DataSet getAllPractice()
        {
            return DAL.dalPractice.getAllPractice();
        }
    }
}
