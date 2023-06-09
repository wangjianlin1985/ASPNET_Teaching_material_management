using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�����¼ҵ���߼���ʵ��*/
    public class dalMeeting
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӻ����¼ʵ��*/
        public static bool AddMeeting(ENTITY.Meeting meeting)
        {
            string sql = "insert into Meeting(meetingDate,fuzeren,hyjly,content,chry) values(@meetingDate,@fuzeren,@hyjly,@content,@chry)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@meetingDate",SqlDbType.DateTime),
             new SqlParameter("@fuzeren",SqlDbType.VarChar),
             new SqlParameter("@hyjly",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@chry",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = meeting.meetingDate; //��������
            parm[1].Value = meeting.fuzeren; //������
            parm[2].Value = meeting.hyjly; //�����¼Ա
            parm[3].Value = meeting.content; //��������
            parm[4].Value = meeting.chry; //�λ���Ա

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����meetingId��ȡĳ�������¼��¼*/
        public static ENTITY.Meeting getSomeMeeting(int meetingId)
        {
            /*������ѯsql*/
            string sql = "select * from Meeting where meetingId=" + meetingId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Meeting meeting = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���»����¼ʵ��*/
        public static bool EditMeeting(ENTITY.Meeting meeting)
        {
            string sql = "update Meeting set meetingDate=@meetingDate,fuzeren=@fuzeren,hyjly=@hyjly,content=@content,chry=@chry where meetingId=@meetingId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@meetingDate",SqlDbType.DateTime),
             new SqlParameter("@fuzeren",SqlDbType.VarChar),
             new SqlParameter("@hyjly",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@chry",SqlDbType.VarChar),
             new SqlParameter("@meetingId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = meeting.meetingDate;
            parm[1].Value = meeting.fuzeren;
            parm[2].Value = meeting.hyjly;
            parm[3].Value = meeting.content;
            parm[4].Value = meeting.chry;
            parm[5].Value = meeting.meetingId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�������¼*/
        public static bool DelMeeting(string p)
        {
            string sql = "delete from Meeting where meetingId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�����¼*/
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

        /*��ѯ�����¼*/
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
