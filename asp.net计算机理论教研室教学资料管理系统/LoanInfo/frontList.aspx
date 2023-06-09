<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="LoanInfo_frontList" %>
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
<title>资料借阅查询</title>
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
			    	<li role="presentation" class="active"><a href="#loanInfoListPanel" aria-controls="loanInfoListPanel" role="tab" data-toggle="tab">资料借阅列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加资料借阅</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="loanInfoListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>借阅资料</td><td>借阅人</td><td>借阅日期</td><td>借阅期限</td><td>归还日期</td><td>备注</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpLoanInfo" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#GetMaterialmaterialObj(Eval("materialObj").ToString())%></td>
 											<td><%#GetTeacherteacherObj(Eval("teacherObj").ToString())%></td>
 											<td><%#Eval("borrowDate")%></td>
 											<td><%#Eval("qixian")%></td>
 											<td><%#Eval("returnDate")%></td>
 											<td><%#Eval("memo")%></td>
 											<td>
 												<a href="frontshow.aspx?loadId=<%#Eval("loadId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="loanInfoEdit('<%#Eval("loadId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="loanInfoDelete('<%#Eval("loadId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
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
    		<h1>资料借阅查询</h1>
		</div>
            <div class="form-group">
            	<label for="materialObj_loadId">借阅资料：</label>
                <asp:DropDownList ID="materialObj" runat="server"  CssClass="form-control" placeholder="请选择借阅资料"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="teacherObj_loadId">借阅人：</label>
                <asp:DropDownList ID="teacherObj" runat="server"  CssClass="form-control" placeholder="请选择借阅人"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="borrowDate">借阅日期:</label>
				<asp:TextBox ID="borrowDate"  runat="server" CssClass="form-control" placeholder="请选择借阅日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="returnDate">归还日期:</label>
				<asp:TextBox ID="returnDate" runat="server"  CssClass="form-control" placeholder="请输入归还日期"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="loanInfoEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;资料借阅信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="loanInfoEditForm" id="loanInfoEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="loanInfo_loadId_edit" class="col-md-3 text-right">记录id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="loanInfo_loadId_edit" name="loanInfo.loadId" class="form-control" placeholder="请输入记录id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="loanInfo_materialObj_materialId_edit" class="col-md-3 text-right">借阅资料:</label>
		  	 <div class="col-md-9">
			    <select id="loanInfo_materialObj_materialId_edit" name="loanInfo.materialObj.materialId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="loanInfo_teacherObj_teacherNo_edit" class="col-md-3 text-right">借阅人:</label>
		  	 <div class="col-md-9">
			    <select id="loanInfo_teacherObj_teacherNo_edit" name="loanInfo.teacherObj.teacherNo" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="loanInfo_borrowDate_edit" class="col-md-3 text-right">借阅日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date loanInfo_borrowDate_edit col-md-12" data-link-field="loanInfo_borrowDate_edit"  data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="loanInfo_borrowDate_edit" name="loanInfo.borrowDate" size="16" type="text" value="" placeholder="请选择借阅日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="loanInfo_qixian_edit" class="col-md-3 text-right">借阅期限:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="loanInfo_qixian_edit" name="loanInfo.qixian" class="form-control" placeholder="请输入借阅期限">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="loanInfo_returnDate_edit" class="col-md-3 text-right">归还日期:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="loanInfo_returnDate_edit" name="loanInfo.returnDate" class="form-control" placeholder="请输入归还日期">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="loanInfo_memo_edit" class="col-md-3 text-right">备注:</label>
		  	 <div class="col-md-9">
			    <textarea id="loanInfo_memo_edit" name="loanInfo.memo" rows="8" class="form-control" placeholder="请输入备注"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#loanInfoEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxLoanInfoModify();">提交</button>
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
/*弹出修改资料借阅界面并初始化数据*/
function loanInfoEdit(loadId) {
	$.ajax({
		url :  basePath + "LoanInfo/LoanInfoController.aspx?action=getLoanInfo&loadId=" + loadId,
		type : "get",
		dataType: "json",
		success : function (loanInfo, response, status) {
			if (loanInfo) {
				$("#loanInfo_loadId_edit").val(loanInfo.loadId);
				$.ajax({
					url: basePath + "Material/MaterialController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(materials,response,status) { 
						$("#loanInfo_materialObj_materialId_edit").empty();
						var html="";
		        		$(materials).each(function(i,material){
		        			html += "<option value='" + material.materialId + "'>" + material.materialName + "</option>";
		        		});
		        		$("#loanInfo_materialObj_materialId_edit").html(html);
		        		$("#loanInfo_materialObj_materialId_edit").val(loanInfo.materialObjPri);
					}
				});
				$.ajax({
					url: basePath + "Teacher/TeacherController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(teachers,response,status) { 
						$("#loanInfo_teacherObj_teacherNo_edit").empty();
						var html="";
		        		$(teachers).each(function(i,teacher){
		        			html += "<option value='" + teacher.teacherNo + "'>" + teacher.name + "</option>";
		        		});
		        		$("#loanInfo_teacherObj_teacherNo_edit").html(html);
		        		$("#loanInfo_teacherObj_teacherNo_edit").val(loanInfo.teacherObjPri);
					}
				});
				$("#loanInfo_borrowDate_edit").val(loanInfo.borrowDate);
				$("#loanInfo_qixian_edit").val(loanInfo.qixian);
				$("#loanInfo_returnDate_edit").val(loanInfo.returnDate);
				$("#loanInfo_memo_edit").val(loanInfo.memo);
				$('#loanInfoEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除资料借阅信息*/
function loanInfoDelete(loadId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "LoanInfo/LoanInfoController.aspx?action=delete",
			data : {
				loadId : loadId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "LoanInfo/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交资料借阅信息表单给服务器端修改*/
function ajaxLoanInfoModify() {
	$.ajax({
		url :  basePath + "LoanInfo/LoanInfoController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#loanInfoEditForm")[0]),
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

    /*借阅日期组件*/
    $('.loanInfo_borrowDate_edit').datetimepicker({
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

