using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*教学资料业务逻辑层实现*/
    public class dalMaterial
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加教学资料实现*/
        public static bool AddMaterial(ENTITY.Material material)
        {
            string sql = "insert into Material(yearObj,termInfo,materialName,putDate,putPlace,handMan) values(@yearObj,@termInfo,@materialName,@putDate,@putPlace,@handMan)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@termInfo",SqlDbType.VarChar),
             new SqlParameter("@materialName",SqlDbType.VarChar),
             new SqlParameter("@putDate",SqlDbType.DateTime),
             new SqlParameter("@putPlace",SqlDbType.VarChar),
             new SqlParameter("@handMan",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = material.yearObj; //学年
            parm[1].Value = material.termInfo; //学期
            parm[2].Value = material.materialName; //资料名称
            parm[3].Value = material.putDate; //归档日期
            parm[4].Value = material.putPlace; //存放位置
            parm[5].Value = material.handMan; //经手人

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据materialId获取某条教学资料记录*/
        public static ENTITY.Material getSomeMaterial(int materialId)
        {
            /*构建查询sql*/
            string sql = "select * from Material where materialId=" + materialId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Material material = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新教学资料实现*/
        public static bool EditMaterial(ENTITY.Material material)
        {
            string sql = "update Material set yearObj=@yearObj,termInfo=@termInfo,materialName=@materialName,putDate=@putDate,putPlace=@putPlace,handMan=@handMan where materialId=@materialId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@yearObj",SqlDbType.Int),
             new SqlParameter("@termInfo",SqlDbType.VarChar),
             new SqlParameter("@materialName",SqlDbType.VarChar),
             new SqlParameter("@putDate",SqlDbType.DateTime),
             new SqlParameter("@putPlace",SqlDbType.VarChar),
             new SqlParameter("@handMan",SqlDbType.VarChar),
             new SqlParameter("@materialId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = material.yearObj;
            parm[1].Value = material.termInfo;
            parm[2].Value = material.materialName;
            parm[3].Value = material.putDate;
            parm[4].Value = material.putPlace;
            parm[5].Value = material.handMan;
            parm[6].Value = material.materialId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除教学资料*/
        public static bool DelMaterial(string p)
        {
            string sql = "delete from Material where materialId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询教学资料*/
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

        /*查询教学资料*/
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
