using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*教学资料业务逻辑层*/
    public class bllMaterial{
        /*添加教学资料*/
        public static bool AddMaterial(ENTITY.Material material)
        {
            return DAL.dalMaterial.AddMaterial(material);
        }

        /*根据materialId获取某条教学资料记录*/
        public static ENTITY.Material getSomeMaterial(int materialId)
        {
            return DAL.dalMaterial.getSomeMaterial(materialId);
        }

        /*更新教学资料*/
        public static bool EditMaterial(ENTITY.Material material)
        {
            return DAL.dalMaterial.EditMaterial(material);
        }

        /*删除教学资料*/
        public static bool DelMaterial(string p)
        {
            return DAL.dalMaterial.DelMaterial(p);
        }

        /*查询教学资料*/
        public static System.Data.DataSet GetMaterial(string strWhere)
        {
            return DAL.dalMaterial.GetMaterial(strWhere);
        }

        /*根据条件分页查询教学资料*/
        public static System.Data.DataTable GetMaterial(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalMaterial.GetMaterial(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的教学资料*/
        public static System.Data.DataSet getAllMaterial()
        {
            return DAL.dalMaterial.getAllMaterial();
        }
    }
}
