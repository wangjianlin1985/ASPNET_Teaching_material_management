using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*教学日历业务逻辑层实现*/
    public class dalTeaching
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加教学日历实现*/
        public static bool AddTeaching(ENTITY.Teaching teaching)
        {
            string sql = "insert into Teaching(yearObj,termInfo,courseNo,courseName,teacherObj,className,putDate,putPlace,handMan) values(@yearObj,@termInfo,@courseNo,@courseName,@teacherObj,@className,@putDate,@putPlace,@handMan)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@termInfo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@putDate",SqlDbType.DateTime),
             new SqlParameter("@putPlace",SqlDbType.VarChar),
             new SqlParameter("@handMan",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = teaching.yearObj; //学年
            parm[1].Value = teaching.termInfo; //学期
            parm[2].Value = teaching.courseNo; //课程编号
            parm[3].Value = teaching.courseName; //课程名称
            parm[4].Value = teaching.teacherObj; //任课老师
            parm[5].Value = teaching.className; //任课班级
            parm[6].Value = teaching.putDate; //归档日期
            parm[7].Value = teaching.putPlace; //存放位置
            parm[8].Value = teaching.handMan; //经手人

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据teachingId获取某条教学日历记录*/
        public static ENTITY.Teaching getSomeTeaching(int teachingId)
        {
            /*构建查询sql*/
            string sql = "select * from Teaching where teachingId=" + teachingId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Teaching teaching = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                teaching = new ENTITY.Teaching();
                teaching.teachingId = Convert.ToInt32(DataRead["teachingId"]);
                teaching.yearObj = Convert.ToInt32(DataRead["yearObj"]);
                teaching.termInfo = DataRead["termInfo"].ToString();
                teaching.courseNo = DataRead["courseNo"].ToString();
                teaching.courseName = DataRead["courseName"].ToString();
                teaching.teacherObj = DataRead["teacherObj"].ToString();
                teaching.className = DataRead["className"].ToString();
                teaching.putDate = Convert.ToDateTime(DataRead["putDate"].ToString());
                teaching.putPlace = DataRead["putPlace"].ToString();
                teaching.handMan = DataRead["handMan"].ToString();
            }
            return teaching;
        }

        /*更新教学日历实现*/
        public static bool EditTeaching(ENTITY.Teaching teaching)
        {
            string sql = "update Teaching set yearObj=@yearObj,termInfo=@termInfo,courseNo=@courseNo,courseName=@courseName,teacherObj=@teacherObj,className=@className,putDate=@putDate,putPlace=@putPlace,handMan=@handMan where teachingId=@teachingId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@termInfo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@putDate",SqlDbType.DateTime),
             new SqlParameter("@putPlace",SqlDbType.VarChar),
             new SqlParameter("@handMan",SqlDbType.VarChar),
             new SqlParameter("@teachingId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = teaching.yearObj;
            parm[1].Value = teaching.termInfo;
            parm[2].Value = teaching.courseNo;
            parm[3].Value = teaching.courseName;
            parm[4].Value = teaching.teacherObj;
            parm[5].Value = teaching.className;
            parm[6].Value = teaching.putDate;
            parm[7].Value = teaching.putPlace;
            parm[8].Value = teaching.handMan;
            parm[9].Value = teaching.teachingId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除教学日历*/
        public static bool DelTeaching(string p)
        {
            string sql = "delete from Teaching where teachingId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询教学日历*/
        public static DataSet GetTeaching(string strWhere)
        {
            try
            {
                string strSql = "select * from Teaching" + strWhere + " order by teachingId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询教学日历*/
        public static System.Data.DataTable GetTeaching(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Teaching";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "teachingId", strShow, strSql, strWhere, " teachingId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTeaching()
        {
            try
            {
                string strSql = "select * from Teaching";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
