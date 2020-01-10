<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="ManegeKaoHe.aspx.cs" Inherits="user_ManegeKaoHe" %>

<%-- 
    <%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="ChuQin.aspx.cs" Inherits="user_ChuQin" %>
<%@ Register Assembly="EeekSoft.Web.PopupWin" Namespace="EeekSoft.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="_head" Runat="Server">
    
    --%>
<asp:Content ID="Content1" ContentPlaceHolderID="_head" runat="Server">
      <script type="text/javascript">
          function checkdata() {

              var start = document.getElementById("startime").value;
              if (start == "") {

                  alert("请输入开始时间!");
                  return false;
              }
              var end = document.getElementById("endtime").value;
              if (end == "") {

                  alert("请输入截止日期!");
                  return false;
              }
          }
          function checkdata1() {

              var start = document.getElementById("adddate").value;
              if (start == "") {

                  alert("请输入时间!");
                  return false;
              }
             
          }
          function checklength1(length) {
              var v = document.getElementById("jihua").value;
              if (v.length > 300) {
                  document.getElementById("jihua").value = "";
                  alert('输入文字不超过300个字符');
              }
              return false;
          }
          function checklength2(length)
          {
              var v = document.getElementById("wancheng").value;
              if (v.length > 400) {
                  document.getElementById("wancheng").value = "";
                  alert('输入文字不超过400个字符');
              }
              return false;
          }
          function check() {


              var startnian = document.getElementById("tb_nian").value;
              if (startnian == "") {

                  alert("请输入年份!");
                  return false;
              }
          }
          function LimitNum() {
              var result = false;
              if ((event.keyCode > 47 && event.keyCode < 58 || event.keyCode == 46)) //大小键盘的数字key都是一样的
              {
                  result = true;
              }
              return result;
          }
      </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="position" >
     <div style="padding-left: 10px; padding-top: 15px">
        当前位置：下属信息管理&nbsp;&gt;&gt;&nbsp;管理工作考核

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="mainContent" ClientIDMode="Static">
    <div style="margin-left: 40px;text-align:center">
        <table>
            <tr>
                <td>
                    <asp:linkbutton ID="seek" runat="server" OnClick="seek_Click"  >批阅下属考核表</asp:linkbutton>
                    &nbsp;&nbsp;
                </td>
                 <td>
                     <asp:LinkButton ID="addtianjia" runat="server" OnClick="addtianjia_Click" >添加下属考核表</asp:LinkButton>
                     &nbsp;&nbsp;
                </td>
                <td>
                <asp:LinkButton ID="seek_fen" runat="server" OnClick="seek_fen_Click">工作考核总得分统计</asp:LinkButton>
                    </td>
            </tr>
        </table>
        <table style="width: 90%;" runat="server" id="seektab">
            <tr>
                <td>
                    下属：
                
                    <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="name" DataValueField="name" ></asp:DropDownList>
                    
                </td>
                 <td>
                    考勤位置：
                </td>
                <td>
                   <asp:DropDownList ID="ddr_address" runat="server" DataSourceID="SqlDataSource1" DataTextField="location" DataValueField="location" Width="150px"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.; Initial Catalog=KaoQin; Integrated Security=True" SelectCommand="SELECT　[location] FROM [Location]" ProviderName="System.Data.SqlClient"></asp:SqlDataSource> 
                    <%--
                        <asp:DropDownList ID="ddr_address" runat="server" DataSourceID="SqlDataSource1" DataTextField="location" DataValueField="location" Width="150px"></asp:DropDownList>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.;Initial Catalog=KaoQin;Integrated Security=True" SelectCommand="SELECT [location] FROM [Location]" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>

                        --%>

                </td>
                <td>
                    班次：
                </td>
                <td>
                    <asp:DropDownList ID="ddr_banci" runat="server" Width="150px">
                        <asp:ListItem>班次1</asp:ListItem>
                        <asp:ListItem>班次2</asp:ListItem>
                        <asp:ListItem>班次3</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>开始时间：
               
                    <asp:TextBox ID="startime" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">打开日历</asp:LinkButton>
          
                </td>
                <td>结束时间：
                
                    <asp:TextBox ID="endtime" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">打开日历</asp:LinkButton>

                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="查看" OnClick="Button1_Click" Width="100px" OnClientClick=" return checkdata() " />
                </td>
               
            </tr>
            </table>
        <table style="width: 90%;" runat="server" id="yuangongxinxi">
            <tr>
                   
                   <td>
                       工号：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       级别：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       部门：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       上级：<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       入职：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   </td>
                   
               </tr>
             <tr>
                <td style="text-align:center; padding-left:160px" colspan="5" >
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar1_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar2_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                 

            </tr>
        </table>

         <table style="width: 90%; padding-top: 5px;  text-align:center " id="addZhouJiHua" runat="server" >

               <tr>
                 <td>
                    下属：
                </td>
                <td>
                    <asp:DropDownList ID="ddl_name2" runat="server" ></asp:DropDownList>
                    
                </td>
             </tr>
            <tr>
                <td style="width: 100px">填写时间
                </td>
                <td style= "width: 150px">周计划
                </td>
                <td style= "width: 150px">目标
                </td>
                <td style= "width:50px">占比
                </td>
                <td style= "width: 150px">实施情况
                </td>
                <td style= "width:50px">结果
                </td>
                <td style= "width: 80px"></td>
            </tr>
           
           <tr>

                <td  style="width: 100px"  >
                    <asp:TextBox ID="z_time" runat="server" ReadOnly="true" Width="80px" align="center"></asp:TextBox>

                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">
                        <br />
                       打开日历</asp:LinkButton>
                </td>
                <td  style= "width: 150px">
                    <asp:TextBox ID="z_jihua" runat="server" TextMode="MultiLine" onkeyup="checklength1(this) " Height="80px"  Width="250px" ></asp:TextBox>
                </td>
                <td  style= "width: 150px">
                    <asp:TextBox ID="z_mubiao" runat="server" TextMode="MultiLine" onkeyup="checklength2(this)" Height="80px" Width="250px"></asp:TextBox>

                </td>
                <td style= "width: 50px">
                    <asp:TextBox ID="z_zhanbi" runat="server" TextMode="MultiLine" Height="80px" Width="50px"></asp:TextBox>
                </td>
                <td style= "width: 150px">
                    <asp:TextBox ID="z_shishiqingkuang" runat="server" TextMode="MultiLine" onkeyup="checklength3(this)" Height="80px" Width="250px"></asp:TextBox>
                </td>
                <td style= "width: 50px">
                    <asp:TextBox ID="z_jieguo" runat="server" TextMode="MultiLine" Height="80px" Width="50px"></asp:TextBox>
                </td>
                <td style= "width: 80px">
              
                         <asp:Button ID="Btnzhou" runat="server" Text="提交" Width="80px" OnClick="Btnzhou_Click" OnClientClick="return checkdatazhou()"  />
                       
                             <%--    <asp:Button ID="Btnzhou" runat="server" Text="提交" Width="80px"  OnCommand="Btnzhou_Command" OnClientClick="return checkdatazhou()" CommandArgument='<%# Eval("id") %>'  CommandName="Clicked" />   --%>
                               </td>
            </tr>
            
             <tr style="text-align: center">
                <td style="text-align: center; padding-left: 40%" colspan="6">
                    <asp:Calendar ID="Calendar4" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar4_SelectionChanged"  >
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                
            </tr>
            
             <tr>
                <td style="width: 100px"   >填写时间
                </td>
                <td  style= "width: 150px" >当天计划
                </td>
                <td style= "width: 150px" >目标
                </td>
                <td style= "width:50px" >工时
                </td>
                <td style= "width: 150px">当天工作内容
                </td>
                <td style= "width:50px">结果
                </td>
                <td style= "width: 80px"></td>
            </tr>
             
            <tr>

                <td style="width: 100px" >
                    <asp:TextBox ID="r_time" runat="server" ReadOnly="true"  Width="80px" align="center"></asp:TextBox>

                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">
                         <br />
                        打开日历</asp:LinkButton>
                </td>
                <td style= "width: 150px">
                    <asp:TextBox ID="r_jihua" runat="server" TextMode="MultiLine" onkeyup="checklength4(this) " Height="80px" Width="250px"></asp:TextBox>
                </td>
                <td style= "width: 150px">
                    <asp:TextBox ID="r_mubiao" runat="server" TextMode="MultiLine" onkeyup="checklength5(this)" Height="80px" Width="250px"></asp:TextBox>

                </td>
                <td style= "width:50px">
                    <asp:TextBox ID="r_gongshi" runat="server" TextMode="MultiLine" Height="80px" Width="50px"></asp:TextBox>
                </td>
                <td style= "width: 150px">
                    <asp:TextBox ID="r_neirong" runat="server" TextMode="MultiLine" onkeyup="checklength6(this)" Height="80px" Width="250px"></asp:TextBox>
                </td>
                <td style= "width:50px">
                    <asp:TextBox ID="r_jieguo" runat="server" TextMode="MultiLine" Height="80px" Width="50px"></asp:TextBox>
                </td>
                <td  style= "width: 80px">
                    <asp:Button ID="Btnri" runat="server" Text="提交" Width="80px" OnClick="Btnri_Click" OnClientClick="return checkdatari()" />
                </td>
            </tr>

             <tr style="text-align: center">
                <td style="text-align: center; padding-left: 40%" colspan="2">
                    <asp:Calendar ID="Calendar5" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar5_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
            </tr>

         </table>
        <table style="width: 90%; padding-top: 5px; text-align:center " id="addqingjia" runat="server">    
            <tr>
                 <td  style="width: 100px"  >
                    申请请假事项
                </td>
                <td style="width: 140px">
                    开始时间
                </td>
                <td style="width: 140px">
                    结束时间
                </td>
                 <td style="width: 250px">
                    缘由
                </td>
                <td style="width: 200px">
                   申请天数/小时数
                </td>
                <td style="width: 150px">
                   上传凭证
                </td>
                <td style="width: 80px">
                    
                </td>
                
            </tr>
            <tr>
                 <td  style="width: 100px"  >
                    
                    <asp:DropDownList ID="ddl_shixiang" runat="server" Width="100px">
                        <asp:ListItem>因公外出</asp:ListItem>
                        <asp:ListItem>年假</asp:ListItem>
                        <asp:ListItem>事假</asp:ListItem>
                        <asp:ListItem>病假</asp:ListItem>
                        <asp:ListItem>临时假</asp:ListItem>
                        <asp:ListItem>加班</asp:ListItem>
                         <asp:ListItem>异常申报</asp:ListItem>
                    </asp:DropDownList>
                
                </td>
                <td style="width: 140px">
                   
                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">打开日历</asp:LinkButton>
                     <br />
                    <asp:TextBox ID="startdate" runat="server" Width="100px" ReadOnly="true"></asp:TextBox>
                     <br />
                    <asp:DropDownList ID="time11_d1" runat="server">
          
                    </asp:DropDownList>
                    :
                    <asp:DropDownList ID="time11_d2" runat="server">
     
                    </asp:DropDownList>
                       
                </td>
                <td style="width: 140px">
                     <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">打开日历</asp:LinkButton>
                    <br />
                     <asp:TextBox ID="enddate" runat="server" Width="100px" ReadOnly="true" ></asp:TextBox>
                     <br />   
                    <asp:DropDownList ID="time12_d1" runat="server">
          
                    </asp:DropDownList>
                    :
                    <asp:DropDownList ID="time12_d2" runat="server" >
     
                    </asp:DropDownList>
                </td>
                 <td style="width: 250px">
                   <asp:TextBox ID="thing" runat="server" TextMode="MultiLine" onkeyup= "checklength7(this) " Height="100px" style="margin-left: 0px" Width="250px" ></asp:TextBox>
                </td>
                <td style="width: 200px">
                   <asp:TextBox ID="tianall" runat="server"  onkeypress="return(LimitNum())" style="ime-mode:disabled" onpaste="return false" Width="50px"></asp:TextBox>(天、小时)
                     <br />   
                    <br />
                    (请假(天计算)、加班(小时计算)必填,填写数值,如0.5)
                </td>
                <td style="width: 150px">
                <%--     <asp:Image ID ="Image1" runat ="server" />
                    <br />
                    <br />
                --%>
                   &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                    <br />
                    <asp:Button ID="Btn_shangchuan" runat="server" Text="上传文件" OnClick="Btn_shangchuan_Click" />
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td style="width: 80px">
                    <asp:Button ID="Btnshenqing" runat="server" Text="申请"  Width="80px" OnClick="Btnshenqing_Click" OnClientClick="return checkdatashenqing()" />
                </td>
                
            </tr>
            <tr style="text-align: center">
                <td style="text-align: center; padding-left: 40%" colspan="2">
                    <asp:Calendar ID="Calendar6" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar6_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar7" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar7_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
            </tr>
            </table>

        <%-- 
            <table style="width: 90%;" id="addkaohe" runat="server">
            
            <tr>
                 <td>
                    下属：
                </td>
                <td>
                    <asp:DropDownList ID="ddl_name2" runat="server" ></asp:DropDownList>
                    
                </td>
             </tr>
               <tr>
                <td>
                    日期：
                </td>
                
           
                <td>
                    <asp:TextBox ID="adddate" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">打开日历</asp:LinkButton>
                </td>
                </tr>
            <tr>
                 <td>
                    计划：
                </td>
                <td style="width:80%">
                    <asp:TextBox ID="jihua" runat="server" TextMode="MultiLine" Height="80px" onkeyup= "checklength1(this) " Width="321px"></asp:TextBox>
                </td>
                </tr>
            <tr>
                 <td>
                    完成情况：
                </td>
                <td style="width:80%">
                    <asp:TextBox ID="wancheng" runat="server" TextMode="MultiLine" Height="80px" onkeyup= "checklength2(this) " Width="318px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; padding-left: 160px" colspan="6">
                    <asp:Calendar ID="Calendar3" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar3_SelectionChanged" >
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
            </tr>
            
           
            <tr>
                <td colspan="2" style="padding-left:20%">
                    <asp:Button ID="Button2" runat="server" Text="添加"  OnClientClick=" return checkdata1() " Width="109px" OnClick="Button2_Click" />
                </td>
            </tr>
            </table>
             --%>

           <table style="width:90%" id="defen" runat="server">
              <tr>
                  <td>
                     年份：<asp:TextBox ID="tb_nian" runat="server" onkeypress="return(LimitNum())" style="ime-mode:disabled" onpaste="return false" Width="100px"></asp:TextBox>

                  </td>
                  <td>
                      月份：<asp:DropDownList ID="tb_yue" runat="server" Width="100px">
                          <asp:ListItem>01</asp:ListItem>
                          <asp:ListItem>02</asp:ListItem>
                          <asp:ListItem>03</asp:ListItem>
                          <asp:ListItem>04</asp:ListItem>
                          <asp:ListItem>05</asp:ListItem>
                          <asp:ListItem>06</asp:ListItem>
                          <asp:ListItem>07</asp:ListItem>
                          <asp:ListItem>08</asp:ListItem>
                          <asp:ListItem>09</asp:ListItem>
                          <asp:ListItem>10</asp:ListItem>
                          <asp:ListItem>11</asp:ListItem>
                          <asp:ListItem>12</asp:ListItem>
                      </asp:DropDownList>
                  </td>
                 
                  <td>
                      <asp:Button ID="bnt_defen" runat="server" Text="统计"  OnClientClick=" return check()" OnClick="bnt_defen_Click" Width="87px"  />
                  </td>
                   <td>
                       <asp:Button ID="btn_excel" runat="server" Text="导出到excel" OnClick="btn_excel_Click" OnClientClick=" return check()" />
                   </td>
        
              </tr>
             
               

          </table>

           
      <%--  批阅考核表--%>


        <table style="width:90%" id="zhoujihua" runat="server">
              <tr height =" 40px">
                  <td> 
                   <font size="5" >
                  周计划
                    </font>
                   </td>
            </tr>
         </table>
         <asp:GridView ID="gvShow_zhou" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="90%" HorizontalAlign="Justify" AllowPaging="True" PageSize="4" OnPageIndexChanging="gvShow_zhou_PageIndexChanging"
                OnRowDataBound="gvShow_zhou_RowDataBound" OnRowCommand="gvShow_zhou_RowCommand" OnSorting="gvShow_zhou_Sorting" >

                <Columns>
                     <asp:BoundField DataField="z_time" HeaderText="填写日期" SortExpression="z_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                     <asp:BoundField DataField="z_jihua" HeaderText="周计划" SortExpression="z_jihua"  ItemStyle-Width="15%"  HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>

                    <asp:BoundField DataField="z_mubiao" HeaderText="目标" SortExpression="z_mubiao" ItemStyle-Width="15%" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>

                    <asp:BoundField DataField="z_zhanbi" HeaderText="占比" SortExpression="z_zhanbi" ItemStyle-Width="5%" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="z_shishiqingkuang" HeaderText="实施情况" SortExpression="z_shishiqingkuang" ItemStyle-Width="15%" HeaderStyle-Width="15%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="15%" /></asp:BoundField>
                     <asp:BoundField DataField="z_jieguo" HeaderText="结果" SortExpression="z_jieguo" ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="z_statue" HeaderText="状态"  ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="z_pingyu" HeaderText="评语" SortExpression="z_pingyu" ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                     <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="15%">
                        <ItemTemplate>
                             <asp:LinkButton ID="PingShen_zhou" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>'
                                CommandName="Edit" Text="批阅" HeaderStyle-Width="5%"  ></asp:LinkButton>
                   <%--             <asp:LinkButton ID="lbDelete_zhou" runat="server" CausesValidation="False" CommandName="Delete"
                                CommandArgument='<%# Eval("id") %>' Text="删除" HeaderStyle-Width="5%"></asp:LinkButton>
                      <asp:LinkButton ID="PingShen_zhou"runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>'
                                CommandName="PingShen_zhou"Text="审阅" HeaderStyle-Width="5%"></asp:LinkButton>   
                        --%>  
                            </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#C5E2F2" Height="30" Font-Bold="True" ForeColor="Black" BorderColor="#C5E2F2" />
                <PagerSettings FirstPageText="&nbsp;&nbsp;&nbsp;&nbsp;首页" LastPageText="&nbsp;&nbsp;&nbsp;&nbsp;尾页"
                    Mode="NextPreviousFirstLast" NextPageText="&nbsp;&nbsp;&nbsp;&nbsp;下一页" PreviousPageText="&nbsp;&nbsp;&nbsp;&nbsp;上一页" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <RowStyle Height="25px" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />

            </asp:GridView>
      

           <table style="width:90%" id="rijihua" runat="server">
   
                <tr height =" 40px">
                  <td> 
                   <font size="5" >
                  日计划
                 </font>
                
                    
                   </td>
            </tr>
         </table>

        <asp:GridView ID="gvShow_ri" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="90%" HorizontalAlign="Justify" AllowPaging="True" PageSize="5"
                 OnPageIndexChanging="gvShow_ri_PageIndexChanging"
                OnRowDataBound="gvShow_ri_RowDataBound" OnRowCommand="gvShow_ri_RowCommand" OnSorting="gvShow_ri_Sorting"
                    
              >

                <Columns>
                     <asp:BoundField DataField="r_time" HeaderText="填写日期" SortExpression="r_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                     <asp:BoundField DataField="r_jihua" HeaderText="当日计划" SortExpression="r_jihua"  ItemStyle-Width="15%"  HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>

                    <asp:BoundField DataField="r_mubiao" HeaderText="目标" SortExpression="r_mubiao" ItemStyle-Width="15%" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>

                    <asp:BoundField DataField="r_gongshi" HeaderText="工时" SortExpression="r_gongshi" ItemStyle-Width="5%" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="r_neirong" HeaderText="当天工作内容" SortExpression="r_neirong" ItemStyle-Width="15%" HeaderStyle-Width="15%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="15%" /></asp:BoundField>
                     <asp:BoundField DataField="r_jieguo" HeaderText="结果" SortExpression="r_jieguo" ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="r_statue" HeaderText="状态"  ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="r_pingyu" HeaderText="评语" SortExpression="r_pingyu" ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="r_defen" HeaderText="得分" SortExpression="r_defen" ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="10%">
                        <ItemTemplate>
                           <asp:LinkButton ID="PingShen_ri" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>'
                                CommandName="Edit" Text="批阅" HeaderStyle-Width="5%" ></asp:LinkButton>   
                      
                          


                           </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#C5E2F2" Height="30" Font-Bold="True" ForeColor="Black" BorderColor="#C5E2F2" />
                <PagerSettings FirstPageText="&nbsp;&nbsp;&nbsp;&nbsp;首页" LastPageText="&nbsp;&nbsp;&nbsp;&nbsp;尾页"
                    Mode="NextPreviousFirstLast" NextPageText="&nbsp;&nbsp;&nbsp;&nbsp;下一页" PreviousPageText="&nbsp;&nbsp;&nbsp;&nbsp;上一页" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <RowStyle Height="25px" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />

            </asp:GridView>


        <table style="width:90%" id="qingjia" runat="server">
      
                <tr height =" 40px">
                  <td> 
                   <font size="5" >
                   请假/加班申请
                 </font>
                 
                    
                   </td>
            </tr>
         </table>
           
             <asp:GridView ID="gvShow_qing" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                Width="90%" HorizontalAlign="Justify" AllowPaging="True" PageSize="4"     OnPageIndexChanging="gvShow_qing_PageIndexChanging"
                OnRowDataBound="gvShow_qing_RowDataBound" OnRowCommand="gvShow_qing_RowCommand" OnSorting="gvShow_qing_Sorting" >

                <Columns>
                     <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="True" ReadOnly="True" SortExpression="id" Visible="True" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="q_time" HeaderText="填写日期" SortExpression="q_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                      <asp:BoundField DataField="q_shixiang" HeaderText="事项" SortExpression="q_shixiang" ItemStyle-Width="5%"  HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="q_startdate" HeaderText="请假开始时间" SortExpression="q_startdate" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="q_enddate" HeaderText="请假结束时间" SortExpression="q_enddate" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="q_things" HeaderText="缘由" SortExpression="q_things" ItemStyle-Width="15%"  HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>
                   <asp:TemplateField HeaderText="请假凭证" HeaderStyle-Width="10%">
                        <ItemTemplate>
                    <asp:LinkButton ID="lbChaKan" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>'
                                CommandName="ChaKan" Text="查看凭证" HeaderStyle-Width="10%" ></asp:LinkButton>
                            </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="q_all" HeaderText="申请天数(加班小时)" SortExpression="q_all" ItemStyle-Width="5%"  HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                      <asp:BoundField DataField="q_statue" HeaderText="状态"  ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    
                   
                    <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="15%">
                        <ItemTemplate>
                              <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>' CommandName="Edit" Text="同意"></asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            CommandArgument='<%# Eval("id") %>' Text="不同意"></asp:LinkButton>
                      <asp:LinkButton ID="lbxiugai" runat="server" CausesValidation="False" CommandName="Xiugai"
                            CommandArgument='<%# Eval("id") %>' Text="重新修改"></asp:LinkButton>
                  
                        </ItemTemplate>
                    </asp:TemplateField>
                   
