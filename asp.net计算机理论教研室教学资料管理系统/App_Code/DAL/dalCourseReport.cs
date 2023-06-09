using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�γ���Ʊ���ҵ���߼���ʵ��*/
    public class dalCourseReport
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӿγ���Ʊ���ʵ��*/
        public static bool AddCourseReport(ENTITY.CourseReport courseReport)
        {
            string sql = "insert into CourseReport(yearObj,termInfo,courseNo,courseName,teacherObj,className,fenshu,putDate,putPlace,handMan) values(@yearObj,@termInfo,@courseNo,@courseName,@teacherObj,@className,@fenshu,@putDate,@putPlace,@handMan)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = courseReport.yearObj; //ѧ��
            parm[1].Value = courseReport.termInfo; //ѧ��
            parm[2].Value = courseReport.courseNo; //�γ̱��
            parm[3].Value = courseReport.courseName; //�γ�����
            parm[4].Value = courseReport.teacherObj; //�ο���ʦ
            parm[5].Value = courseReport.className; //�οΰ༶
            parm[6].Value = courseReport.fenshu; //����
            parm[7].Value = courseReport.putDate; //�鵵����
            parm[8].Value = courseReport.putPlace; //���λ��
            parm[9].Value = courseReport.handMan; //������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����reportId��ȡĳ���γ���Ʊ����¼*/
        public static ENTITY.CourseReport getSomeCourseReport(int reportId)
        {
            /*������ѯsql*/
            string sql = "select * from CourseReport where reportId=" + reportId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CourseReport courseReport = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���¿γ���Ʊ���ʵ��*/
        public static bool EditCourseReport(ENTITY.CourseReport courseReport)
        {
            string sql = "update CourseReport set yearObj=@yearObj,termInfo=@termInfo,courseNo=@courseNo,courseName=@courseName,teacherObj=@teacherObj,className=@className,fenshu=@fenshu,putDate=@putDate,putPlace=@putPlace,handMan=@handMan where reportId=@reportId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
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
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���γ���Ʊ���*/
        public static bool DelCourseReport(string p)
        {
            string sql = "delete from CourseReport where reportId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�γ���Ʊ���*/
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

        /*��ѯ�γ���Ʊ���*/
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
