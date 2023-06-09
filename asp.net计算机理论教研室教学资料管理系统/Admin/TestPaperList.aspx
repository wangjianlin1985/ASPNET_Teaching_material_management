<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPaperList.aspx.cs" Inherits="chengxusheji.Admin.TestPaperList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>试卷列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">试卷管理 》》试卷列表</div>
     <div class="Body_Search">
        学年&nbsp;&nbsp;<asp:DropDownList ID="yearObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        学期&nbsp;&nbsp;<asp:TextBox ID="teamInfo" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        课程编号&nbsp;&nbsp;<asp:TextBox ID="courseNo" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        课程名称&nbsp;&nbsp;<asp:TextBox ID="courseName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        任课老师&nbsp;&nbsp;<asp:DropDownList ID="teacherObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        任课班级&nbsp;&nbsp;<asp:TextBox ID="className" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        归档日期&nbsp;&nbsp; <asp:TextBox ID="putDate"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="导出excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpTestPaper" runat="server" onitemcommand="RpTestPaper_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>选择</th> 
                        <th>学年</th>
                        <th>学期</th>
                        <th>课程编号</th>
                        <th>课程名称</th>
                        <th>任课老师</th>
                        <th>任课班级</th>
                        <th>考试性质</th>
                        <th>归档日期</th>
                        <th>存放位置</th>
                        <th>经手人</th>
                        <th>操作</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("paperId") %>' name="CheckMes" id="DelChecked"/></td>
                  <td align="center"><%#GetYearyearObj(Eval("yearObj").ToString())%></td>
                <td align="center"><%#Eval("teamInfo")%> </td>
                <td align="center"><%#Eval("courseNo")%> </td>
                <td align="center"><%#Eval("courseName")%> </td>
                  <td align="center"><%#GetTeacherteacherObj(Eval("teacherObj").ToString())%></td>
                <td align="center"><%#Eval("className")%> </td>
                <td align="center"><%#Eval("examType")%> </td>
                  <td align="center"><%# Convert.ToDateTime(Eval("putDate")).ToShortDateString() %></td>
                <td align="center"><%#Eval("putPlace")%> </td>
                <td align="center"><%#Eval("handMan")%> </td>
                <td align="center"><a href="TestPaperEdit.aspx?paperId=<%#Eval("paperId") %>"><img src="Images/MillMes_ICO.gif" alt="修改信息..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("paperId")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="全选" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" 删除选中 " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[首页]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[上一页]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[下一页]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[尾页]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="5"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
