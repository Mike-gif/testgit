<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="edit_ShenQingShenBao.aspx.cs" Inherits="user_edit_ShenQingShenBao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" runat="Server">
    <script type="text/javascript">
        function checkdata() {


            var z_time = document.getElementById("z_time").value;
            if (z_time == "") {

                alert("请选择开始日期!");
                return false;
            }
            var z_jihua = document.getElementById("z_jihua").value;
            if (z_jihua == "") {

                alert("请输入计划内容!");
                return false;
            }


        }
        function checkdatari() {


            var r_time = document.getElementById("r_time").value;
            if (r_time == "") {

                alert("请选择开始日期!");
                return false;
            }
            var r_jihua = document.getElementById("r_jihua").value;
            if (r_jihua == "") {

                alert("请输入计划内容!");
                return false;
            }


        }
        function checkdatazhou() {


            var z_time = document.getElementById("z_time").value;
            if (z_time == "") {

                alert("请选择开始日期!");
                return false;
            }
            var z_jihua = document.getElementById("z_jihua").value;
            if (z_jihua == "") {

                alert("请输入计划内容!");
                return false;
            }


        }
        function checkdatashenqing() {


            var startdate = document.getElementById("startdate").value;
            if (startdate == "") {

                alert("请选择开始日期!");
                return false;
            }
            var enddate = document.getElementById("enddate").value;
            if (enddate == "") {

                alert("请选择结束时间!");
                return false;
            }
            


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
        function checklength1(length) {
            var v = document.getElementById("z_jihua").value;
            if (v.length > 300) {
                document.getElementById("z_jihua").value = "";
                alert('输入文字不得超过200个字符');
            }
            return false;
        }
        function checklength2(length) {
            var v = document.getElementById("z_mubiao").value;
            if (v.length > 300) {
                document.getElementById("z_mubiao").value = "";
                alert('输入文字不得超过200个字符');
            }
            return false;
        }

        function checklength3(length) {
            var v = document.getElementById("z_shishiqingkuang").value;
            if (v.length > 300) {
                document.getElementById("z_shishiqingkuang").value = "";
                alert('输入文字不得超过200个字符');
            }
            return false;
        }
        function checklength4(length) {
            var v = document.getElementById("r_jihua").value;
            if (v.length > 300) {
                document.getElementById("r_jihua").value = "";
                alert('输入文字不得超过200个字符');
            }
            return false;
        }
        function checklength5(length) {
            var v = document.getElementById("r_mubiao").value;
            if (v.length > 300) {
                document.getElementById("r_mubiao").value = "";
                alert('输入文字不得超过200个字符');
            }
            return false;
        }

        function checklength6(length) {
            var v = document.getElementById("r_neirong").value;
            if (v.length > 300) {
                document.getElementById("r_neirong").value = "";
                alert('输入文字不得超过200个字符');
            }
            return false;
        }
        function checklength7(length) {
            var v = document.getElementById("thing").value;
            if (v.length > 300) {
                document.getElementById("thing").value = "";
                alert('输入文字不得超过200个字符');
            }
            return false;
        }
    </script>

    
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="position">
    <div style="padding-left: 10px; padding-top: 15px">
        当前位置：个人信息管理&nbsp;&gt;&gt;&nbsp;个人申请申报

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="mainContent" ClientIDMode="Static">
    <div style="margin-left: 40px; text-align: center" id="div_cont">

        <table>
            <tr>
                <td>姓名：<asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>工号：<asp:TextBox ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>级别：<asp:TextBox ID="TextBox3" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>部门：<asp:TextBox ID="TextBox4" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>上级：<asp:TextBox ID="TextBox5" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>入职：<asp:TextBox ID="TextBox6" runat="server" ReadOnly="true"></asp:TextBox>
                </td>

            </tr>
        </table>
       
        <table style="width: 90%; padding-top: 5px; text-align:center ">
                
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

                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                        <br />
                       打开日历</asp:LinkButton>
                </td>
                <td  style= "width: 150px">
                    <asp:TextBox ID="z_jihua" runat="server" TextMode="MultiLine" onkeyup="checklength1(this) " Height="80px"  Width="250px"></asp:TextBox>
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
                    <asp:Button ID="lbSubmitAddzhou" runat="server" Text="修 改"  class="buttonSubmit" Width="80px" OnClick="lbSubmitAddzhou_Click" OnClientClick="return checkdatazhou()"/>

                </td>
            </tr>
            
             <tr style="text-align: center">
                <td style="text-align: center; padding-left: 40%" colspan="2">
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

                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">
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
  
                     <asp:Button ID="lbSubmitAddri" runat="server" Text="修 改"  class="buttonSubmit" Width="80px" OnClick="lbSubmitAddri_Click" OnClientClick="return checkdatari()"/>
                </td>
            </tr>

             <tr style="text-align: center">
                <td style="text-align: center; padding-left: 40%" colspan="2">
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
        <table style="width: 90%; padding-top: 5px; text-align:center ">    
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
                   申请天数
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
                   
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">打开日历</asp:LinkButton>
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
                     <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">打开日历</asp:LinkButton>
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
                   上传凭证
                </td>
                <td style="width: 80px">
                    <asp:Button ID="lbSubmitAddshenqing" runat="server" Text="修改" class="buttonSubmit" Width="80px" OnClick="lbSubmitAddshenqing_Click" OnClientClick="return checkdatashenqing()" />
                </td>
                
            </tr>
            <tr style="text-align: center">
                <td style="text-align: center; padding-left: 40%" colspan="2">
                    <asp:Calendar ID="Calendar3" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar3_SelectionChanged">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                    <asp:Calendar ID="Calendar4" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar4_SelectionChanged">
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
           
                        <td>
                            <asp:TextBox ID="_ID" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                        </td>
             </tr>
            </table>


 

        <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
            Width="90%" HorizontalAlign="Justify" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvShow_PageIndexChanging"
            OnRowDataBound="gvShow_RowDataBound"  OnSorting="gvShow_Sorting">

            <Columns>


             
                <asp:BoundField DataField="s_time" HeaderText="填写日期" SortExpression="s_time" ItemStyle-Width="20%" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="s_leibie" HeaderText="类别" SortExpression="s_leibie" ItemStyle-Width="25%" HeaderStyle-Width="25%" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="25%" />
                </asp:BoundField>
                <asp:BoundField DataField="s_statue" HeaderText="状态"  ItemStyle-Width="25%" HeaderStyle-Width="25%" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="25%" />
                </asp:BoundField>
                 <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
                <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="30%">
        <%--            <ItemTemplate>
                        <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("s_id") %>'
                            CommandName="Edit" Text="编辑" HeaderStyle-Width="15%"></asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            CommandArgument='<%# Eval("s_id") %>' Text="删除" HeaderStyle-Width="15%"></asp:LinkButton>
                    </ItemTemplate>
          --%>      
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
<%--
        <table style="width: 90%; padding-top: 5px; text-align:center">
                        <tr>
                   <td colspan="2" style="width: 100px">
                      <asp:BoundField DataField="k_number" HeaderText="员工号" SortExpression="k_number" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="k_name" HeaderText="姓名" SortExpression="k_name" ItemStyle-Width="5%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>                
                </td>
                <td   >

    <tr>
                <td>计划：
                </td>

            </tr>
            <tr>
                <td>完成情况：
                </td>
                <td>
                    <asp:TextBox ID="wancheng" runat="server" TextMode="MultiLine" onkeyup="checklength2(this) "></asp:TextBox>
                </td>
            </tr>


            <tr>
                <td colspan="6">
                    <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" OnClientClick=" return checkdata() " Width="109px" />
                </td>
            </tr>               
                 
                </td>
                 <td>
       
         <asp:BoundField DataField="k_number" HeaderText="员工号" SortExpression="k_number" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="k_name" HeaderText="姓名" SortExpression="k_name" ItemStyle-Width="5%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>        
                                
                </td>
                <td>
                    <asp:TextBox ID="TextBox16" runat="server" Text="无"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="Btnshengqin" runat="server" Text="申请"  Width="100px" />
                </td>
            </tr>
           

           <tr>
                <td>计划：
                </td>

            </tr>
            <tr>
                <td>完成情况：
                </td>
                <td>
                    <asp:TextBox ID="wancheng" runat="server" TextMode="MultiLine" onkeyup="checklength2(this) "></asp:TextBox>
                </td>
            </tr>


            <tr>
                <td colspan="6">
                    <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" OnClientClick=" return checkdata() " Width="109px" />
                </td>
            </tr>
        </table>
                <br />
        <br />
        <table>
            <tr>
                <td>姓名：<asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>工号：<asp:TextBox ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>级别：<asp:TextBox ID="TextBox3" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>部门：<asp:TextBox ID="TextBox4" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>上级：<asp:TextBox ID="TextBox5" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td>入职：<asp:TextBox ID="TextBox6" runat="server" ReadOnly="true"></asp:TextBox>
                </td>

            </tr>
        </table>--%>

     <%-- <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="k_id"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
            CellPadding="4" ForeColor="Black" AllowSorting="true" GridLines="Horizontal"
            Width="100%" HorizontalAlign="Justify" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvShow_PageIndexChanging"
            OnRowDataBound="gvShow_RowDataBound" OnRowCommand="gvShow_RowCommand" OnSorting="gvShow_Sorting">

            <Columns>


              <asp:BoundField DataField="k_number" HeaderText="员工号" SortExpression="k_number" HeaderStyle-Width="5%"  ItemStyle-HorizontalAlign="Center"><ItemStyle Width="5%" /></asp:BoundField>
                    <asp:BoundField DataField="k_name" HeaderText="姓名" SortExpression="k_name" ItemStyle-Width="5%"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ><ItemStyle Width="5%" /></asp:BoundField>
                <asp:BoundField DataField="k_time" HeaderText="日期" SortExpression="k_time" ItemStyle-Width="10%" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="z_jihua" HeaderText="计划" SortExpression="z_jihua" ItemStyle-Width="25%" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="25%" />
                </asp:BoundField>

                <asp:BoundField DataField="k_wancheng" HeaderText="完成情况" SortExpression="k_wancheng" ItemStyle-Width="20%" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="20%" />
                </asp:BoundField>

                <asp:BoundField DataField="k_pingyu" HeaderText="评语" SortExpression="k_pingyu" ItemStyle-Width="15%"
                    HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="k_defen" HeaderText="得分" SortExpression="k_defen" ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="5%" />
                </asp:BoundField>
                <asp:BoundField DataField="k_statue" HeaderText="状态" SortExpression="k_statue" ItemStyle-Width="5%" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="5%" />
                </asp:BoundField>

                <asp:BoundField DataField="k_id" HeaderText="k_id" InsertVisible="False" ReadOnly="True" SortExpression="k_id" Visible="false" />
                <asp:TemplateField HeaderText="详细操作" HeaderStyle-Width="5%">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("k_id") %>'
                            CommandName="Edit" Text="编辑" HeaderStyle-Width="5%"></asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            CommandArgument='<%# Eval("k_id") %>' Text="删除" HeaderStyle-Width="5%"></asp:LinkButton>
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
   --%>

    </div>
</asp:Content>



