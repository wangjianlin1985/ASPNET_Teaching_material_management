using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ʵϰ����ҵ���߼���ʵ��*/
    public class dalPractice
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ʵϰ����ʵ��*/
        public static bool AddPractice(ENTITY.Practice practice)
        {
            string sql = "insert into Practice(yearObj,studentName,sxdw,sxrq,teacherObj) values(@yearObj,@studentName,@sxdw,@sxrq,@teacherObj)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@sxdw",SqlDbType.VarChar),
             new SqlParameter("@sxrq",SqlDbType.DateTime),
             new SqlParameter("@teacherObj",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = practice.yearObj; //ѧ��
            parm[1].Value = practice.studentName; //ѧ������
            parm[2].Value = practice.sxdw; //ʵϰ��λ
            parm[3].Value = practice.sxrq; //ʵϰ����
            parm[4].Value = practice.teacherObj; //ָ����ʦ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����practiceId��ȡĳ��ʵϰ�����¼*/
        public static ENTITY.Practice getSomePractice(int practiceId)
        {
            /*������ѯsql*/
            string sql = "select * from Practice where practiceId=" + practiceId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Practice practice = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*����ʵϰ����ʵ��*/
        public static bool EditPractice(ENTITY.Practice practice)
        {
            string sql = "update Practice set yearObj=@yearObj,studentName=@studentName,sxdw=@sxdw,sxrq=@sxrq,teacherObj=@teacherObj where practiceId=@practiceId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@studentName",SqlDbType.VarChar),
             new SqlParameter("@sxdw",SqlDbType.VarChar),
             new SqlParameter("@sxrq",SqlDbType.DateTime),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@practiceId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = practice.yearObj;
            parm[1].Value = practice.studentName;
            parm[2].Value = practice.sxdw;
            parm[3].Value = practice.sxrq;
            parm[4].Value = practice.teacherObj;
            parm[5].Value = practice.practiceId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ʵϰ����*/
        public static bool DelPractice(string p)
        {
            string sql = "delete from Practice where practiceId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯʵϰ����*/
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

        /*��ѯʵϰ����*/
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
