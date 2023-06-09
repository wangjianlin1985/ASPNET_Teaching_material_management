using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*成绩业务逻辑层实现*/
    public class dalScore
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加成绩实现*/
        public static bool AddScore(ENTITY.Score score)
        {
            string sql = "insert into Score(yearObj,teamInfo,courseNo,courseName,studentNo,studentName,chengji) values(@yearObj,@teamInfo,@courseNo,@courseName,@studentNo,@studentName,@chengji)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@teamInfo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@studentNo",SqlDbType.VarChar),
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@chengji",SqlDbType.Float)
            };
            /*给参数赋值*/
            parm[0].Value = score.yearObj; //学年
            parm[1].Value = score.teamInfo; //学期
            parm[2].Value = score.courseNo; //课程编号
            parm[3].Value = score.courseName; //课程名称
            parm[4].Value = score.studentNo; //学生学号
            parm[5].Value = score.studentName; //学生姓名
            parm[6].Value = score.chengji; //学生成绩

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据scoreId获取某条成绩记录*/
        public static ENTITY.Score getSomeScore(int scoreId)
        {
            /*构建查询sql*/
            string sql = "select * from Score where scoreId=" + scoreId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Score score = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                score = new ENTITY.Score();
                score.scoreId = Convert.ToInt32(DataRead["scoreId"]);
                score.yearObj = Convert.ToInt32(DataRead["yearObj"]);
                score.teamInfo = DataRead["teamInfo"].ToString();
                score.courseNo = DataRead["courseNo"].ToString();
                score.courseName = DataRead["courseName"].ToString();
                score.studentNo = DataRead["studentNo"].ToString();
                score.studentName = DataRead["studentName"].ToString();
                score.chengji = float.Parse(DataRead["chengji"].ToString());
            }
            return score;
        }

        /*更新成绩实现*/
        public static bool EditScore(ENTITY.Score score)
        {
            string sql = "update Score set yearObj=@yearObj,teamInfo=@teamInfo,courseNo=@courseNo,courseName=@courseName,studentNo=@studentNo,studentName=@studentName,chengji=@chengji where scoreId=@scoreId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@teamInfo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@studentNo",SqlDbType.VarChar),
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@chengji",SqlDbType.Float),
             new SqlParameter("@scoreId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = score.yearObj;
            parm[1].Value = score.teamInfo;
            parm[2].Value = score.courseNo;
            parm[3].Value = score.courseName;
            parm[4].Value = score.studentNo;
            parm[5].Value = score.studentName;
            parm[6].Value = score.chengji;
            parm[7].Value = score.scoreId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除成绩*/
        public static bool DelScore(string p)
        {
            string sql = "delete from Score where scoreId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询成绩*/
        public static DataSet GetScore(string strWhere)
        {
            try
            {
                string strSql = "select * from Score" + strWhere + " order by scoreId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询成绩*/
        public static System.Data.DataTable GetScore(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Score";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "scoreId", strShow, strSql, strWhere, " scoreId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllScore()
        {
            try
            {
                string strSql = "select * from Score";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
