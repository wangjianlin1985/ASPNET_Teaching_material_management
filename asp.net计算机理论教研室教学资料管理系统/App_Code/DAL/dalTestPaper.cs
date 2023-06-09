using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�Ծ�ҵ���߼���ʵ��*/
    public class dalTestPaper
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����Ծ�ʵ��*/
        public static bool AddTestPaper(ENTITY.TestPaper testPaper)
        {
            string sql = "insert into TestPaper(yearObj,teamInfo,courseNo,courseName,teacherObj,className,examType,putDate,putPlace,handMan) values(@yearObj,@teamInfo,@courseNo,@courseName,@teacherObj,@className,@examType,@putDate,@putPlace,@handMan)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = testPaper.yearObj; //ѧ��
            parm[1].Value = testPaper.teamInfo; //ѧ��
            parm[2].Value = testPaper.courseNo; //�γ̱��
            parm[3].Value = testPaper.courseName; //�γ�����
            parm[4].Value = testPaper.teacherObj; //�ο���ʦ
            parm[5].Value = testPaper.className; //�οΰ༶
            parm[6].Value = testPaper.examType; //��������
            parm[7].Value = testPaper.putDate; //�鵵����
            parm[8].Value = testPaper.putPlace; //���λ��
            parm[9].Value = testPaper.handMan; //������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����paperId��ȡĳ���Ծ��¼*/
        public static ENTITY.TestPaper getSomeTestPaper(int paperId)
        {
            /*������ѯsql*/
            string sql = "select * from TestPaper where paperId=" + paperId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.TestPaper testPaper = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*�����Ծ�ʵ��*/
        public static bool EditTestPaper(ENTITY.TestPaper testPaper)
        {
            string sql = "update TestPaper set yearObj=@yearObj,teamInfo=@teamInfo,courseNo=@courseNo,courseName=@courseName,teacherObj=@teacherObj,className=@className,examType=@examType,putDate=@putDate,putPlace=@putPlace,handMan=@handMan where paperId=@paperId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
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
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���Ծ�*/
        public static bool DelTestPaper(string p)
        {
            string sql = "delete from TestPaper where paperId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�Ծ�*/
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

        /*��ѯ�Ծ�*/
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
