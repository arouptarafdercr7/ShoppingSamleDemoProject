<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintOrder.aspx.cs" Inherits="Lesson_10_DataTable_Edit_DeleteData_.PrintOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--Install bootstrap--%>
    <%-- When use bootstrap need this link--%>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.7.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>

    <%-- 1st Content/bootstrap.css, Then Scripts/jquery-3.7.1.js, Then Scripts/bootstrap.js --%>
    <%-- Bootstrap use korar jonno jquery lage.tai jquery bootstrap er age hobe --%>


    <%--jQuery Command--%>
    <%--This code for print--%>

    <%-- print some area function.
        printDiv=ekhane jekono name deya jabe And divName=ekhane jekono name deya jabe.
        button er moddhe   onclick="printDiv('printreport')"      ekhane printreport hocche id. --%>

    <script>
        function printDiv(divName) {
            var pC = document.getElementById(divName).innerHTML;
            var oC = document.body.innerHTML;

            document.body.innerHTML = pC;
            window.print();
            document.body.innerHTML = oC;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        Enter Invoice No :
        <asp:TextBox ID="txtInvoiceNo" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show Order" />
        <br />
        <br />
        <div id="printreport">
            <%--HTML Print Report button er moddhe onclick="printDiv('printreport')"   printreport ei id jototuku ongso declare korbe tototukui print korbe--%>

            <table class="auto-style1">
                <tr>
                    <td>Invoice No: </td>
                    <td>
                        <asp:Label ID="lblInvoice" runat="server"></asp:Label>
                    </td>
                    <td>Order Date : </td>
                    <td>
                        <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Customer Name : </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblCustomer" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2">Shipping Address : </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Total Amount : </td>
                    <td>
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <%--Database table er under jei name thakbe nicher DataField er value must be same hote hobe--%>

            <asp:GridView ID="GridView1" runat="server" CssClass="table table-stripped" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="SalesPrice" HeaderText="Product Price" />
                    <asp:BoundField DataField="SalesQTY" HeaderText="Sales Quantity" />
                    <asp:BoundField DataField="SaleTotal" HeaderText="Sale Total" />
                </Columns>
            </asp:GridView>

            <div class="d-flex flex-row-reverse bg-dark text-white p-4">
                <div class="py-3 px-5 text-center">
                    <footer>Thanks For Purchases</footer>
                </div>
            </div>

        </div>

    </form>
    <p>
        <input id="Button1" type="button" value="Print Report" onclick="printDiv('printreport')" />
    </p>
</body>
</html>

