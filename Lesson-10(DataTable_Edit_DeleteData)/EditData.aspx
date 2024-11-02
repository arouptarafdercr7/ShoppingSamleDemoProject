<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditData.aspx.cs" Inherits="Lesson_10_DataTable_Edit_DeleteData_.EditData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--Install-Package jQuery.DataTables.Net--%>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/css/jquery.dataTables.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.7.1.js"></script>
    <script src="Scripts/jquery.dataTables.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <table id="table_dynamic" width="50%" align="center" border="1px">
                <thead>
                    <tr>
                        <td>Sn</td>
                        <th>Product Name</th>
                        <th>Quantity</th>
                        <th>Price</th>
                        <th>Photo</th>
                        <th>Action</th>
                    </tr>
                </thead>
            </table>

            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <div>

                <table class="w-100">
                    <tr>
                        <td>Product Name</td>
                        <td>
                            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Quantity</td>
                        <td>
                            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Price</td>
                        <td>
                            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Photo</td>
                        <td>
                            <asp:Image ID="Image1" runat="server" Width="150px" />
                            <br />
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </div>
            <p>
                <br />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                &nbsp;<br />
            </p>
        </div>
    </form>
</body>
</html>
