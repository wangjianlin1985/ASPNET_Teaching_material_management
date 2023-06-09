using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*试卷业务逻辑层实现*/
    public class dalTestPaper
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加试卷实现*/
        public static bool AddTestPaper(ENTITY.TestPaper testPaper)
        {
            string sql = "insert into TestPaper(yearObj,teamInfo,courseNo,courseName,teacherObj,className,examType,putDate,putPlace,handMan) values(@yearObj,@teamInfo,@courseNo,@courseName,@teacherObj,@className,@examType,@putDate,@putPlace,@handMan)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@teamInfo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@examType",SqlDbType.VarChar),
             new SqlParameter("@putDate",SqlDbType.DateTime),
             new SqlParameter("@putPlace",SqlDbType.VarChar),
             new SqlParameter("@handMan",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = testPaper.yearObj; //学年
            parm[1].Value = testPaper.teamInfo; //学期
            parm[2].Value = testPaper.courseNo; //课程编号
            parm[3].Value = testPaper.courseName; //课程名称
            parm[4].Value = testPaper.teacherObj; //任课老师
            parm[5].Value = testPaper.className; //任课班级
            parm[6].Value = testPaper.examType; //考试性质
            parm[7].Value = testPaper.putDate; //归档日期
            parm[8].Value = testPaper.putPlace; //存放位置
            parm[9].Value = testPaper.handMan; //经手人

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据paperId获取某条试卷记录*/
        public static ENTITY.TestPaper getSomeTestPaper(int paperId)
        {
            /*构建查询sql*/
            string sql = "select * from TestPaper where paperId=" + paperId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.TestPaper testPaper = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                testPaper = new ENTITY.TestPaper();
                testPaper.paperId = Convert.ToInt32(DataRead["paperId"]);
                testPaper.yearObj = Convert.ToInt32(DataRead["yearObj"]);
                testPaper.teamInfo = DataRead["teamInfo"].ToString();
                testPaper.courseNo = DataRead["courseNo"].ToString();
                testPaper.courseName = DataRead["courseName"].ToString();
                testPaper.teacherObj = DataRead["teacherObj"].ToString();
                testPaper.className = DataRead["className"].ToString();
                testPaper.examType = DataRead["examType"].ToString();
                testPaper.putDate = Convert.ToDateTime(DataRead["putDate"].ToString());
                testPaper.putPlace = DataRead["putPlace"].ToString();
                testPaper.handMan = DataRead["handMan"].ToString();
            }
            return testPaper;
        }

        /*更新试卷实现*/
        public static bool EditTestPaper(ENTITY.TestPaper testPaper)
        {
            string sql = "update TestPaper set yearObj=@yearObj,teamInfo=@teamInfo,courseNo=@courseNo,courseName=@courseName,teacherObj=@teacherObj,className=@className,examType=@examType,putDate=@putDate,putPlace=@putPlace,handMan=@handMan where paperId=@paperId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@teamInfo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@className",SqlDbType.VarChar),
             new SqlParameter("@examType",SqlDbType.VarChar),
             new SqlParameter("@putDate",SqlDbType.DateTime),
             new SqlParameter("@putPlace",SqlDbType.VarChar),
             new SqlParameter("@handMan",SqlDbType.VarChar),
             new SqlParameter("@paperId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = testPaper.yearObj;
            parm[1].Value = testPaper.teamInfo;
            parm[2].Value = testPaper.courseNo;
            parm[3].Value = testPaper.courseName;
            parm[4].Value = testPaper.teacherObj;
            parm[5].Value = testPaper.className;
            parm[6].Value = testPaper.examType;
            parm[7].Value = testPaper.putDate;
            parm[8].Value = testPaper.putPlace;
            parm[9].Value = testPaper.handMan;
            parm[10].Value = testPaper.paperId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除试卷*/
        public static bool DelTestPaper(string p)
        {
            string sql = "delete from TestPaper where paperId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询试卷*/
        public static DataSet GetTestPaper(string strWhere)
        {
            try
            {
                string strSql = "select * from TestPaper" + strWhere + " order by paperId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询试卷*/
        public static System.Data.DataTable GetTestPaper(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from TestPaper";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "paperId", strShow, strSql, strWhere, " paperId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTestPaper()
        {
            try
            {
                string strSql = "select * from TestPaper";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
