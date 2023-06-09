using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���Ͻ���ҵ���߼���*/
    public class bllLoanInfo{
        /*������Ͻ���*/
        public static bool AddLoanInfo(ENTITY.LoanInfo loanInfo)
        {
            return DAL.dalLoanInfo.AddLoanInfo(loanInfo);
        }

        /*����loadId��ȡĳ�����Ͻ��ļ�¼*/
        public static ENTITY.LoanInfo getSomeLoanInfo(int loadId)
        {
            return DAL.dalLoanInfo.getSomeLoanInfo(loadId);
        }

        /*�������Ͻ���*/
        public static bool EditLoanInfo(ENTITY.LoanInfo loanInfo)
        {
            return DAL.dalLoanInfo.EditLoanInfo(loanInfo);
        }

        /*ɾ�����Ͻ���*/
        public static bool DelLoanInfo(string p)
        {
            return DAL.dalLoanInfo.DelLoanInfo(p);
        }

        /*��ѯ���Ͻ���*/
        public static System.Data.DataSet GetLoanInfo(string strWhere)
        {
            return DAL.dalLoanInfo.GetLoanInfo(strWhere);
        }

        /*����������ҳ��ѯ���Ͻ���*/
        public static System.Data.DataTable GetLoanInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalLoanInfo.GetLoanInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����Ͻ���*/
        public static System.Data.DataSet getAllLoanInfo()
        {
            return DAL.dalLoanInfo.getAllLoanInfo();
        }
    }
}
