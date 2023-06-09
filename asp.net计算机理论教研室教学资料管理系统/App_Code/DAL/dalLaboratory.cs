using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*实验报告业务逻辑层实现*/
    public class dalLaboratory
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加实验报告实现*/
        public static bool AddLaboratory(ENTITY.Laboratory laboratory)
        {
            string sql = "insert into Laboratory(yearObj,team,symc,sys,teacherObj,syrq) values(@yearObj,@team,@symc,@sys,@teacherObj,@syrq)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@team",SqlDbType.VarChar),
             new SqlParameter("@symc",SqlDbType.VarChar),
             new SqlParameter("@sys",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@syrq",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = laboratory.yearObj; //学年
            parm[1].Value = laboratory.team; //学期
            parm[2].Value = laboratory.symc; //实验名称
            parm[3].Value = laboratory.sys; //实验室
            parm[4].Value = laboratory.teacherObj; //任课老师
            parm[5].Value = laboratory.syrq; //实验日期

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据laboratoryId获取某条实验报告记录*/
        public static ENTITY.Laboratory getSomeLaboratory(int laboratoryId)
        {
            /*构建查询sql*/
            string sql = "select * from Laboratory where laboratoryId=" + laboratoryId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Laboratory laboratory = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                laboratory = new ENTITY.Laboratory();
                laboratory.laboratoryId = Convert.ToInt32(DataRead["laboratoryId"]);
                laboratory.yearObj = Convert.ToInt32(DataRead["yearObj"]);
                laboratory.team = DataRead["team"].ToString();
                laboratory.symc = DataRead["symc"].ToString();
                laboratory.sys = DataRead["sys"].ToString();
                laboratory.teacherObj = DataRead["teacherObj"].ToString();
                laboratory.syrq = Convert.ToDateTime(DataRead["syrq"].ToString());
            }
            return laboratory;
        }

        /*更新实验报告实现*/
        public static bool EditLaboratory(ENTITY.Laboratory laboratory)
        {
            string sql = "update Laboratory set yearObj=@yearObj,team=@team,symc=@symc,sys=@sys,teacherObj=@teacherObj,syrq=@syrq where laboratoryId=@laboratoryId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@team",SqlDbType.VarChar),
             new SqlParameter("@symc",SqlDbType.VarChar),
             new SqlParameter("@sys",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@syrq",SqlDbType.DateTime),
             new SqlParameter("@laboratoryId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = laboratory.yearObj;
            parm[1].Value = laboratory.team;
            parm[2].Value = laboratory.symc;
            parm[3].Value = laboratory.sys;
            parm[4].Value = laboratory.teacherObj;
            parm[5].Value = laboratory.syrq;
            parm[6].Value = laboratory.laboratoryId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除实验报告*/
        public static bool DelLaboratory(string p)
        {
            string sql = "delete from Laboratory where laboratoryId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询实验报告*/
        public static DataSet GetLaboratory(string strWhere)
        {
            try
            {
                string strSql = "select * from Laboratory" + strWhere + " order by laboratoryId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询实验报告*/
        public static System.Data.DataTable GetLaboratory(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Laboratory";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "laboratoryId", strShow, strSql, strWhere, " laboratoryId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllLaboratory()
        {
            try
            {
                string strSql = "select * from Laboratory";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
