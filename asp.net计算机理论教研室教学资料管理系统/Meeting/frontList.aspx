<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Meeting_frontList" %>
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
<title>会议记录查询</title>
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
			    	<li role="presentation" class="active"><a href="#meetingListPanel" aria-controls="meetingListPanel" role="tab" data-toggle="tab">会议记录列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加会议记录</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="meetingListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>开会日期</td><td>负责人</td><td>会议记录员</td><td>会议内容</td><td>参会人员</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpMeeting" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("meetingDate")%></td>
 											<td><%#Eval("fuzeren")%></td>
 											<td><%#Eval("hyjly")%></td>
 											<td><%#Eval("content")%></td>
 											<td><%#Eval("chry")%></td>
 											<td>
 												<a href="frontshow.aspx?meetingId=<%#Eval("meetingId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="meetingEdit('<%#Eval("meetingId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="meetingDelete('<%#Eval("meetingId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>会议记录查询</h1>
		</div>
			<div class="form-group">
				<label for="meetingDate">开会日期:</label>
				<asp:TextBox ID="meetingDate"  runat="server" CssClass="form-control" placeholder="请选择开会日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="fuzeren">负责人:</label>
				<asp:TextBox ID="fuzeren" runat="server"  CssClass="form-control" placeholder="请输入负责人"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="hyjly">会议记录员:</label>
				<asp:TextBox ID="hyjly" runat="server"  CssClass="form-control" placeholder="请输入会议记录员"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="meetingEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;会议记录信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="meetingEditForm" id="meetingEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="meeting_meetingId_edit" class="col-md-3 text-right">记录id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="meeting_meetingId_edit" name="meeting.meetingId" class="form-control" placeholder="请输入记录id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="meeting_meetingDate_edit" class="col-md-3 text-right">开会日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date meeting_meetingDate_edit col-md-12" data-link-field="meeting_meetingDate_edit"  data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="meeting_meetingDate_edit" name="meeting.meetingDate" size="16" type="text" value="" placeholder="请选择开会日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="meeting_fuzeren_edit" class="col-md-3 text-right">负责人:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="meeting_fuzeren_edit" name="meeting.fuzeren" class="form-control" placeholder="请输入负责人">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="meeting_hyjly_edit" class="col-md-3 text-right">会议记录员:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="meeting_hyjly_edit" name="meeting.hyjly" class="form-control" placeholder="请输入会议记录员">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="meeting_content_edit" class="col-md-3 text-right">会议内容:</label>
		  	 <div class="col-md-9">
			    <textarea id="meeting_content_edit" name="meeting.content" rows="8" class="form-control" placeholder="请输入会议内容"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="meeting_chry_edit" class="col-md-3 text-right">参会人员:</label>
		  	 <div class="col-md-9">
			    <textarea id="meeting_chry_edit" name="meeting.chry" rows="8" class="form-control" placeholder="请输入参会人员"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#meetingEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxMeetingModify();">提交</button>
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
/*弹出修改会议记录界面并初始化数据*/
function meetingEdit(meetingId) {
	$.ajax({
		url :  basePath + "Meeting/MeetingController.aspx?action=getMeeting&meetingId=" + meetingId,
		type : "get",
		dataType: "json",
		success : function (meeting, response, status) {
			if (meeting) {
				$("#meeting_meetingId_edit").val(meeting.meetingId);
				$("#meeting_meetingDate_edit").val(meeting.meetingDate);
				$("#meeting_fuzeren_edit").val(meeting.fuzeren);
				$("#meeting_hyjly_edit").val(meeting.hyjly);
				$("#meeting_content_edit").val(meeting.content);
				$("#meeting_chry_edit").val(meeting.chry);
				$('#meetingEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除会议记录信息*/
function meetingDelete(meetingId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Meeting/MeetingController.aspx?action=delete",
			data : {
				meetingId : meetingId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Meeting/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交会议记录信息表单给服务器端修改*/
function ajaxMeetingModify() {
	$.ajax({
		url :  basePath + "Meeting/MeetingController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#meetingEditForm")[0]),
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

    /*开会日期组件*/
    $('.meeting_meetingDate_edit').datetimepicker({
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

