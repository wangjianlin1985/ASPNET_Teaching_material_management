using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Score_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindyearObj();
            string sqlstr = " where 1=1 ";
            if (Request["yearObj"] != null && Request["yearObj"].ToString() != "0")
            {
                    sqlstr += "  and yearObj=" + Request["yearObj"].ToString();
                    yearObj.SelectedValue = Request["yearObj"].ToString();
            }
            if (Request["teamInfo"] != null && Request["teamInfo"].ToString() != "")
            {
                sqlstr += "  and teamInfo like '%" + Request["teamInfo"].ToString() + "%'";
                teamInfo.Text = Request["teamInfo"].ToString();
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
            if (Request["studentNo"] != null && Request["studentNo"].ToString() != "")
            {
                sqlstr += "  and studentNo like '%" + Request["studentNo"].ToString() + "%'";
                studentNo.Text = Request["studentNo"].ToString();
            }
            if (Request["studentName"] != null && Request["studentName"].ToString() != "")
            {
                sqlstr += "  and studentName like '%" + Request["studentName"].ToString() + "%'";
                studentName.Text = Request["studentName"].ToString();
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
            li = new ListItem(dr["yearName"].ToString(),dr["yearId"].ToString());
            yearObj.Items.Add(li);
        }
        yearObj.SelectedValue = "0";
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
        DataTable dsLog = BLL.bllScore.GetScore(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpScore.DataSource = dsLog;
        RpScore.DataBind();
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
        public string GetYearyearObj(string yearObj)
        {
            return BLL.bllYear.getSomeYear(int.Parse(yearObj)).yearName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?yearObj=" + yearObj.SelectedValue.Trim()+ "&&teamInfo=" + teamInfo.Text.Trim()+ "&&courseNo=" + courseNo.Text.Trim()+ "&&courseName=" + courseName.Text.Trim()+ "&&studentNo=" + studentNo.Text.Trim()+ "&&studentName=" + studentName.Text.Trim());
        }

}
