using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*教学日历业务逻辑层*/
    public class bllTeaching{
        /*添加教学日历*/
        public static bool AddTeaching(ENTITY.Teaching teaching)
        {
            return DAL.dalTeaching.AddTeaching(teaching);
        }

        /*根据teachingId获取某条教学日历记录*/
        public static ENTITY.Teaching getSomeTeaching(int teachingId)
        {
            return DAL.dalTeaching.getSomeTeaching(teachingId);
        }

        /*更新教学日历*/
        public static bool EditTeaching(ENTITY.Teaching teaching)
        {
            return DAL.dalTeaching.EditTeaching(teaching);
        }

        /*删除教学日历*/
        public static bool DelTeaching(string p)
        {
            return DAL.dalTeaching.DelTeaching(p);
        }

        /*查询教学日历*/
        public static System.Data.DataSet GetTeaching(string strWhere)
        {
            return DAL.dalTeaching.GetTeaching(strWhere);
        }

        /*根据条件分页查询教学日历*/
        public static System.Data.DataTable GetTeaching(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTeaching.GetTeaching(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的教学日历*/
        public static System.Data.DataSet getAllTeaching()
        {
            return DAL.dalTeaching.getAllTeaching();
        }
    }
}
