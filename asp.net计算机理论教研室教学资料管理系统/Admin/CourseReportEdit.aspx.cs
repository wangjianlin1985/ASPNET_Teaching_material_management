using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class CourseReportEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindYearyearObj();
                BindTeacherteacherObj();
                if (Request["reportId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindYearyearObj()
        {
            yearObj.DataSource = BLL.bllYear.getAllYear();
            yearObj.DataTextField = "yearName";
            yearObj.DataValueField = "yearId";
            yearObj.DataBind();
        }

        private void BindTeacherteacherObj()
        {
            teacherObj.DataSource = BLL.bllTeacher.getAllTeacher();
            teacherObj.DataTextField = "name";
            teacherObj.DataValueField = "teacherNo";
            teacherObj.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "reportId")))
            {
                ENTITY.CourseReport courseReport = BLL.bllCourseReport.getSomeCourseReport(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "reportId")));
                yearObj.SelectedValue = courseReport.yearObj.ToString();
                termInfo.Value = courseReport.termInfo;
                courseNo.Value = courseReport.courseNo;
                courseName.Value = courseReport.courseName;
                teacherObj.SelectedValue = courseReport.teacherObj;
                className.Value = courseReport.className;
                fenshu.Value = courseReport.fenshu.ToString();
                putDate.Text = courseReport.putDate.ToShortDateString();
                putPlace.Value = courseReport.putPlace;
                handMan.Value = courseReport.handMan;
            }
        }

        protected void BtnCourseReportSave_Click(object sender, EventArgs e)
        {
            ENTITY.CourseReport courseReport = new ENTITY.CourseReport();
            courseReport.yearObj = int.Parse(yearObj.SelectedValue);
            courseReport.termInfo = termInfo.Value;
            courseReport.courseNo = courseNo.Value;
            courseReport.courseName = courseName.Value;
            courseReport.teacherObj = teacherObj.SelectedValue;
            courseReport.className = className.Value;
            courseReport.fenshu = int.Parse(fenshu.Value);
            courseReport.putDate = Convert.ToDateTime(putDate.Text);
            courseReport.putPlace = putPlace.Value;
            courseReport.handMan = handMan.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "reportId")))
            {
                courseReport.reportId = int.Parse(Request["reportId"]);
                if (BLL.bllCourseReport.EditCourseReport(courseReport))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"CourseReportEdit.aspx?reportId=" + Request["reportId"] + "\"} else  {location.href=\"CourseReportList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllCourseReport.AddCourseReport(courseReport))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"CourseReportEdit.aspx\"} else  {location.href=\"CourseReportList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseReportList.aspx");
        }
    }
}

