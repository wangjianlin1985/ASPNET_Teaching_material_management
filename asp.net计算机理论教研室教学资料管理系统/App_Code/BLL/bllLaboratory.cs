using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*实验报告业务逻辑层*/
    public class bllLaboratory{
        /*添加实验报告*/
        public static bool AddLaboratory(ENTITY.Laboratory laboratory)
        {
            return DAL.dalLaboratory.AddLaboratory(laboratory);
        }

        /*根据laboratoryId获取某条实验报告记录*/
        public static ENTITY.Laboratory getSomeLaboratory(int laboratoryId)
        {
            return DAL.dalLaboratory.getSomeLaboratory(laboratoryId);
        }

        /*更新实验报告*/
        public static bool EditLaboratory(ENTITY.Laboratory laboratory)
        {
            return DAL.dalLaboratory.EditLaboratory(laboratory);
        }

        /*删除实验报告*/
        public static bool DelLaboratory(string p)
        {
            return DAL.dalLaboratory.DelLaboratory(p);
        }

        /*查询实验报告*/
        public static System.Data.DataSet GetLaboratory(string strWhere)
        {
            return DAL.dalLaboratory.GetLaboratory(strWhere);
        }

        /*根据条件分页查询实验报告*/
        public static System.Data.DataTable GetLaboratory(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalLaboratory.GetLaboratory(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的实验报告*/
        public static System.Data.DataSet getAllLaboratory()
        {
            return DAL.dalLaboratory.getAllLaboratory();
        }
    }
}
