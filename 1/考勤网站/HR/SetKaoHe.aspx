<%@ Page Title="" Language="C#" MasterPageFile="~/HR/HRadmin.master" AutoEventWireup="true" CodeFile="SetKaoHe.aspx.cs" Inherits="HR_SetKaoHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="_head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="position">
    <div style="padding-left: 10px; padding-top: 15px">
        当前位置：考勤信息管理&nbsp;&gt;&gt;&nbsp;岗位职责考核标准配置

    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="mainContent">
     <div style="margin-left: 40px; text-align: center">
    <table>
        <tr>
            <td>考核项目
            </td>
            <td>绩效分
            </td>
            <td>奖罚款
            </td>
        </tr>
         <tr>
            <td>
               失误
            </td>
            <td>
                <asp:TextBox ID="TextBox65" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox66" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                一般过错
            </td>
            <td>
                <asp:TextBox ID="TextBox67" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox68" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                重大过错
            </td>
            <td>
                <asp:TextBox ID="TextBox69" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox70" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                当天在岗()
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                在岗并完成当天目标任务
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                按时完成超额临时任务(计划外任务)
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                周目标任务，部分完成按权重比例得分<br />
                平均得分不得高于部门或项目组综合考评分
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                因工作延期而造成项目终止
            </td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            </td>
        </tr>
       <tr>
            <td>
                已签合同项目其他因素造成项目终止
            </td>
            <td>
                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
                意向性项目预研项目（未签合同）终止
            </td>
            <td>
                <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
               延期完成周工作任务
            </td>
            <td>
                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
                外部原因造成未完成当日计划
            </td>
            <td>
                <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
              其他原因造成未完成当日计划
            </td>
            <td>
                <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
               收发邮件、财物失误
            </td>
            <td>
                <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
               文档文件内容错误
            </td>
            <td>
                <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
               软件版本错误
            </td>
            <td>
                <asp:TextBox ID="TextBox25" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
                采购及收发错误
            </td>
            <td>
                <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox28" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
               产品检验错误
            </td>
            <td>
                <asp:TextBox ID="TextBox29" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox30" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
               产品质量问题退货
            </td>
            <td>
                <asp:TextBox ID="TextBox31" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox32" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
              其他非主观工作失误
            </td>
            <td>
                <asp:TextBox ID="TextBox33" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox34" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
               设计不合理，功能不明确、不完善、<br />
                缺陷、有隐患、兼容性问题
            </td>
            <td>
                <asp:TextBox ID="TextBox35" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox36" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
              其他可正常使用但易出现问题的缺陷
            </td>
            <td>
                <asp:TextBox ID="TextBox37" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox38" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
              电路设计错误、电路加工错误
            </td>
            <td>
                <asp:TextBox ID="TextBox39" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox40" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
              代码错误
            </td>
            <td>
                <asp:TextBox ID="TextBox41" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox42" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
               票据错误
            </td>
            <td>
                <asp:TextBox ID="TextBox43" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox44" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
               违反规定和流程造成的失误
            </td>
            <td>
                <asp:TextBox ID="TextBox45" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox46" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
               其他主观性错误
            </td>
            <td>
                <asp:TextBox ID="TextBox47" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox48" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
             建议被采纳、设计改进、设计创新
            </td>
            <td>
                <asp:TextBox ID="TextBox49" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox50" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
               月度、季度、年度之星
            </td>
            <td>
                <asp:TextBox ID="TextBox51" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox52" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
             第一人称省部级奖项
            </td>
            <td>
                <asp:TextBox ID="TextBox53" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox54" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
             参与者省部级奖项（不超过2人）
            </td>
            <td>
                <asp:TextBox ID="TextBox55" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox56" runat="server"></asp:TextBox>
            </td>
        </tr>
             <tr>
            <td>
             以第一人称被授予实用新型专利
            </td>
            <td>
                <asp:TextBox ID="TextBox57" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox58" runat="server"></asp:TextBox>
            </td>
        </tr>
             <tr>
            <td>
             第一人称其他奖项
            </td>
            <td>
                <asp:TextBox ID="TextBox59" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox60" runat="server"></asp:TextBox>
            </td>
        </tr>
             <tr>
            <td>
            以第一人称在学术杂志发表论文
            </td>
            <td>
                <asp:TextBox ID="TextBox61" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox62" runat="server"></asp:TextBox>
            </td>
        </tr>
             <tr>
            <td>
            以第一人称发表著作权
            </td>
            <td>
                <asp:TextBox ID="TextBox63" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TextBox64" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>

            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="确定" Width="70px" />

            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="取消" Width="70px" />
            </td>
        </tr>

    </table>
         </div>
</asp:Content>


