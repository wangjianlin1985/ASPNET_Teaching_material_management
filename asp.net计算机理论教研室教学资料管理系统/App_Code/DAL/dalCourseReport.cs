using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*课程设计报告业务逻辑层实现*/
    public class dalCourseReport
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加课程设计报告实现*/
        public static bool AddCourseReport(ENTITY.CourseReport courseReport)
        {
            string sql = "insert into CourseReport(yearObj,termInfo,courseNo,courseName,teacherObj,className,fenshu,putDate,putPlace,handMan) values(@yearObj,@termInfo,@courseNo,@courseName,@teacherObj,@className,@fenshu,@putDate,@putPlace,@handMan)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@termInfo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@fenshu",SqlDbType.Int),
             new SqlParameter("@putDate",SqlDbType.DateTime),
             new SqlParameter("@putPlace",SqlDbType.VarChar),
             new SqlParameter("@handMan",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = courseReport.yearObj; //学年
            parm[1].Value = courseReport.termInfo; //学期
            parm[2].Value = courseReport.courseNo; //课程编号
            parm[3].Value = courseReport.courseName; //课程名称
            parm[4].Value = courseReport.teacherObj; //任课老师
            parm[5].Value = courseReport.className; //任课班级
            parm[6].Value = courseReport.fenshu; //份数
            parm[7].Value = courseReport.putDate; //归档日期
            parm[8].Value = courseReport.putPlace; //存放位置
            parm[9].Value = courseReport.handMan; //经手人

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据reportId获取某条课程设计报告记录*/
        public static ENTITY.CourseReport getSomeCourseReport(int reportId)
        {
            /*构建查询sql*/
            string sql = "select * from CourseReport where reportId=" + reportId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CourseReport courseReport = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                courseReport = new ENTITY.CourseReport();
                courseReport.reportId = Convert.ToInt32(DataRead["reportId"]);
                courseReport.yearObj = Convert.ToInt32(DataRead["yearObj"]);
                courseReport.termInfo = DataRead["termInfo"].ToString();
                courseReport.courseNo = DataRead["courseNo"].ToString();
                courseReport.courseName = DataRead["courseName"].ToString();
                courseReport.teacherObj = DataRead["teacherObj"].ToString();
                courseReport.className = DataRead["className"].ToString();
                courseReport.fenshu = Convert.ToInt32(DataRead["fenshu"]);
                courseReport.putDate = Convert.ToDateTime(DataRead["putDate"].ToString());
                courseReport.putPlace = DataRead["putPlace"].ToString();
                courseReport.handMan = DataRead["handMan"].ToString();
            }
            return courseReport;
        }

        /*更新课程设计报告实现*/
        public static bool EditCourseReport(ENTITY.CourseReport courseReport)
        {
            string sql = "update CourseReport set yearObj=@yearObj,termInfo=@termInfo,courseNo=@courseNo,courseName=@courseName,teacherObj=@teacherObj,className=@className,fenshu=@fenshu,putDate=@putDate,putPlace=@putPlace,handMan=@handMan where reportId=@reportId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@termInfo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@fenshu",SqlDbType.Int),
             new SqlParameter("@putDate",SqlDbType.DateTime),
             new SqlParameter("@putPlace",SqlDbType.VarChar),
             new SqlParameter("@handMan",SqlDbType.VarChar),
             new SqlParameter("@reportId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = courseReport.yearObj;
            parm[1].Value = courseReport.termInfo;
            parm[2].Value = courseReport.courseNo;
            parm[3].Value = courseReport.courseName;
            parm[4].Value = courseReport.teacherObj;
            parm[5].Value = courseReport.className;
            parm[6].Value = courseReport.fenshu;
            parm[7].Value = courseReport.putDate;
            parm[8].Value = courseReport.putPlace;
            parm[9].Value = courseReport.handMan;
            parm[10].Value = courseReport.reportId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除课程设计报告*/
        public static bool DelCourseReport(string p)
        {
            string sql = "delete from CourseReport where reportId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询课程设计报告*/
        public static DataSet GetCourseReport(string strWhere)
        {
            try
            {
                string strSql = "select * from CourseReport" + strWhere + " order by reportId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询课程设计报告*/
        public static System.Data.DataTable GetCourseReport(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CourseReport";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "reportId", strShow, strSql, strWhere, " reportId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCourseReport()
        {
            try
            {
                string strSql = "select * from CourseReport";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
