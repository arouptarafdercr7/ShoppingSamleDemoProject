<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataTableExample.aspx.cs" Inherits="Lesson_10_DataTable_Edit_DeleteData_.DataTableExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--Install-Package jQuery.DataTables.Net--%>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/css/jquery.dataTables.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.7.1.js"></script>
    <script src="Scripts/jquery.dataTables.js"></script>

    <%-- jQuery Command--%>
    <%--This code for Searching,Edit,Delete.but if i want to Edit,Delete,I need Edit,Delete Web Form.jodi kono product order kora hoye jai.tahole sei product r delete hobe.cause of Foreign Key.if you want to delete.at first cancel order or delete Parent table--%>
    <script>
        $(function () {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "ProductService.asmx/GetProducts",
                success: function (data) {
                    var datatableVariable = $('#productTable').DataTable({      //productTable body er vitorer table er id
                        data: data,
                        columns: [
                            { 'data': 'Id' },            //jodi Id,ProductName,Quantity edit/modify/kicu add korte chai tahole render use korte hobe 
                            { 'data': 'ProductName' },
                            { 'data': 'Quantity' },
                            {
                                'data': 'Price', 'render': function (feesPaid) { return '$ ' + feesPaid; }
                                //render use kora hoi jate aro kicu add korte pari.feesPaid is a variable.return '$' means jei price dekhabe tar age $ sign  bosbe

                            },
                            {
                                'data': 'ProductImage', 'render': function (pimage) { return "<img src='./Pic/" + pimage + "' alt= '" + "no' width=200px />" }
                                //render use kora hoi jate aro kicu add korte pari.pimage is a variable.return "<img src='./image/" means image show korbe
                            },
                            {
                                'data': 'Id', 'render': function (idn) { return "<a href='EditData.aspx?Editid=" + idn + "' >Edit</a>" }
                                //href='default2.aspx?Editid   Question mark er pore jei variable thake take QueryString bole.ekhane Editid hocche QueryString
                            }
                            ,
                            {
                                'data': 'Id', 'render': function (idn) { return "<a href='DeleteData.aspx?Deleteid=" + idn + "' class='btn btn-warning'>Delete</a>" }
                            }
                        ]
                    });
                }
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="productTable" class="table table-responsive table-hover">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Product Name</th>
                        <th>Quantity</th>
                        <th>Price</th>
                        <th>Photo</th>
                        <th>Action</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tfoot>
                </tfoot>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

