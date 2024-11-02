<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyProduct.aspx.cs" Inherits="Lesson_10_DataTable_Edit_DeleteData_.BuyProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" ShowHeaderWhenEmpty="True" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" />
                        <asp:BoundField DataField="Product Id" HeaderText="Product Id" />
                        <asp:BoundField DataField="Product Name" HeaderText="Product Name" />
                        <asp:BoundField DataField="Product Quantity" HeaderText="Product Quantity" />
                        <asp:BoundField DataField="Sales Price" HeaderText="Sales Price" />
                        <asp:BoundField DataField="Total Price" HeaderText="Total Price" />
                    </Columns>
                </asp:GridView>
            </p>
            <p>
                <asp:Button ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" Text="Check Out" />
            </p>
            <p>
                <asp:DataList ID="DataList1" runat="server" BorderColor="Black" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyField="Id" GridLines="Both" RepeatColumns="4" OnItemCommand="DataList1_ItemCommand">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ProductImage","./Pic/{0}") %>' Width="300px" />
                        <br />
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' Visible="False" />
                        <br />
                        ProductName:
                        <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                        <br />
                        <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' Visible="False" />
                        <br />
                        Price:
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                        <br />
                        <asp:Label ID="ProductImageLabel" runat="server" Text='<%# Eval("ProductImage") %>' Visible="False" />
                        <br />
                        <asp:Label ID="CategoryIdLabel" runat="server" Text='<%# Eval("CategoryId") %>' Visible="False" />
                        <br />
                        <asp:Button ID="btnBuy" runat="server" CommandName="B" Text="Buy" />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
            </p>
        </div>
    </form>
</body>
</html>
