using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�γ���Ʊ���ҵ���߼���*/
    public class bllCourseReport{
        /*��ӿγ���Ʊ���*/
        public static bool AddCourseReport(ENTITY.CourseReport courseReport)
        {
            return DAL.dalCourseReport.AddCourseReport(courseReport);
        }

        /*����reportId��ȡĳ���γ���Ʊ����¼*/
        public static ENTITY.CourseReport getSomeCourseReport(int reportId)
        {
            return DAL.dalCourseReport.getSomeCourseReport(reportId);
        }

        /*���¿γ���Ʊ���*/
        public static bool EditCourseReport(ENTITY.CourseReport courseReport)
        {
            return DAL.dalCourseReport.EditCourseReport(courseReport);
        }

        /*ɾ���γ���Ʊ���*/
        public static bool DelCourseReport(string p)
        {
            return DAL.dalCourseReport.DelCourseReport(p);
        }

        /*��ѯ�γ���Ʊ���*/
        public static System.Data.DataSet GetCourseReport(string strWhere)
        {
            return DAL.dalCourseReport.GetCourseReport(strWhere);
        }

        /*����������ҳ��ѯ�γ���Ʊ���*/
        public static System.Data.DataTable GetCourseReport(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCourseReport.GetCourseReport(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĿγ���Ʊ���*/
        public static System.Data.DataSet getAllCourseReport()
        {
            return DAL.dalCourseReport.getAllCourseReport();
        }
    }
}
