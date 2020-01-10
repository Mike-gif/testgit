<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="ZhouJH.aspx.cs" Inherits="user_ZhouJH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" runat="Server">

    <style type="text/css">
        .auto-style1 {
            Height: 25px;
            width: 100%;
        }

        .td-style1 {
            font-size: 16px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="position">
    <div style="padding-left: 10px; padding-top: 15px">
        当前位置：个人信息管理&nbsp;&gt;&gt;&nbsp;周工作总结与计划
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="mainContent">
    <div style="margin-left: 10px; text-align: center">
        <table>
            <tr>
                <td>汇报时间
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="startdate" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Style="font-size: 13px">打开日历</asp:LinkButton>
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="按日期查询周报" Width="115px" OnClick="Button3_Click" />

                </td>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="按日期修改周报" Width="115px" OnClick="Button4_Click" />
                </td>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="添加周报" />
                </td>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="清空表单" OnClick="Button6_Click" />
                </td>
                <td>
                    <asp:TextBox ID="z_ID" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                </td>
                <td style="text-align: center; padding-left: 160px" colspan="2">
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
        </table>
        <table style="width: 100%;" class="td-style1">
            <tr>
                <td colspan="8">
                    <h3>周工作总结与计划</h3>
                </td>

            </tr>
            <tr>
                <td>汇报人
                </td>
                <td>
                    <asp:TextBox ID="name" runat="server" class="auto-style1" ReadOnly="true"></asp:TextBox>
                </td>
                <td>部门
                </td>
                <td>
                    <asp:TextBox ID="bumen" runat="server" class="auto-style1"></asp:TextBox>
                </td>
                <td>职务
                </td>
                <td>
                    <asp:TextBox ID="zhiwu" runat="server" class="auto-style1"></asp:TextBox>
                </td>
                <td>汇报时间
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="time1" runat="server" ReadOnly="true"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton2" runat="server" Style="font-size: 12px" OnClick="LinkButton2_Click">打开日历</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td rowspan="6">时间
                </td>
                <td rowspan="6">
                    <asp:TextBox ID="strtime" runat="server" class="auto-style1"></asp:TextBox>
                </td>
                <td rowspan="6">主要工作
                </td>
                <td>
                    <asp:TextBox ID="strword1" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strword2" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strword3" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strword4" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strword5" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strword6" runat="server" class="auto-style1"></asp:TextBox>
                </td>
                <td rowspan="6">完成情况
                </td>
                <td>
                    <asp:TextBox ID="strwan1" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strwan2" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strwan3" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strwan4" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strwan5" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strwan6" runat="server" class="auto-style1"></asp:TextBox>


                </td>
                <td rowspan="6">备注
                </td>
                <td>
                    <asp:TextBox ID="strbeizhu1" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strbeizhu2" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strbeizhu3" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strbeizhu4" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strbeizhu5" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="strbeizhu6" runat="server" class="auto-style1"></asp:TextBox>

                </td>
            </tr>
        </table>
        <table style="width: 100%;" class="td-style1">
            <tr>
                <td style="width: 100px; height: 50px">不足之处及
                <br />
                    问题所在
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="strbuzu" runat="server" Height="90px" TextMode="MultiLine" Width="600px" Style="margin-left: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 50px">解决办法/
                <br />
                    希望得到的
                <br />
                    工作支持或帮助
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="strbanfa" runat="server" Height="90px" TextMode="MultiLine" Width="600px" Style="margin-left: 0px"></asp:TextBox>
                </td>
            </tr>
        </table>


        <table style="width: 100%;" class="td-style1">
            <tr>
                <td colspan="8">
                    <h3>下周主要工作计划</h3>
                </td>

            </tr>
            <tr>
                <td>时间/事件
                </td>
                <td>
                    <asp:TextBox ID="shijian1" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="shijian2" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="shijian3" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="shijian4" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="shijian5" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="shijian6" runat="server" class="auto-style1"></asp:TextBox>
                </td>
                <td>预计计划
                </td>
                <td>
                    <asp:TextBox ID="jihua1" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="jihua2" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="jihua3" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="jihua4" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="jihua5" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="jihua6" runat="server" class="auto-style1"></asp:TextBox>
                </td>
                <td>实现目标
                </td>
                <td>
                    <asp:TextBox ID="mubiao1" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="mubiao2" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="mubiao3" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="mubiao4" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="mubiao5" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="mubiao6" runat="server" class="auto-style1"></asp:TextBox>
                </td>
                <td>预计耗时
                </td>
                <td>
                    <asp:TextBox ID="usetime1" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="usetime2" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="usetime3" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="usetime4" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="usetime5" runat="server" class="auto-style1"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="usetime6" runat="server" class="auto-style1"></asp:TextBox>
                </td>
            </tr>

        </table>
        <table style="width: 100%;" class="td-style1">
            <tr>
                <td style="width: 100px; height: 50px" class="td-style1">部门建议/
                <br />
                    个人建议
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="jianyi" runat="server" Height="90px" TextMode="MultiLine" Width="600px" Style="margin-left: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;"></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="添加" Width="110px" OnClick="Button1_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="取消" Width="110px" OnClick="Button2_Click" />

                </td>
            </tr>
        </table>
    </div>


</asp:Content>


