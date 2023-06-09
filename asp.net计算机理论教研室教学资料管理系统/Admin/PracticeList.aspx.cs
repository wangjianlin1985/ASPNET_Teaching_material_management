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
    public partial class PracticeList : System.Web.UI.Page
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
                if (Request["studentName"] != null && Request["studentName"].ToString() != "")
                {
                    sqlstr += "  and studentName like '%" + Request["studentName"].ToString() + "%'";
                    studentName.Text = Request["studentName"].ToString();
                }
                if (Request["sxdw"] != null && Request["sxdw"].ToString() != "")
                {
                    sqlstr += "  and sxdw like '%" + Request["sxdw"].ToString() + "%'";
                    sxdw.Text = Request["sxdw"].ToString();
                }
                if (Request["sxrq"] != null && Request["sxrq"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,sxrq,120) like '" + Request["sxrq"].ToString() + "%'";
                    sxrq.Text = Request["sxrq"].ToString();
                }
                if (Request["teacherObj"] != null && Request["teacherObj"].ToString() != "")
                {
                    sqlstr += "  and teacherObj='" + Request["teacherObj"].ToString() + "'";
                    teacherObj.SelectedValue = Request["teacherObj"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindyearObj()
        {
            ListItem li = new ListItem("������", "0");
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
            ListItem li = new ListItem("������", "");
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

        protected void BtnPracticeAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("PracticeEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllPractice.DelPractice(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "PracticeList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "ɾ��ʧ��..");
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
            DataTable dsLog = BLL.bllPractice.GetPractice(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpPractice.DataSource = dsLog;
            RpPractice.DataBind();
            PageMes.Text = string.Format("[ÿҳ<font color=green>{0}</font>�� ��<font color=red>{1}</font>ҳ����<font color=green>{2}</font>ҳ   ��<font color=green>{3}</font>��]", PageSize, NowPage, AllPage, DataCount);
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
        protected void RpPractice_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllPractice.DelPractice((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "PracticeList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "PracticeList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "PracticeList.aspx");
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
            Response.Redirect("PracticeList.aspx?yearObj=" + yearObj.SelectedValue.Trim()+ "&&studentName=" + studentName.Text.Trim()+ "&&sxdw=" + sxdw.Text.Trim()+ "&&sxrq=" + sxrq.Text.Trim() + "&&teacherObj=" + teacherObj.SelectedValue.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet practiceDataSet = BLL.bllPractice.GetPractice(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='5'>ʵϰ�����¼</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>ѧ��</th>");
            sb.Append("<th>ѧ������</th>");
            sb.Append("<th>ʵϰ��λ</th>");
            sb.Append("<th>ʵϰ����</th>");
            sb.Append("<th>ָ����ʦ</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < practiceDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = practiceDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + BLL.bllYear.getSomeYear(Convert.ToInt32(dr["yearObj"])).yearName + "</td>");
                sb.Append("<td>" + dr["studentName"].ToString() + "</td>");
                sb.Append("<td>" + dr["sxdw"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["sxrq"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + BLL.bllTeacher.getSomeTeacher(dr["teacherObj"].ToString()).name + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "ʵϰ�����¼.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
