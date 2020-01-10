<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ELECseekinf.aspx.cs" Inherits="admin_ELECseekinf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<%--<link type="text/css" rel="stylesheet" href="../css/style.css" />--%>
<script type="text/javascript" src="../js/jquery-1.8.3.min.js"></script>
<script type="text/javascript" src="../js/menu.js"></script>
       <style type="text/css"> 
         /*//setTimeout("location.href='ELECseekinf.aspx'",5000)*/
         #gvShow
         {
             font-family:Microsoft YaHei,Verdana,Arial,SimSun;color:#666;font-size:14px;background:#f6f6f6; overflow:hidden;
           
         }

    </style>   
    <title></title>
</head>
<body  >
    <form id="form1" runat="server" style="text-align:center; height:90%;">
       <div style="width:70%;margin:0 auto ;overflow:hidden;height:95%;margin-top:10px;">
             <asp:ScriptManager ID="ScriptManager1" runat="server" />
             <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="4000" />
   <asp:UpdatePanel ID="StockPricePanel" runat="server" UpdateMode="Conditional">
       <Triggers>
           <asp:AsyncPostBackTrigger ControlID="Timer1" />
       </Triggers>
       <ContentTemplate>
           <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="id" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid"  BorderWidth="1px"  CellPadding="4" ForeColor="Black" AllowSorting="false"  PageSize="50"
      Width="100%" HorizontalAlign="Justify" AllowPaging="True"  OnPageIndexChanging="gvShow_PageIndexChanging" Font-Size="20px"  Height="450px">

            <Columns>
                <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                <asp:BoundField DataField="name" HeaderText="状态(早，晚)" SortExpression="name" />
                <asp:BoundField DataField="name" HeaderText="事由" SortExpression="name" />
                <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                <asp:BoundField DataField="name" HeaderText="状态(早，晚)" SortExpression="name" />
                <asp:BoundField DataField="name" HeaderText="事由" SortExpression="name" />
                 <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="false" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#C5E2F2" Height="30" Font-Bold="True" ForeColor="Black" BorderColor="#C5E2F2" />
      
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center"  />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <RowStyle Height="25px" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B"  BorderStyle="Solid"/>
            <SortedDescendingCellStyle BackColor="#E5E5E5" BorderStyle="Solid"   />
            <SortedDescendingHeaderStyle BackColor="#242121" BorderStyle="Solid" />
           

        </asp:GridView>
             </ContentTemplate>
   </asp:UpdatePanel>
      <asp:Timer ID="Timer2" OnTick="Timer2_Tick" runat="server" Interval="3000" />
   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
       <Triggers>
           <asp:AsyncPostBackTrigger ControlID="Timer2" />
       </Triggers>
       <ContentTemplate>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid"  BorderWidth="1px"  CellPadding="4" ForeColor="Black" AllowSorting="false"  PageSize="50"
      Width="100%" HorizontalAlign="Justify" AllowPaging="True"  OnPageIndexChanging="gvShow_PageIndexChanging" Font-Size="20px"  Height="100px">

            <Columns>
                <asp:BoundField DataField="c_name" HeaderText="刷卡状态" SortExpression="c_name" />
                <asp:BoundField DataField="c_name" HeaderText="姓名" SortExpression="c_name" />
                <asp:BoundField DataField="c_time" HeaderText="刷卡时间(出门)" SortExpression="c_time" />
                <asp:BoundField DataField="c_name" HeaderText="姓名" SortExpression="c_name" />
                <asp:BoundField DataField="c_time" HeaderText="刷卡时间(进门)" SortExpression="c_time" />
                 <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="false" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#C5E2F2" Height="10" Font-Bold="True" ForeColor="Black" BorderColor="#C5E2F2" />
      
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center"  />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <RowStyle Height="10px" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B"  BorderStyle="Solid"/>
            <SortedDescendingCellStyle BackColor="#E5E5E5" BorderStyle="Solid"   />
            <SortedDescendingHeaderStyle BackColor="#242121" BorderStyle="Solid" />
           

        </asp:GridView>
             </ContentTemplate>
   </asp:UpdatePanel>
    </div>
  
    </form>
</body>
</html>
