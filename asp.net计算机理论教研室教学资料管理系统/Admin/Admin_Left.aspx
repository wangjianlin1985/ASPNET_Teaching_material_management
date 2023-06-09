<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;教师管理</div>
        <div class="MenuNote" style="display:none;" id="TeacherDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="TeacherEdit.aspx" target="main">添加教师</a></li>
                <li><a href="TeacherList.aspx" target="main">教师查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;试卷管理</div>
        <div class="MenuNote" style="display:none;" id="TestPaperDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="TestPaperEdit.aspx" target="main">添加试卷</a></li>
                <li><a href="TestPaperList.aspx" target="main">试卷查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;课程设计报告管理</div>
        <div class="MenuNote" style="display:none;" id="CourseReportDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="CourseReportEdit.aspx" target="main">添加课程设计报告</a></li>
                <li><a href="CourseReportList.aspx" target="main">课程设计报告查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;实习报告管理</div>
        <div class="MenuNote" style="display:none;" id="PracticeDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="PracticeEdit.aspx" target="main">添加实习报告</a></li>
                <li><a href="PracticeList.aspx" target="main">实习报告查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;实验报告管理</div>
        <div class="MenuNote" style="display:none;" id="LaboratoryDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="LaboratoryEdit.aspx" target="main">添加实验报告</a></li>
                <li><a href="LaboratoryList.aspx" target="main">实验报告查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;教学日历管理</div>
        <div class="MenuNote" style="display:none;" id="TeachingDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="TeachingEdit.aspx" target="main">添加教学日历</a></li>
                <li><a href="TeachingList.aspx" target="main">教学日历查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;教学资料管理</div>
        <div class="MenuNote" style="display:none;" id="MaterialDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="MaterialEdit.aspx" target="main">添加教学资料</a></li>
                <li><a href="MaterialList.aspx" target="main">教学资料查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;资料借阅管理</div>
        <div class="MenuNote" style="display:none;" id="LoanInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="LoanInfoEdit.aspx" target="main">添加资料借阅</a></li>
                <li><a href="LoanInfoList.aspx" target="main">资料借阅查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;会议记录管理</div>
        <div class="MenuNote" style="display:none;" id="MeetingDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="MeetingEdit.aspx" target="main">添加会议记录</a></li>
                <li><a href="MeetingList.aspx" target="main">会议记录查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学年信息管理</div>
        <div class="MenuNote" style="display:none;" id="YearDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="YearEdit.aspx" target="main">添加学年信息</a></li>
                <li><a href="YearList.aspx" target="main">学年信息查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;成绩管理</div>
        <div class="MenuNote" style="display:none;" id="ScoreDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ScoreEdit.aspx" target="main">添加成绩</a></li>
                <li><a href="ScoreList.aspx" target="main">成绩查询</a></li> 
            </ul>
        </div>

 
 <!--
         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;客户信息管理</div>
        <div class="MenuNote" style="display:none;" id="Div2" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
          
                <li><a href="M_CusList.aspx" target="main">客户信息列表</a></li>  
            </ul>
        </div>

        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div>
-->
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
