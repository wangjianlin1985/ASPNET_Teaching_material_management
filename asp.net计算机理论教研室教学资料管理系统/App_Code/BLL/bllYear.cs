using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*学年信息业务逻辑层*/
    public class bllYear{
        /*添加学年信息*/
        public static bool AddYear(ENTITY.Year year)
        {
            return DAL.dalYear.AddYear(year);
        }

        /*根据yearId获取某条学年信息记录*/
        public static ENTITY.Year getSomeYear(int yearId)
        {
            return DAL.dalYear.getSomeYear(yearId);
        }

        /*更新学年信息*/
        public static bool EditYear(ENTITY.Year year)
        {
            return DAL.dalYear.EditYear(year);
        }

        /*删除学年信息*/
        public static bool DelYear(string p)
        {
            return DAL.dalYear.DelYear(p);
        }

        /*查询学年信息*/
        public static System.Data.DataSet GetYear(string strWhere)
        {
            return DAL.dalYear.GetYear(strWhere);
        }

        /*根据条件分页查询学年信息*/
        public static System.Data.DataTable GetYear(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalYear.GetYear(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的学年信息*/
        public static System.Data.DataSet getAllYear()
        {
            return DAL.dalYear.getAllYear();
        }
    }
}
