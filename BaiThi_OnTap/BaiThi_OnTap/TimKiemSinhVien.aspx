<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TimKiemSinhVien.aspx.cs" Inherits="BaiThi_OnTap.TimKiemSinhVien" %>

<asp:Content ID="ctheader" runat="server" ContentPlaceHolderID="CTHeader"></asp:Content>
<asp:Content ID="ctContent" runat="server" ContentPlaceHolderID="CTContent">
     <style>
        *{
            margin: 0 auto;
            padding: 0;
            box-sizing: border-box;
        }
        .container{
           max-width: 1200px;
        }
        .container-content{
            margin-top: 20px;
        }
        .container-content-title{
            padding: 10px 0 10px 0;
            text-align: center;
            font-size: 30px;
            border: 1px solid #808080;
        }
        .content-left{
            float: left;
            font-size: 18px;
            width: 400px;
            text-align: center;
            border-right: 1px solid #808080;
            border-left: 1px solid #808080;
            height: 450px;
            padding-top: 20px;
        }
        .content-right{
            float: right;
            font-size: 18px;
            width: 800px;
            text-align: center;
            border-right: 1px solid #808080;
            height: 450px;
            padding-top: 20px;
        }
        .clear-float{
            clear: both;
        }
        .content-bottom{
            border: 1px solid #808080;
            text-align: center;
            font-size: 25px;
            padding: 10px 0 10px 0;
        }
        .link{
            font-size: 20px;
          
        }
        .title-right{
            font-size: 25px;
            font-weight: bold;
        }
        .td{
            font-size: 20px;
        }
        .btn{
            margin-top: 20px;
            font-size: 18px;
        }
        input[type="text"i]{
            padding: 3px 5px 3px 5px;
        }
        .groupBtn{
            font-size: 18px;
            padding: 3px 5px 3px 5px;
        }
    </style>
                    <div class="title-right">
                        <asp:Label ID="lblTitleRight" runat="server" Text="Tìm kiếm Sinh Viên"></asp:Label>
                    </div>
                    <div class="table">
                        <table>
                            <tr>
                                <td><asp:Label ID="lblMasinhvien" CssClass="td" runat="server" Text="Mã sinh viên:"></asp:Label></td>
                                <td> <asp:TextBox ID="txtMaSV" runat="server"></asp:TextBox> </td>
                            </tr>
                           <tr>
                                <td><asp:Label ID="lblTensinhvien" CssClass="td" runat="server" Text="Tên sinh viên:"></asp:Label></td>
                                <td> <asp:TextBox ID="txtTenSV" runat="server"></asp:TextBox> </td>
                            </tr>
                        </table>
                    </div>
                    <div class="Erorr">
                        <asp:Label ID="lblErorr" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="gridview">
                            <asp:GridView ID="grvDSSV" runat="server" Width="600px"  AutoGenerateColumns="False"  OnPageIndexChanging="grvDSSV_PageIndexChanging" CellPadding="4"  ForeColor="#333333" PageSize="3"  BackColor="White" AllowPaging="True" OnSelectedIndexChanged="grvDSSV_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="MaSV" HeaderText="Mã môn học" ReadOnly="True" />
                            <asp:BoundField DataField="TenSV" HeaderText="Tên môn học" />
                            <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
                        </Columns>
                 <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#0066CC" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    </div>
                    <div class="btn">
                        <asp:Button ID="btnTimTheoMa" CssClass="groupBtn" runat="server" Text="Tìm theo mã" OnClick="btnTimTheoMa_Click" />
                        <asp:Button ID="btnTimTheoTen" CssClass="groupBtn"  runat="server" Text="Tìm theo Tên" OnClick="btnTimTheoTen_Click" />
                      
                    </div>

</asp:Content>