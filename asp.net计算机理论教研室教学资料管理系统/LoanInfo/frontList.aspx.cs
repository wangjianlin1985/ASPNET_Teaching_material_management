using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class LoanInfo_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindmaterialObj();
            BindteacherObj();
            string sqlstr = " where 1=1 ";
            if (Request["materialObj"] != null && Request["materialObj"].ToString() != "0")
            {
                    sqlstr += "  and materialObj=" + Request["materialObj"].ToString();
                    materialObj.SelectedValue = Request["materialObj"].ToString();
            }
            if (Request["teacherObj"] != null && Request["teacherObj"].ToString() != "")
            {
                sqlstr += "  and teacherObj='" + Request["teacherObj"].ToString() + "'";
                teacherObj.SelectedValue = Request["teacherObj"].ToString();
            }
            if (Request["borrowDate"] != null && Request["borrowDate"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,borrowDate,120) like '" + Request["borrowDate"].ToString() + "%'";
                borrowDate.Text = Request["borrowDate"].ToString();
            }
            if (Request["returnDate"] != null && Request["returnDate"].ToString() != "")
            {
                sqlstr += "  and returnDate like '%" + Request["returnDate"].ToString() + "%'";
                returnDate.Text = Request["returnDate"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindmaterialObj()
    {
        ListItem li = new ListItem("不限制", "0");
        materialObj.Items.Add(li);
        DataSet materialObjDs = BLL.bllMaterial.getAllMaterial();
        for (int i = 0; i < materialObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = materialObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["materialName"].ToString(),dr["materialId"].ToString());
            materialObj.Items.Add(li);
        }
        materialObj.SelectedValue = "0";
    }

    private void BindteacherObj()
    {
        ListItem li = new ListItem("不限制", "");
        teacherObj.Items.Add(li);
        DataSet teacherObjDs = BLL.bllTeacher.getAllTeacher();
        for (int i = 0; i < teacherObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = teacherObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["name"].ToString(),dr["teacherNo"].ToString());
            teacherObj.Items.Add(li);
        }
        teacherObj.SelectedValue = "";
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
        DataTable dsLog = BLL.bllLoanInfo.GetLoanInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
        RpLoanInfo.DataSource = dsLog;
        RpLoanInfo.DataBind();
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
        public string GetMaterialmaterialObj(string materialObj)
        {
            return BLL.bllMaterial.getSomeMaterial(int.Parse(materialObj)).materialName;
        }

        public string GetTeacherteacherObj(string teacherObj)
        {
            return BLL.bllTeacher.getSomeTeacher(teacherObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?materialObj=" + materialObj.SelectedValue.Trim() + "&&teacherObj=" + teacherObj.SelectedValue.Trim()+ "&&borrowDate=" + borrowDate.Text.Trim()+ "&&returnDate=" + returnDate.Text.Trim());
        }

}
