using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*资料借阅业务逻辑层*/
    public class bllLoanInfo{
        /*添加资料借阅*/
        public static bool AddLoanInfo(ENTITY.LoanInfo loanInfo)
        {
            return DAL.dalLoanInfo.AddLoanInfo(loanInfo);
        }

        /*根据loadId获取某条资料借阅记录*/
        public static ENTITY.LoanInfo getSomeLoanInfo(int loadId)
        {
            return DAL.dalLoanInfo.getSomeLoanInfo(loadId);
        }

        /*更新资料借阅*/
        public static bool EditLoanInfo(ENTITY.LoanInfo loanInfo)
        {
            return DAL.dalLoanInfo.EditLoanInfo(loanInfo);
        }

        /*删除资料借阅*/
        public static bool DelLoanInfo(string p)
        {
            return DAL.dalLoanInfo.DelLoanInfo(p);
        }

        /*查询资料借阅*/
        public static System.Data.DataSet GetLoanInfo(string strWhere)
        {
            return DAL.dalLoanInfo.GetLoanInfo(strWhere);
        }

        /*根据条件分页查询资料借阅*/
        public static System.Data.DataTable GetLoanInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalLoanInfo.GetLoanInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的资料借阅*/
        public static System.Data.DataSet getAllLoanInfo()
        {
            return DAL.dalLoanInfo.getAllLoanInfo();
        }
    }
}
