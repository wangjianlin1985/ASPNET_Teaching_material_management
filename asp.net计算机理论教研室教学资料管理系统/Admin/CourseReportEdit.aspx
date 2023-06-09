<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseReportEdit.aspx.cs" Inherits="chengxusheji.Admin.CourseReportEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var termInfo = document.getElementById("termInfo").value;
            if (termInfo == "") {
                alert("������ѧ��...");
                document.getElementById("termInfo").focus();
                return false;
            }

            var courseNo = document.getElementById("courseNo").value;
            if (courseNo == "") {
                alert("������γ̱��...");
                document.getElementById("courseNo").focus();
                return false;
            }

            var courseName = document.getElementById("courseName").value;
            if (courseName == "") {
                alert("������γ�����...");
                document.getElementById("courseName").focus();
                return false;
            }

            var className = document.getElementById("className").value;
            if (className == "") {
                alert("�������οΰ༶...");
                document.getElementById("className").focus();
                return false;
            }

            var fenshu = document.getElementById("fenshu").value;
            if(fenshu == ""){
                alert("���������...");
                document.getElementById("fenshu").focus();
                return false;
            }
            else if (!resc.test(fenshu))
            {
                alert("��������������");
                document.getElementById("fenshu").focus();
                //input.rate.focus();
                return false;
            }

            var putDate = document.getElementById("putDate").value;
            if (putDate == "") {
                alert("������鵵����...");
                document.getElementById("putDate").focus();
                return false;
            }

            var putPlace = document.getElementById("putPlace").value;
            if (putPlace == "") {
                alert("��������λ��...");
                document.getElementById("putPlace").focus();
                return false;
            }

            var handMan = document.getElementById("handMan").value;
            if (handMan == "") {
                alert("�����뾭����...");
                document.getElementById("handMan").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">�γ���Ʊ������ �����༭�γ���Ʊ���</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ѧ�꣺</td>
                    <td width="650px;">
                         <asp:DropDownList ID="yearObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ѧ�ڣ�</td>
                    <td width="650px;">
                         <input id="termInfo" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������ѧ�ڣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �γ̱�ţ�</td>
                    <td width="650px;">
                         <input id="courseNo" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������γ̱�ţ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �γ����ƣ�</td>
                    <td width="650px;">
                         <input id="courseName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������γ����ƣ�</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �ο���ʦ��</td>
                    <td width="650px;">
                         <asp:DropDownList ID="teacherObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �οΰ༶��</td>
                    <td width="650px;">
                         <input id="className" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������οΰ༶��</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ������</td>
                    <td width="650px;">
                         <input id="fenshu" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>�����������</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  �鵵���ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="putDate"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd');"></asp:TextBox></td>                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ���λ�ã�</td>
                    <td width="650px;">
                         <input id="putPlace" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������λ�ã�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �����ˣ�</td>
                    <td width="650px;">
                         <input id="handMan" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�����뾭���ˣ�</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnCourseReportSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnCourseReportSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

