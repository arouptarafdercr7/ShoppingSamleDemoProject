<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lesson_10_DataTable_Edit_DeleteData_.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--Install bootstrap and jQuery--%>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.7.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>

    <%-- Design er moddhe Modal dekhar jonno ei link gulo off rakhte hobe --%>
    <%-- 1st Content/bootstrap.css, Then Scripts/jquery-3.7.1.js, Then Scripts/bootstrap.js --%>
    <%-- Bootstrap use korar jonno jquery lage.tai jquery bootstrap er age hobe --%>


    <%--Insert,Update er somoy Image show korar jonno nicher code--%>
    <%--jQuery Command--%>

    <script>
        function readURL(input) {

            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.prev').attr('src', e.target.result);    //Image  CssClass="prev"
                }

                reader.readAsDataURL(input.files[0]);
            }
        }

        //$(".imgInp").change(function () {
        //    readURL(this);                         //FileUpload  onchange=" readURL(this);"
        //});
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--UpdatePanel nile ScriptManager nite hobe--%>
            <%--Button UpdatePanel er vitorei hobe--%>
            <%-- Literal message dekhte ContentTemplate and UpdatePanel er vitore nite hobe --%>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" DataKeyNames="Id" EmptyDataText="There are no data records to display" OnRowCommand="GridView1_RowCommand">
                        <Columns>
                            <asp:ButtonField CommandName="V" Text="View" />
                            <asp:ButtonField CommandName="U" Text="Update" />
                            <asp:ButtonField CommandName="D" Text="Delete" />
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                            <asp:TemplateField HeaderText="Photo" SortExpression="Photo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Photo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("Photo","./Pic/{0}") %>' Width="100px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

                    <%--Literal message dekhte ContentTemplate and UpdatePanel er vitore nite hobe--%>

                    <br />
                    <asp:Button ID="btnAddNew" runat="server" class="btn btn-primary"
                        Text="Add New" OnClick="btnAddNew_Click" />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />


            <!-- Modal -->
            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>


                        <%-- Modal er vitore Table show korar jonno UpdatePanel er vitore Database Table dite hobe
                             UpdatePanel nile must be ContentTemplate nite hobe--%>
                        <%-- GridView theke Modal er Button show korte holeo Button UpdatePanel er vitore Button nite hobe--%>

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>


                                <div class="modal-body">
                                    Customer Information

                                    <table class="auto-style1">
                                        <tr>
                                            <td>Customer Id</td>
                                            <td>
                                                <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Customer Name</td>
                                            <td>
                                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Customer Email:</td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Customer Address:</td>
                                            <td>
                                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Customer Phone:</td>
                                            <td>
                                                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Photo</td>
                                            <td>
                                                <asp:Image ID="Image1" runat="server" CssClass="prev" Width="100px" />
                                                <br />
                                                <asp:FileUpload ID="FileUpload1" runat="server" onchange=" readURL(this);" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <%-- Button er color change korar jonno class dite hobe.Example:class="btn btn-secondary" etc...--%>

                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                    <asp:Button ID="btnInsert" class="btn btn-primary" runat="server" OnClick="btnInsert_Click" Text="Insert" />
                                    <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                    <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                                </div>

                                <%-- Pic upload er jonno trigger er vitore nicher code.updatepanel click kore properties theke --%>
                                <%-- Image Insert,Update er jonno must be Triggers nite hobe--%>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                                <asp:PostBackTrigger ControlID="btnInsert" />
                                <asp:PostBackTrigger ControlID="btnUpdate" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>

            <%--End Modal--%>
        </div>

    </form>
</body>
</html>

