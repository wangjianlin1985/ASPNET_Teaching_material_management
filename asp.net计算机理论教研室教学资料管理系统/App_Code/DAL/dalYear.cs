using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѧ����Ϣҵ���߼���ʵ��*/
    public class dalYear
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧ����Ϣʵ��*/
        public static bool AddYear(ENTITY.Year year)
        {
            string sql = "insert into Year(yearName) values(@yearName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = year.yearName; //ѧ������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����yearId��ȡĳ��ѧ����Ϣ��¼*/
        public static ENTITY.Year getSomeYear(int yearId)
        {
            /*������ѯsql*/
            string sql = "select * from Year where yearId=" + yearId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Year year = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                year = new ENTITY.Year();
                year.yearId = Convert.ToInt32(DataRead["yearId"]);
                year.yearName = DataRead["yearName"].ToString();
            }
            return year;
        }

        /*����ѧ����Ϣʵ��*/
        public static bool EditYear(ENTITY.Year year)
        {
            string sql = "update Year set yearName=@yearName where yearId=@yearId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearName",SqlDbType.VarChar),
             new SqlParameter("@yearId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = year.yearName;
            parm[1].Value = year.yearId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧ����Ϣ*/
        public static bool DelYear(string p)
        {
            string sql = "delete from Year where yearId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯѧ����Ϣ*/
        public static DataSet GetYear(string strWhere)
        {
            try
            {
                string strSql = "select * from Year" + strWhere + " order by yearId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯѧ����Ϣ*/
        public static System.Data.DataTable GetYear(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Year";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "yearId", strShow, strSql, strWhere, " yearId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllYear()
        {
            try
            {
                string strSql = "select * from Year";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
