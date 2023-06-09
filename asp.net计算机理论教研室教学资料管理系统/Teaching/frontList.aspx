<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Teaching_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>教学日历查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#teachingListPanel" aria-controls="teachingListPanel" role="tab" data-toggle="tab">教学日历列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加教学日历</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="teachingListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>学年</td><td>学期</td><td>课程编号</td><td>课程名称</td><td>任课老师</td><td>任课班级</td><td>归档日期</td><td>存放位置</td><td>经手人</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpTeaching" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#GetYearyearObj(Eval("yearObj").ToString())%></td>
 											<td><%#Eval("termInfo")%></td>
 											<td><%#Eval("courseNo")%></td>
 											<td><%#Eval("courseName")%></td>
 											<td><%#GetTeacherteacherObj(Eval("teacherObj").ToString())%></td>
 											<td><%#Eval("className")%></td>
 											<td><%#Eval("putDate")%></td>
 											<td><%#Eval("putPlace")%></td>
 											<td><%#Eval("handMan")%></td>
 											<td>
 												<a href="frontshow.aspx?teachingId=<%#Eval("teachingId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="teachingEdit('<%#Eval("teachingId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="teachingDelete('<%#Eval("teachingId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

				    		<div class="row">
					            <div class="col-md-12">
						            <nav class="pull-left">
						                <ul class="pagination">
						                    <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn"
						                      onclick="LBHome_Click">[首页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
						                      onclick="LBUp_Click">[上一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
						                      onclick="LBNext_Click">[下一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn"
						                      onclick="LBEnd_Click">[尾页]</asp:LinkButton>
						                    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
						                    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
						                    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
						                    <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
						                    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						                </ul>
						            </nav>
						            <div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
					            </div>
				            </div> 
				    </div>
				</div>
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>教学日历查询</h1>
		</div>
            <div class="form-group">
            	<label for="yearObj_teachingId">学年：</label>
                <asp:DropDownList ID="yearObj" runat="server"  CssClass="form-control" placeholder="请选择学年"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="termInfo">学期:</label>
				<asp:TextBox ID="termInfo" runat="server"  CssClass="form-control" placeholder="请输入学期"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="courseNo">课程编号:</label>
				<asp:TextBox ID="courseNo" runat="server"  CssClass="form-control" placeholder="请输入课程编号"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="courseName">课程名称:</label>
				<asp:TextBox ID="courseName" runat="server"  CssClass="form-control" placeholder="请输入课程名称"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="teacherObj_teachingId">任课老师：</label>
                <asp:DropDownList ID="teacherObj" runat="server"  CssClass="form-control" placeholder="请选择任课老师"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="className">任课班级:</label>
				<asp:TextBox ID="className" runat="server"  CssClass="form-control" placeholder="请输入任课班级"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="putDate">归档日期:</label>
				<asp:TextBox ID="putDate"  runat="server" CssClass="form-control" placeholder="请选择归档日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="teachingEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;教学日历信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="teachingEditForm" id="teachingEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="teaching_teachingId_edit" class="col-md-3 text-right">记录编号:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="teaching_teachingId_edit" name="teaching.teachingId" class="form-control" placeholder="请输入记录编号" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="teaching_yearObj_yearId_edit" class="col-md-3 text-right">学年:</label>
		  	 <div class="col-md-9">
			    <select id="teaching_yearObj_yearId_edit" name="teaching.yearObj.yearId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teaching_termInfo_edit" class="col-md-3 text-right">学期:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teaching_termInfo_edit" name="teaching.termInfo" class="form-control" placeholder="请输入学期">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teaching_courseNo_edit" class="col-md-3 text-right">课程编号:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teaching_courseNo_edit" name="teaching.courseNo" class="form-control" placeholder="请输入课程编号">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teaching_courseName_edit" class="col-md-3 text-right">课程名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teaching_courseName_edit" name="teaching.courseName" class="form-control" placeholder="请输入课程名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teaching_teacherObj_teacherNo_edit" class="col-md-3 text-right">任课老师:</label>
		  	 <div class="col-md-9">
			    <select id="teaching_teacherObj_teacherNo_edit" name="teaching.teacherObj.teacherNo" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teaching_className_edit" class="col-md-3 text-right">任课班级:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teaching_className_edit" name="teaching.className" class="form-control" placeholder="请输入任课班级">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teaching_putDate_edit" class="col-md-3 text-right">归档日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date teaching_putDate_edit col-md-12" data-link-field="teaching_putDate_edit"  data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="teaching_putDate_edit" name="teaching.putDate" size="16" type="text" value="" placeholder="请选择归档日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teaching_putPlace_edit" class="col-md-3 text-right">存放位置:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teaching_putPlace_edit" name="teaching.putPlace" class="form-control" placeholder="请输入存放位置">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="teaching_handMan_edit" class="col-md-3 text-right">经手人:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="teaching_handMan_edit" name="teaching.handMan" class="form-control" placeholder="请输入经手人">
			 </div>
		  </div>
		</form> 
	    <style>#teachingEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxTeachingModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改教学日历界面并初始化数据*/
function teachingEdit(teachingId) {
	$.ajax({
		url :  basePath + "Teaching/TeachingController.aspx?action=getTeaching&teachingId=" + teachingId,
		type : "get",
		dataType: "json",
		success : function (teaching, response, status) {
			if (teaching) {
				$("#teaching_teachingId_edit").val(teaching.teachingId);
				$.ajax({
					url: basePath + "Year/YearController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(years,response,status) { 
						$("#teaching_yearObj_yearId_edit").empty();
						var html="";
		        		$(years).each(function(i,year){
		        			html += "<option value='" + year.yearId + "'>" + year.yearName + "</option>";
		        		});
		        		$("#teaching_yearObj_yearId_edit").html(html);
		        		$("#teaching_yearObj_yearId_edit").val(teaching.yearObjPri);
					}
				});
				$("#teaching_termInfo_edit").val(teaching.termInfo);
				$("#teaching_courseNo_edit").val(teaching.courseNo);
				$("#teaching_courseName_edit").val(teaching.courseName);
				$.ajax({
					url: basePath + "Teacher/TeacherController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(teachers,response,status) { 
						$("#teaching_teacherObj_teacherNo_edit").empty();
						var html="";
		        		$(teachers).each(function(i,teacher){
		        			html += "<option value='" + teacher.teacherNo + "'>" + teacher.name + "</option>";
		        		});
		        		$("#teaching_teacherObj_teacherNo_edit").html(html);
		        		$("#teaching_teacherObj_teacherNo_edit").val(teaching.teacherObjPri);
					}
				});
				$("#teaching_className_edit").val(teaching.className);
				$("#teaching_putDate_edit").val(teaching.putDate);
				$("#teaching_putPlace_edit").val(teaching.putPlace);
				$("#teaching_handMan_edit").val(teaching.handMan);
				$('#teachingEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除教学日历信息*/
function teachingDelete(teachingId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Teaching/TeachingController.aspx?action=delete",
			data : {
				teachingId : teachingId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Teaching/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交教学日历信息表单给服务器端修改*/
function ajaxTeachingModify() {
	$.ajax({
		url :  basePath + "Teaching/TeachingController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#teachingEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

    /*归档日期组件*/
    $('.teaching_putDate_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd',
    	minView: 2,
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

