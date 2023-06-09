using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*学年信息业务逻辑层实现*/
    public class dalYear
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加学年信息实现*/
        public static bool AddYear(ENTITY.Year year)
        {
            string sql = "insert into Year(yearName) values(@yearName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = year.yearName; //学年名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据yearId获取某条学年信息记录*/
        public static ENTITY.Year getSomeYear(int yearId)
        {
            /*构建查询sql*/
            string sql = "select * from Year where yearId=" + yearId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Year year = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                year = new ENTITY.Year();
                year.yearId = Convert.ToInt32(DataRead["yearId"]);
                year.yearName = DataRead["yearName"].ToString();
            }
            return year;
        }

        /*更新学年信息实现*/
        public static bool EditYear(ENTITY.Year year)
        {
            string sql = "update Year set yearName=@yearName where yearId=@yearId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearName",SqlDbType.VarChar),
             new SqlParameter("@yearId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = year.yearName;
            parm[1].Value = year.yearId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除学年信息*/
        public static bool DelYear(string p)
        {
            string sql = "delete from Year where yearId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询学年信息*/
        public static DataSet GetYear(string strWhere)
        {
            try
            {
                string strSql = "select * from Year" + strWhere + " order by yearId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询学年信息*/
        public static System.Data.DataTable GetYear(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Year";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "yearId", strShow, strSql, strWhere, " yearId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllYear()
        {
            try
            {
                string strSql = "select * from Year";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
