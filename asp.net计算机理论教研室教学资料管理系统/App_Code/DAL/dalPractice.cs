using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*实习报告业务逻辑层实现*/
    public class dalPractice
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加实习报告实现*/
        public static bool AddPractice(ENTITY.Practice practice)
        {
            string sql = "insert into Practice(yearObj,studentName,sxdw,sxrq,teacherObj) values(@yearObj,@studentName,@sxdw,@sxrq,@teacherObj)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@sxdw",SqlDbType.VarChar),
             new SqlParameter("@sxrq",SqlDbType.DateTime),
             new SqlParameter("@teacherObj",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = practice.yearObj; //学年
            parm[1].Value = practice.studentName; //学生姓名
            parm[2].Value = practice.sxdw; //实习单位
            parm[3].Value = practice.sxrq; //实习日期
            parm[4].Value = practice.teacherObj; //指导老师

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据practiceId获取某条实习报告记录*/
        public static ENTITY.Practice getSomePractice(int practiceId)
        {
            /*构建查询sql*/
            string sql = "select * from Practice where practiceId=" + practiceId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Practice practice = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                practice = new ENTITY.Practice();
                practice.practiceId = Convert.ToInt32(DataRead["practiceId"]);
                practice.yearObj = Convert.ToInt32(DataRead["yearObj"]);
                practice.studentName = DataRead["studentName"].ToString();
                practice.sxdw = DataRead["sxdw"].ToString();
                practice.sxrq = Convert.ToDateTime(DataRead["sxrq"].ToString());
                practice.teacherObj = DataRead["teacherObj"].ToString();
            }
            return practice;
        }

        /*更新实习报告实现*/
        public static bool EditPractice(ENTITY.Practice practice)
        {
            string sql = "update Practice set yearObj=@yearObj,studentName=@studentName,sxdw=@sxdw,sxrq=@sxrq,teacherObj=@teacherObj where practiceId=@practiceId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@sxdw",SqlDbType.VarChar),
             new SqlParameter("@sxrq",SqlDbType.DateTime),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@practiceId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = practice.yearObj;
            parm[1].Value = practice.studentName;
            parm[2].Value = practice.sxdw;
            parm[3].Value = practice.sxrq;
            parm[4].Value = practice.teacherObj;
            parm[5].Value = practice.practiceId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除实习报告*/
        public static bool DelPractice(string p)
        {
            string sql = "delete from Practice where practiceId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询实习报告*/
        public static DataSet GetPractice(string strWhere)
        {
            try
            {
                string strSql = "select * from Practice" + strWhere + " order by practiceId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询实习报告*/
        public static System.Data.DataTable GetPractice(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Practice";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "practiceId", strShow, strSql, strWhere, " practiceId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllPractice()
        {
            try
            {
                string strSql = "select * from Practice";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
