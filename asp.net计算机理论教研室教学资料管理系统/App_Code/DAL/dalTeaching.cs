using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��ѧ����ҵ���߼���ʵ��*/
    public class dalTeaching
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӽ�ѧ����ʵ��*/
        public static bool AddTeaching(ENTITY.Teaching teaching)
        {
            string sql = "insert into Teaching(yearObj,termInfo,courseNo,courseName,teacherObj,className,putDate,putPlace,handMan) values(@yearObj,@termInfo,@courseNo,@courseName,@teacherObj,@className,@putDate,@putPlace,@handMan)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = teaching.yearObj; //ѧ��
            parm[1].Value = teaching.termInfo; //ѧ��
            parm[2].Value = teaching.courseNo; //�γ̱��
            parm[3].Value = teaching.courseName; //�γ�����
            parm[4].Value = teaching.teacherObj; //�ο���ʦ
            parm[5].Value = teaching.className; //�οΰ༶
            parm[6].Value = teaching.putDate; //�鵵����
            parm[7].Value = teaching.putPlace; //���λ��
            parm[8].Value = teaching.handMan; //������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����teachingId��ȡĳ����ѧ������¼*/
        public static ENTITY.Teaching getSomeTeaching(int teachingId)
        {
            /*������ѯsql*/
            string sql = "select * from Teaching where teachingId=" + teachingId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Teaching teaching = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���½�ѧ����ʵ��*/
        public static bool EditTeaching(ENTITY.Teaching teaching)
        {
            string sql = "update Teaching set yearObj=@yearObj,termInfo=@termInfo,courseNo=@courseNo,courseName=@courseName,teacherObj=@teacherObj,className=@className,putDate=@putDate,putPlace=@putPlace,handMan=@handMan where teachingId=@teachingId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
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
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����ѧ����*/
        public static bool DelTeaching(string p)
        {
            string sql = "delete from Teaching where teachingId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��ѧ����*/
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

        /*��ѯ��ѧ����*/
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
