using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ʵ�鱨��ҵ���߼���ʵ��*/
    public class dalLaboratory
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ʵ�鱨��ʵ��*/
        public static bool AddLaboratory(ENTITY.Laboratory laboratory)
        {
            string sql = "insert into Laboratory(yearObj,team,symc,sys,teacherObj,syrq) values(@yearObj,@team,@symc,@sys,@teacherObj,@syrq)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@team",SqlDbType.VarChar),
             new SqlParameter("@symc",SqlDbType.VarChar),
             new SqlParameter("@sys",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@syrq",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = laboratory.yearObj; //ѧ��
            parm[1].Value = laboratory.team; //ѧ��
            parm[2].Value = laboratory.symc; //ʵ������
            parm[3].Value = laboratory.sys; //ʵ����
            parm[4].Value = laboratory.teacherObj; //�ο���ʦ
            parm[5].Value = laboratory.syrq; //ʵ������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����laboratoryId��ȡĳ��ʵ�鱨���¼*/
        public static ENTITY.Laboratory getSomeLaboratory(int laboratoryId)
        {
            /*������ѯsql*/
            string sql = "select * from Laboratory where laboratoryId=" + laboratoryId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Laboratory laboratory = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                laboratory = new ENTITY.Laboratory();
                laboratory.laboratoryId = Convert.ToInt32(DataRead["laboratoryId"]);
                laboratory.yearObj = Convert.ToInt32(DataRead["yearObj"]);
                laboratory.team = DataRead["team"].ToString();
                laboratory.symc = DataRead["symc"].ToString();
                laboratory.sys = DataRead["sys"].ToString();
                laboratory.teacherObj = DataRead["teacherObj"].ToString();
                laboratory.syrq = Convert.ToDateTime(DataRead["syrq"].ToString());
            }
            return laboratory;
        }

        /*����ʵ�鱨��ʵ��*/
        public static bool EditLaboratory(ENTITY.Laboratory laboratory)
        {
            string sql = "update Laboratory set yearObj=@yearObj,team=@team,symc=@symc,sys=@sys,teacherObj=@teacherObj,syrq=@syrq where laboratoryId=@laboratoryId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@team",SqlDbType.VarChar),
             new SqlParameter("@symc",SqlDbType.VarChar),
             new SqlParameter("@sys",SqlDbType.VarChar),
             new SqlParameter("@teacherObj",SqlDbType.VarChar),
             new SqlParameter("@syrq",SqlDbType.DateTime),
             new SqlParameter("@laboratoryId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = laboratory.yearObj;
            parm[1].Value = laboratory.team;
            parm[2].Value = laboratory.symc;
            parm[3].Value = laboratory.sys;
            parm[4].Value = laboratory.teacherObj;
            parm[5].Value = laboratory.syrq;
            parm[6].Value = laboratory.laboratoryId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ʵ�鱨��*/
        public static bool DelLaboratory(string p)
        {
            string sql = "delete from Laboratory where laboratoryId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯʵ�鱨��*/
        public static DataSet GetLaboratory(string strWhere)
        {
            try
            {
                string strSql = "select * from Laboratory" + strWhere + " order by laboratoryId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯʵ�鱨��*/
        public static System.Data.DataTable GetLaboratory(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Laboratory";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "laboratoryId", strShow, strSql, strWhere, " laboratoryId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllLaboratory()
        {
            try
            {
                string strSql = "select * from Laboratory";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
