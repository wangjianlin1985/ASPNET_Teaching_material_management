using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*资料借阅业务逻辑层实现*/
    public class dalLoanInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加资料借阅实现*/
        public static bool AddLoanInfo(ENTITY.LoanInfo loanInfo)
        {
            string sql = "insert into LoanInfo(materialObj,teacherObj,borrowDate,qixian,returnDate,memo) values(@materialObj,@teacherObj,@borrowDate,@qixian,@returnDate,@memo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@materialObj",SqlDbType.Int),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@borrowDate",SqlDbType.DateTime),
             new SqlParameter("@qixian",SqlDbType.VarChar),
             new SqlParameter("@returnDate",SqlDbType.VarChar),
             new SqlParameter("@memo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = loanInfo.materialObj; //借阅资料
            parm[1].Value = loanInfo.teacherObj; //借阅人
            parm[2].Value = loanInfo.borrowDate; //借阅日期
            parm[3].Value = loanInfo.qixian; //借阅期限
            parm[4].Value = loanInfo.returnDate; //归还日期
            parm[5].Value = loanInfo.memo; //备注

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据loadId获取某条资料借阅记录*/
        public static ENTITY.LoanInfo getSomeLoanInfo(int loadId)
        {
            /*构建查询sql*/
            string sql = "select * from LoanInfo where loadId=" + loadId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.LoanInfo loanInfo = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新资料借阅实现*/
        public static bool EditLoanInfo(ENTITY.LoanInfo loanInfo)
        {
            string sql = "update LoanInfo set materialObj=@materialObj,teacherObj=@teacherObj,borrowDate=@borrowDate,qixian=@qixian,returnDate=@returnDate,memo=@memo where loadId=@loadId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@materialObj",SqlDbType.Int),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@borrowDate",SqlDbType.DateTime),
             new SqlParameter("@qixian",SqlDbType.VarChar),
             new SqlParameter("@returnDate",SqlDbType.VarChar),
             new SqlParameter("@memo",SqlDbType.VarChar),
             new SqlParameter("@loadId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = loanInfo.materialObj;
            parm[1].Value = loanInfo.teacherObj;
            parm[2].Value = loanInfo.borrowDate;
            parm[3].Value = loanInfo.qixian;
            parm[4].Value = loanInfo.returnDate;
            parm[5].Value = loanInfo.memo;
            parm[6].Value = loanInfo.loadId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除资料借阅*/
        public static bool DelLoanInfo(string p)
        {
            string sql = "delete from LoanInfo where loadId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询资料借阅*/
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

        /*查询资料借阅*/
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
