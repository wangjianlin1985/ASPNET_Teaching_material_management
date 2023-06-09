using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*课程设计报告业务逻辑层*/
    public class bllCourseReport{
        /*添加课程设计报告*/
        public static bool AddCourseReport(ENTITY.CourseReport courseReport)
        {
            return DAL.dalCourseReport.AddCourseReport(courseReport);
        }

        /*根据reportId获取某条课程设计报告记录*/
        public static ENTITY.CourseReport getSomeCourseReport(int reportId)
        {
            return DAL.dalCourseReport.getSomeCourseReport(reportId);
        }

        /*更新课程设计报告*/
        public static bool EditCourseReport(ENTITY.CourseReport courseReport)
        {
            return DAL.dalCourseReport.EditCourseReport(courseReport);
        }

        /*删除课程设计报告*/
        public static bool DelCourseReport(string p)
        {
            return DAL.dalCourseReport.DelCourseReport(p);
        }

        /*查询课程设计报告*/
        public static System.Data.DataSet GetCourseReport(string strWhere)
        {
            return DAL.dalCourseReport.GetCourseReport(strWhere);
        }

        /*根据条件分页查询课程设计报告*/
        public static System.Data.DataTable GetCourseReport(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCourseReport.GetCourseReport(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的课程设计报告*/
        public static System.Data.DataSet getAllCourseReport()
        {
            return DAL.dalCourseReport.getAllCourseReport();
        }
    }
}
