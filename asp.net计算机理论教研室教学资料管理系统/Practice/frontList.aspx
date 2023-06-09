<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Practice_frontList" %>
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
<title>实习报告查询</title>
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
			    	<li role="presentation" class="active"><a href="#practiceListPanel" aria-controls="practiceListPanel" role="tab" data-toggle="tab">实习报告列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加实习报告</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="practiceListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>学年</td><td>学生姓名</td><td>实习单位</td><td>实习日期</td><td>指导老师</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpPractice" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#GetYearyearObj(Eval("yearObj").ToString())%></td>
 											<td><%#Eval("studentName")%></td>
 											<td><%#Eval("sxdw")%></td>
 											<td><%#Eval("sxrq")%></td>
 											<td><%#GetTeacherteacherObj(Eval("teacherObj").ToString())%></td>
 											<td>
 												<a href="frontshow.aspx?practiceId=<%#Eval("practiceId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="practiceEdit('<%#Eval("practiceId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="practiceDelete('<%#Eval("practiceId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>实习报告查询</h1>
		</div>
            <div class="form-group">
            	<label for="yearObj_practiceId">学年：</label>
                <asp:DropDownList ID="yearObj" runat="server"  CssClass="form-control" placeholder="请选择学年"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="studentName">学生姓名:</label>
				<asp:TextBox ID="studentName" runat="server"  CssClass="form-control" placeholder="请输入学生姓名"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="sxdw">实习单位:</label>
				<asp:TextBox ID="sxdw" runat="server"  CssClass="form-control" placeholder="请输入实习单位"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="sxrq">实习日期:</label>
				<asp:TextBox ID="sxrq"  runat="server" CssClass="form-control" placeholder="请选择实习日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="teacherObj_practiceId">指导老师：</label>
                <asp:DropDownList ID="teacherObj" runat="server"  CssClass="form-control" placeholder="请选择指导老师"></asp:DropDownList>
            </div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="practiceEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;实习报告信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="practiceEditForm" id="practiceEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="practice_practiceId_edit" class="col-md-3 text-right">记录id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="practice_practiceId_edit" name="practice.practiceId" class="form-control" placeholder="请输入记录id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="practice_yearObj_yearId_edit" class="col-md-3 text-right">学年:</label>
		  	 <div class="col-md-9">
			    <select id="practice_yearObj_yearId_edit" name="practice.yearObj.yearId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="practice_studentName_edit" class="col-md-3 text-right">学生姓名:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="practice_studentName_edit" name="practice.studentName" class="form-control" placeholder="请输入学生姓名">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="practice_sxdw_edit" class="col-md-3 text-right">实习单位:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="practice_sxdw_edit" name="practice.sxdw" class="form-control" placeholder="请输入实习单位">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="practice_sxrq_edit" class="col-md-3 text-right">实习日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date practice_sxrq_edit col-md-12" data-link-field="practice_sxrq_edit"  data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="practice_sxrq_edit" name="practice.sxrq" size="16" type="text" value="" placeholder="请选择实习日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="practice_teacherObj_teacherNo_edit" class="col-md-3 text-right">指导老师:</label>
		  	 <div class="col-md-9">
			    <select id="practice_teacherObj_teacherNo_edit" name="practice.teacherObj.teacherNo" class="form-control">
			    </select>
		  	 </div>
		  </div>
		</form> 
	    <style>#practiceEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxPracticeModify();">提交</button>
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
/*弹出修改实习报告界面并初始化数据*/
function practiceEdit(practiceId) {
	$.ajax({
		url :  basePath + "Practice/PracticeController.aspx?action=getPractice&practiceId=" + practiceId,
		type : "get",
		dataType: "json",
		success : function (practice, response, status) {
			if (practice) {
				$("#practice_practiceId_edit").val(practice.practiceId);
				$.ajax({
					url: basePath + "Year/YearController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(years,response,status) { 
						$("#practice_yearObj_yearId_edit").empty();
						var html="";
		        		$(years).each(function(i,year){
		        			html += "<option value='" + year.yearId + "'>" + year.yearName + "</option>";
		        		});
		        		$("#practice_yearObj_yearId_edit").html(html);
		        		$("#practice_yearObj_yearId_edit").val(practice.yearObjPri);
					}
				});
				$("#practice_studentName_edit").val(practice.studentName);
				$("#practice_sxdw_edit").val(practice.sxdw);
				$("#practice_sxrq_edit").val(practice.sxrq);
				$.ajax({
					url: basePath + "Teacher/TeacherController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(teachers,response,status) { 
						$("#practice_teacherObj_teacherNo_edit").empty();
						var html="";
		        		$(teachers).each(function(i,teacher){
		        			html += "<option value='" + teacher.teacherNo + "'>" + teacher.name + "</option>";
		        		});
		        		$("#practice_teacherObj_teacherNo_edit").html(html);
		        		$("#practice_teacherObj_teacherNo_edit").val(practice.teacherObjPri);
					}
				});
				$('#practiceEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除实习报告信息*/
function practiceDelete(practiceId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Practice/PracticeController.aspx?action=delete",
			data : {
				practiceId : practiceId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Practice/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交实习报告信息表单给服务器端修改*/
function ajaxPracticeModify() {
	$.ajax({
		url :  basePath + "Practice/PracticeController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#practiceEditForm")[0]),
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

    /*实习日期组件*/
    $('.practice_sxrq_edit').datetimepicker({
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

