using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*会议记录业务逻辑层实现*/
    public class dalMeeting
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加会议记录实现*/
        public static bool AddMeeting(ENTITY.Meeting meeting)
        {
            string sql = "insert into Meeting(meetingDate,fuzeren,hyjly,content,chry) values(@meetingDate,@fuzeren,@hyjly,@content,@chry)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@meetingDate",SqlDbType.DateTime),
             new SqlParameter("@fuzeren",SqlDbType.VarChar),
             new SqlParameter("@hyjly",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@chry",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = meeting.meetingDate; //开会日期
            parm[1].Value = meeting.fuzeren; //负责人
            parm[2].Value = meeting.hyjly; //会议记录员
            parm[3].Value = meeting.content; //会议内容
            parm[4].Value = meeting.chry; //参会人员

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据meetingId获取某条会议记录记录*/
        public static ENTITY.Meeting getSomeMeeting(int meetingId)
        {
            /*构建查询sql*/
            string sql = "select * from Meeting where meetingId=" + meetingId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Meeting meeting = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                meeting = new ENTITY.Meeting();
                meeting.meetingId = Convert.ToInt32(DataRead["meetingId"]);
                meeting.meetingDate = Convert.ToDateTime(DataRead["meetingDate"].ToString());
                meeting.fuzeren = DataRead["fuzeren"].ToString();
                meeting.hyjly = DataRead["hyjly"].ToString();
                meeting.content = DataRead["content"].ToString();
                meeting.chry = DataRead["chry"].ToString();
            }
            return meeting;
        }

        /*更新会议记录实现*/
        public static bool EditMeeting(ENTITY.Meeting meeting)
        {
            string sql = "update Meeting set meetingDate=@meetingDate,fuzeren=@fuzeren,hyjly=@hyjly,content=@content,chry=@chry where meetingId=@meetingId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@meetingDate",SqlDbType.DateTime),
             new SqlParameter("@fuzeren",SqlDbType.VarChar),
             new SqlParameter("@hyjly",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@chry",SqlDbType.VarChar),
             new SqlParameter("@meetingId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = meeting.meetingDate;
            parm[1].Value = meeting.fuzeren;
            parm[2].Value = meeting.hyjly;
            parm[3].Value = meeting.content;
            parm[4].Value = meeting.chry;
            parm[5].Value = meeting.meetingId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除会议记录*/
        public static bool DelMeeting(string p)
        {
            string sql = "delete from Meeting where meetingId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询会议记录*/
        public static DataSet GetMeeting(string strWhere)
        {
            try
            {
                string strSql = "select * from Meeting" + strWhere + " order by meetingId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询会议记录*/
        public static System.Data.DataTable GetMeeting(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Meeting";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "meetingId", strShow, strSql, strWhere, " meetingId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllMeeting()
        {
            try
            {
                string strSql = "select * from Meeting";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
