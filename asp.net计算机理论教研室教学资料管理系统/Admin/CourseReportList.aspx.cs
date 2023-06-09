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
    public partial class CourseReportList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindyearObj();
                BindteacherObj();
                string sqlstr = " where 1=1 ";
                if (Request["yearObj"] != null && Request["yearObj"].ToString() != "0")
                {
                    sqlstr += "  and yearObj=" + Request["yearObj"].ToString();
                    yearObj.SelectedValue = Request["yearObj"].ToString();
                }
                if (Request["termInfo"] != null && Request["termInfo"].ToString() != "")
                {
                    sqlstr += "  and termInfo like '%" + Request["termInfo"].ToString() + "%'";
                    termInfo.Text = Request["termInfo"].ToString();
                }
                if (Request["courseNo"] != null && Request["courseNo"].ToString() != "")
                {
                    sqlstr += "  and courseNo like '%" + Request["courseNo"].ToString() + "%'";
                    courseNo.Text = Request["courseNo"].ToString();
                }
                if (Request["courseName"] != null && Request["courseName"].ToString() != "")
                {
                    sqlstr += "  and courseName like '%" + Request["courseName"].ToString() + "%'";
                    courseName.Text = Request["courseName"].ToString();
                }
                if (Request["teacherObj"] != null && Request["teacherObj"].ToString() != "")
                {
                    sqlstr += "  and teacherObj='" + Request["teacherObj"].ToString() + "'";
                    teacherObj.SelectedValue = Request["teacherObj"].ToString();
                }
                if (Request["className"] != null && Request["className"].ToString() != "")
                {
                    sqlstr += "  and className like '%" + Request["className"].ToString() + "%'";
                    className.Text = Request["className"].ToString();
                }
                if (Request["putDate"] != null && Request["putDate"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,putDate,120) like '" + Request["putDate"].ToString() + "%'";
                    putDate.Text = Request["putDate"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindyearObj()
        {
            ListItem li = new ListItem("不限制", "0");
            yearObj.Items.Add(li);
            DataSet yearObjDs = BLL.bllYear.getAllYear();
            for (int i = 0; i < yearObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = yearObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["yearName"].ToString(), dr["yearName"].ToString());
                yearObj.Items.Add(li);
            }
            yearObj.SelectedValue = "0";
        }

        private void BindteacherObj()
        {
            ListItem li = new ListItem("不限制", "");
            teacherObj.Items.Add(li);
            DataSet teacherObjDs = BLL.bllTeacher.getAllTeacher();
            for (int i = 0; i < teacherObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = teacherObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["name"].ToString(), dr["name"].ToString());
                teacherObj.Items.Add(li);
            }
            teacherObj.SelectedValue = "";
        }

        protected void BtnCourseReportAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseReportEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllCourseReport.DelCourseReport(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "CourseReportList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllCourseReport.GetCourseReport(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpCourseReport.DataSource = dsLog;
            RpCourseReport.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpCourseReport_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllCourseReport.DelCourseReport((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "CourseReportList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "CourseReportList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "CourseReportList.aspx");
                }
            }
        }
        public string GetYearyearObj(string yearObj)
        {
            return BLL.bllYear.getSomeYear(int.Parse(yearObj)).yearName;
        }

        public string GetTeacherteacherObj(string teacherObj)
        {
            return BLL.bllTeacher.getSomeTeacher(teacherObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseReportList.aspx?yearObj=" + yearObj.SelectedValue.Trim()+ "&&termInfo=" + termInfo.Text.Trim()+ "&&courseNo=" + courseNo.Text.Trim()+ "&&courseName=" + courseName.Text.Trim() + "&&teacherObj=" + teacherObj.SelectedValue.Trim()+ "&&className=" + className.Text.Trim()+ "&&putDate=" + putDate.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet courseReportDataSet = BLL.bllCourseReport.GetCourseReport(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='11'>课程设计报告记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>编号</th>");
            sb.Append("<th>学年</th>");
            sb.Append("<th>学期</th>");
            sb.Append("<th>课程编号</th>");
            sb.Append("<th>课程名称</th>");
            sb.Append("<th>任课老师</th>");
            sb.Append("<th>任课班级</th>");
            sb.Append("<th>份数</th>");
            sb.Append("<th>归档日期</th>");
            sb.Append("<th>存放位置</th>");
            sb.Append("<th>经手人</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < courseReportDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = courseReportDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["reportId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllYear.getSomeYear(Convert.ToInt32(dr["yearObj"])).yearName + "</td>");
                sb.Append("<td>" + dr["termInfo"].ToString() + "</td>");
                sb.Append("<td>" + dr["courseNo"].ToString() + "</td>");
                sb.Append("<td>" + dr["courseName"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllTeacher.getSomeTeacher(dr["teacherObj"].ToString()).name + "</td>");
                sb.Append("<td>" + dr["className"].ToString() + "</td>");
                sb.Append("<td>" + dr["fenshu"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["putDate"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["putPlace"].ToString() + "</td>");
                sb.Append("<td>" + dr["handMan"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "课程设计报告记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
