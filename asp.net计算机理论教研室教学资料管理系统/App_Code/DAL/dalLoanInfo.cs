using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���Ͻ���ҵ���߼���ʵ��*/
    public class dalLoanInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*������Ͻ���ʵ��*/
        public static bool AddLoanInfo(ENTITY.LoanInfo loanInfo)
        {
            string sql = "insert into LoanInfo(materialObj,teacherObj,borrowDate,qixian,returnDate,memo) values(@materialObj,@teacherObj,@borrowDate,@qixian,@returnDate,@memo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@materialObj",SqlDbType.Int),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@borrowDate",SqlDbType.DateTime),
             new SqlParameter("@qixian",SqlDbType.VarChar),
             new SqlParameter("@returnDate",SqlDbType.VarChar),
             new SqlParameter("@memo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = loanInfo.materialObj; //��������
            parm[1].Value = loanInfo.teacherObj; //������
            parm[2].Value = loanInfo.borrowDate; //��������
            parm[3].Value = loanInfo.qixian; //��������
            parm[4].Value = loanInfo.returnDate; //�黹����
            parm[5].Value = loanInfo.memo; //��ע

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����loadId��ȡĳ�����Ͻ��ļ�¼*/
        public static ENTITY.LoanInfo getSomeLoanInfo(int loadId)
        {
            /*������ѯsql*/
            string sql = "select * from LoanInfo where loadId=" + loadId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.LoanInfo loanInfo = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                loanInfo = new ENTITY.LoanInfo();
                loanInfo.loadId = Convert.ToInt32(DataRead["loadId"]);
                loanInfo.materialObj = Convert.ToInt32(DataRead["materialObj"]);
                loanInfo.teacherObj = DataRead["teacherObj"].ToString();
                loanInfo.borrowDate = Convert.ToDateTime(DataRead["borrowDate"].ToString());
                loanInfo.qixian = DataRead["qixian"].ToString();
                loanInfo.returnDate = DataRead["returnDate"].ToString();
                loanInfo.memo = DataRead["memo"].ToString();
            }
            return loanInfo;
        }

        /*�������Ͻ���ʵ��*/
        public static bool EditLoanInfo(ENTITY.LoanInfo loanInfo)
        {
            string sql = "update LoanInfo set materialObj=@materialObj,teacherObj=@teacherObj,borrowDate=@borrowDate,qixian=@qixian,returnDate=@returnDate,memo=@memo where loadId=@loadId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@materialObj",SqlDbType.Int),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@borrowDate",SqlDbType.DateTime),
             new SqlParameter("@qixian",SqlDbType.VarChar),
             new SqlParameter("@returnDate",SqlDbType.VarChar),
             new SqlParameter("@memo",SqlDbType.VarChar),
             new SqlParameter("@loadId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = loanInfo.materialObj;
            parm[1].Value = loanInfo.teacherObj;
            parm[2].Value = loanInfo.borrowDate;
            parm[3].Value = loanInfo.qixian;
            parm[4].Value = loanInfo.returnDate;
            parm[5].Value = loanInfo.memo;
            parm[6].Value = loanInfo.loadId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����Ͻ���*/
        public static bool DelLoanInfo(string p)
        {
            string sql = "delete from LoanInfo where loadId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���Ͻ���*/
        public static DataSet GetLoanInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from LoanInfo" + strWhere + " order by loadId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ���Ͻ���*/
        public static System.Data.DataTable GetLoanInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from LoanInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "loadId", strShow, strSql, strWhere, " loadId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllLoanInfo()
        {
            try
            {
                string strSql = "select * from LoanInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
