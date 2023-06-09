using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�ɼ�ҵ���߼���ʵ��*/
    public class dalScore
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӳɼ�ʵ��*/
        public static bool AddScore(ENTITY.Score score)
        {
            string sql = "insert into Score(yearObj,teamInfo,courseNo,courseName,studentNo,studentName,chengji) values(@yearObj,@teamInfo,@courseNo,@courseName,@studentNo,@studentName,@chengji)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@teamInfo",SqlDbType.VarChar),
             new SqlParameter("@courseNo",SqlDbType.VarChar),
             new SqlParameter("@courseName",SqlDbType.VarChar),
             new SqlParameter("@studentNo",SqlDbType.VarChar),
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@chengji",SqlDbType.Float)
            };
            /*��������ֵ*/
            parm[0].Value = score.yearObj; //ѧ��
            parm[1].Value = score.teamInfo; //ѧ��
            parm[2].Value = score.courseNo; //�γ̱��
            parm[3].Value = score.courseName; //�γ�����
            parm[4].Value = score.studentNo; //ѧ��ѧ��
            parm[5].Value = score.studentName; //ѧ������
            parm[6].Value = score.chengji; //ѧ���ɼ�

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����scoreId��ȡĳ���ɼ���¼*/
        public static ENTITY.Score getSomeScore(int scoreId)
        {
            /*������ѯsql*/
            string sql = "select * from Score where scoreId=" + scoreId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Score score = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���³ɼ�ʵ��*/
        public static bool EditScore(ENTITY.Score score)
        {
            string sql = "update Score set yearObj=@yearObj,teamInfo=@teamInfo,courseNo=@courseNo,courseName=@courseName,studentNo=@studentNo,studentName=@studentName,chengji=@chengji where scoreId=@scoreId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
            parm[0].Value = score.yearObj;
            parm[1].Value = score.teamInfo;
            parm[2].Value = score.courseNo;
            parm[3].Value = score.courseName;
            parm[4].Value = score.studentNo;
            parm[5].Value = score.studentName;
            parm[6].Value = score.chengji;
            parm[7].Value = score.scoreId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���ɼ�*/
        public static bool DelScore(string p)
        {
            string sql = "delete from Score where scoreId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�ɼ�*/
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

        /*��ѯ�ɼ�*/
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
