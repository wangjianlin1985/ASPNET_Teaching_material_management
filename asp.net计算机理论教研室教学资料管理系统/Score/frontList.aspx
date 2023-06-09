<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Score_frontList" %>
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
<title>成绩查询</title>
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
			    	<li role="presentation" class="active"><a href="#scoreListPanel" aria-controls="scoreListPanel" role="tab" data-toggle="tab">成绩列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加成绩</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="scoreListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>学年</td><td>学期</td><td>课程编号</td><td>课程名称</td><td>学生学号</td><td>学生姓名</td><td>学生成绩</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpScore" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#GetYearyearObj(Eval("yearObj").ToString())%></td>
 											<td><%#Eval("teamInfo")%></td>
 											<td><%#Eval("courseNo")%></td>
 											<td><%#Eval("courseName")%></td>
 											<td><%#Eval("studentNo")%></td>
 											<td><%#Eval("studentName")%></td>
 											<td><%#Eval("chengji")%></td>
 											<td>
 												<a href="frontshow.aspx?scoreId=<%#Eval("scoreId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="scoreEdit('<%#Eval("scoreId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="scoreDelete('<%#Eval("scoreId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>成绩查询</h1>
		</div>
            <div class="form-group">
            	<label for="yearObj_scoreId">学年：</label>
                <asp:DropDownList ID="yearObj" runat="server"  CssClass="form-control" placeholder="请选择学年"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="teamInfo">学期:</label>
				<asp:TextBox ID="teamInfo" runat="server"  CssClass="form-control" placeholder="请输入学期"></asp:TextBox>
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
				<label for="studentNo">学生学号:</label>
				<asp:TextBox ID="studentNo" runat="server"  CssClass="form-control" placeholder="请输入学生学号"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="studentName">学生姓名:</label>
				<asp:TextBox ID="studentName" runat="server"  CssClass="form-control" placeholder="请输入学生姓名"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="scoreEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;成绩信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="scoreEditForm" id="scoreEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="score_scoreId_edit" class="col-md-3 text-right">记录id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="score_scoreId_edit" name="score.scoreId" class="form-control" placeholder="请输入记录id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="score_yearObj_yearId_edit" class="col-md-3 text-right">学年:</label>
		  	 <div class="col-md-9">
			    <select id="score_yearObj_yearId_edit" name="score.yearObj.yearId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="score_teamInfo_edit" class="col-md-3 text-right">学期:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="score_teamInfo_edit" name="score.teamInfo" class="form-control" placeholder="请输入学期">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="score_courseNo_edit" class="col-md-3 text-right">课程编号:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="score_courseNo_edit" name="score.courseNo" class="form-control" placeholder="请输入课程编号">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="score_courseName_edit" class="col-md-3 text-right">课程名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="score_courseName_edit" name="score.courseName" class="form-control" placeholder="请输入课程名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="score_studentNo_edit" class="col-md-3 text-right">学生学号:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="score_studentNo_edit" name="score.studentNo" class="form-control" placeholder="请输入学生学号">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="score_studentName_edit" class="col-md-3 text-right">学生姓名:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="score_studentName_edit" name="score.studentName" class="form-control" placeholder="请输入学生姓名">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="score_chengji_edit" class="col-md-3 text-right">学生成绩:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="score_chengji_edit" name="score.chengji" class="form-control" placeholder="请输入学生成绩">
			 </div>
		  </div>
		</form> 
	    <style>#scoreEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxScoreModify();">提交</button>
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
/*弹出修改成绩界面并初始化数据*/
function scoreEdit(scoreId) {
	$.ajax({
		url :  basePath + "Score/ScoreController.aspx?action=getScore&scoreId=" + scoreId,
		type : "get",
		dataType: "json",
		success : function (score, response, status) {
			if (score) {
				$("#score_scoreId_edit").val(score.scoreId);
				$.ajax({
					url: basePath + "Year/YearController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(years,response,status) { 
						$("#score_yearObj_yearId_edit").empty();
						var html="";
		        		$(years).each(function(i,year){
		        			html += "<option value='" + year.yearId + "'>" + year.yearName + "</option>";
		        		});
		        		$("#score_yearObj_yearId_edit").html(html);
		        		$("#score_yearObj_yearId_edit").val(score.yearObjPri);
					}
				});
				$("#score_teamInfo_edit").val(score.teamInfo);
				$("#score_courseNo_edit").val(score.courseNo);
				$("#score_courseName_edit").val(score.courseName);
				$("#score_studentNo_edit").val(score.studentNo);
				$("#score_studentName_edit").val(score.studentName);
				$("#score_chengji_edit").val(score.chengji);
				$('#scoreEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除成绩信息*/
function scoreDelete(scoreId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Score/ScoreController.aspx?action=delete",
			data : {
				scoreId : scoreId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Score/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交成绩信息表单给服务器端修改*/
function ajaxScoreModify() {
	$.ajax({
		url :  basePath + "Score/ScoreController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#scoreEditForm")[0]),
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

})
</script>
</body>
</html>

