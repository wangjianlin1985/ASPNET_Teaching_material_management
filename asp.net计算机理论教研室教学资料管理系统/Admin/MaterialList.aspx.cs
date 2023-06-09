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
    public partial class MaterialList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindyearObj();
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
                if (Request["materialName"] != null && Request["materialName"].ToString() != "")
                {
                    sqlstr += "  and materialName like '%" + Request["materialName"].ToString() + "%'";
                    materialName.Text = Request["materialName"].ToString();
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

        protected void BtnMaterialAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("MaterialEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllMaterial.DelMaterial(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "MaterialList.aspx");
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
            DataTable dsLog = BLL.bllMaterial.GetMaterial(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpMaterial.DataSource = dsLog;
            RpMaterial.DataBind();
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
        protected void RpMaterial_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllMaterial.DelMaterial((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "MaterialList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "MaterialList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "MaterialList.aspx");
                }
            }
        }
        public string GetYearyearObj(string yearObj)
        {
            return BLL.bllYear.getSomeYear(int.Parse(yearObj)).yearName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("MaterialList.aspx?yearObj=" + yearObj.SelectedValue.Trim()+ "&&termInfo=" + termInfo.Text.Trim()+ "&&materialName=" + materialName.Text.Trim()+ "&&putDate=" + putDate.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet materialDataSet = BLL.bllMaterial.GetMaterial(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='6'>教学资料记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>学年</th>");
            sb.Append("<th>学期</th>");
            sb.Append("<th>资料名称</th>");
            sb.Append("<th>归档日期</th>");
            sb.Append("<th>存放位置</th>");
            sb.Append("<th>经手人</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < materialDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = materialDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + BLL.bllYear.getSomeYear(Convert.ToInt32(dr["yearObj"])).yearName + "</td>");
                sb.Append("<td>" + dr["termInfo"].ToString() + "</td>");
                sb.Append("<td>" + dr["materialName"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["putDate"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["putPlace"].ToString() + "</td>");
                sb.Append("<td>" + dr["handMan"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "教学资料记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