<%-- 
                     <asp:BoundField DataField="q_time" HeaderText="填写日期" SortExpression="q_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                      <asp:BoundField DataField="q_shixiang" HeaderText="事项" SortExpression="q_shixiang" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="q_startdate" HeaderText="请假开始时间" SortExpression="q_startdate" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="q_enddate" HeaderText="请假结束时间" SortExpression="q_enddate" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="q_things" HeaderText="缘由" SortExpression="q_things" ItemStyle-Width="25%"  HeaderStyle-Width="25%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="25%" /></asp:BoundField>
                    <asp:BoundField DataField="q_all" HeaderText="申请天数(加班小时)" SortExpression="q_all" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                      <asp:BoundField DataField="q_statue" HeaderText="状态"  ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                    
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="15%">
                        <ItemTemplate>
                              <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("id") %>' CommandName="Edit" Text="同意"></asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            CommandArgument='<%# Eval("id") %>' Text="不同意"></asp:LinkButton>
                      <asp:LinkButton ID="lbxiugai" runat="server" CausesValidation="False" CommandName="Xiugai"
                            CommandArgument='<%# Eval("id") %>' Text="重新修改"></asp:LinkButton>
                  
                        </ItemTemplate>
                    </asp:TemplateField>

    --%>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#C5E2F2" Height="30" Font-Bold="True" ForeColor="Black" BorderColor="#C5E2F2" />
                <PagerSettings FirstPageText="&nbsp;&nbsp;&nbsp;&nbsp;首页" LastPageText="&nbsp;&nbsp;&nbsp;&nbsp;尾页"
                    Mode="NextPreviousFirstLast" NextPageText="&nbsp;&nbsp;&nbsp;&nbsp;下一页" PreviousPageText="&nbsp;&nbsp;&nbsp;&nbsp;上一页" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <RowStyle Height="25px" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />

            </asp:GridView>
          
           
         <table style="width:90%" id="kaoqin" runat="server">
      
                <tr height =" 40px">
                  <td> 
                   <font size="5" >
                   考勤
                 </font>
                 
                    
                   </td>
            </tr>
         </table>
                <%-- 显示考勤信息--%>
              <asp:Table ID="tb_result" runat="server" Width="90%" ForeColor="Black" >

                   </asp:Table>

           <%-- 查询考核总分--%>
       
         <asp:Table ID="kaohe_result" runat="server" Width="90%" ForeColor="Black" >

        </asp:Table>
        
           
           
        <%-- 
        <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="k_id"
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
                 HorizontalAlign="Justify" AllowPaging="True" PageSize="35" OnPageIndexChanging="gvShow_PageIndexChanging"
                OnRowDataBound="gvShow_RowDataBound" OnRowCommand="gvShow_RowCommand" OnSorting="gvShow_Sorting"  Width="100%"  >

                <Columns>

                   

                   
                     <asp:BoundField DataField="k_time" HeaderText="日期" SortExpression="k_time" ItemStyle-Width="10%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="10%" /></asp:BoundField>
                     <asp:BoundField DataField="k_jihua" HeaderText="计划" SortExpression="k_jihua"  ItemStyle-Width="25%"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="25%" /></asp:BoundField>
                    <asp:BoundField DataField="k_wancheng" HeaderText="完成情况" SortExpression="k_wancheng" ItemStyle-Width="23%" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="23%" /></asp:BoundField>
                    <asp:BoundField DataField="k_pingyu" HeaderText="评语" SortExpression="k_pingyu" ItemStyle-Width="20%" 
                        HeaderStyle-Width="15%"  ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="15%" /></asp:BoundField>
                    <asp:BoundField DataField="k_defen" HeaderText="得分" SortExpression="k_defen" ItemStyle-Width="5%" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="5%" /></asp:BoundField>
                     <asp:BoundField DataField="k_statue" HeaderText="状态" SortExpression="k_statue" ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                    
                    <asp:BoundField DataField="k_id" HeaderText="k_id" InsertVisible="False" ReadOnly="True" SortExpression="k_id" Visible="false" />
                    <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="5%">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("k_id") %>'
                                CommandName="Edit" Text="审阅"  ></asp:LinkButton>   
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#C5E2F2" Height="30" Font-Bold="True" ForeColor="Black" BorderColor="#C5E2F2" />
                <PagerSettings FirstPageText="&nbsp;&nbsp;&nbsp;&nbsp;首页" LastPageText="&nbsp;&nbsp;&nbsp;&nbsp;尾页"
                    Mode="NextPreviousFirstLast" NextPageText="&nbsp;&nbsp;&nbsp;&nbsp;下一页" PreviousPageText="&nbsp;&nbsp;&nbsp;&nbsp;上一页" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <RowStyle Height="10px" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" Height="1px" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            

            </asp:GridView>
            --%>
    
       
    </div>
</asp:Content>
