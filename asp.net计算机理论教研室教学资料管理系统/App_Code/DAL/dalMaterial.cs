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
    public class dalMaterial
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӽ�ѧ����ʵ��*/
        public static bool AddMaterial(ENTITY.Material material)
        {
            string sql = "insert into Material(yearObj,termInfo,materialName,putDate,putPlace,handMan) values(@yearObj,@termInfo,@materialName,@putDate,@putPlace,@handMan)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@termInfo",SqlDbType.VarChar),
             new SqlParameter("@materialName",SqlDbType.VarChar),
             new SqlParameter("@putDate",SqlDbType.DateTime),
             new SqlParameter("@putPlace",SqlDbType.VarChar),
             new SqlParameter("@handMan",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = material.yearObj; //ѧ��
            parm[1].Value = material.termInfo; //ѧ��
            parm[2].Value = material.materialName; //��������
            parm[3].Value = material.putDate; //�鵵����
            parm[4].Value = material.putPlace; //���λ��
            parm[5].Value = material.handMan; //������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����materialId��ȡĳ����ѧ���ϼ�¼*/
        public static ENTITY.Material getSomeMaterial(int materialId)
        {
            /*������ѯsql*/
            string sql = "select * from Material where materialId=" + materialId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Material material = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                material = new ENTITY.Material();
                material.materialId = Convert.ToInt32(DataRead["materialId"]);
                material.yearObj = Convert.ToInt32(DataRead["yearObj"]);
                material.termInfo = DataRead["termInfo"].ToString();
                material.materialName = DataRead["materialName"].ToString();
                material.putDate = Convert.ToDateTime(DataRead["putDate"].ToString());
                material.putPlace = DataRead["putPlace"].ToString();
                material.handMan = DataRead["handMan"].ToString();
            }
            return material;
        }

        /*���½�ѧ����ʵ��*/
        public static bool EditMaterial(ENTITY.Material material)
        {
            string sql = "update Material set yearObj=@yearObj,termInfo=@termInfo,materialName=@materialName,putDate=@putDate,putPlace=@putPlace,handMan=@handMan where materialId=@materialId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@termInfo",SqlDbType.VarChar),
             new SqlParameter("@materialName",SqlDbType.VarChar),
             new SqlParameter("@putDate",SqlDbType.DateTime),
             new SqlParameter("@putPlace",SqlDbType.VarChar),
             new SqlParameter("@handMan",SqlDbType.VarChar),
             new SqlParameter("@materialId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = material.yearObj;
            parm[1].Value = material.termInfo;
            parm[2].Value = material.materialName;
            parm[3].Value = material.putDate;
            parm[4].Value = material.putPlace;
            parm[5].Value = material.handMan;
            parm[6].Value = material.materialId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����ѧ����*/
        public static bool DelMaterial(string p)
        {
            string sql = "delete from Material where materialId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��ѧ����*/
        public static DataSet GetMaterial(string strWhere)
        {
            try
            {
                string strSql = "select * from Material" + strWhere + " order by materialId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��ѧ����*/
        public static System.Data.DataTable GetMaterial(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Material";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "materialId", strShow, strSql, strWhere, " materialId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllMaterial()
        {
            try
            {
                string strSql = "select * from Material";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
