<%@ Page Title="Sản phẩm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="SaleManagement.Controls.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12 title-control-page">
            <h1 class="page-header">Sản phẩm</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <!-- /.panel-heading -->
            <div>
                <div class="col-lg-4">Tên sản phẩm</div>
                <div class="col-lg-8">
                    <input id="txtProductName" />
                </div>
            </div>
            <div>
                <div class="col-lg-4">Loại</div>
                <div class="col-lg-8">
                    <select id="cboCatId">
                        <option value="0">Tất cả</option>
                        <option value="1">Bánh mỳ</option>
                        <option value="2">Nước ngọt</option>
                    </select>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <!-- /.panel-heading -->
            <div class="panel panel-default">
                <div class="panel-body" id="table-content">
                </div>
            </div>
        </div>
    </div>
    <%--Xóa--%>
    <div class="modal fade" id="Delete" tabindex="-1" role="dialog" aria-labelledby="lable-Delete" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="lable-Delete">Xóa thông tin sản phẩm</h4>
                </div>
                <input type="hidden" id="hdProductCode" />
                <div class="modal-body-delete">
                    Bạn muốn xóa?
                </div>
                <div class="modal-footer">
                    <button type="button" onclick="ConfirmDelete()" class="btn btn-primary">Xác nhận</button>
                    <button type="button" class="btn btn-primary" id="btnClose" data-dismiss="modal">Đóng</button>
                </div>
            </div>
        </div>
    </div>
    <%--Kết thúc Xóa--%>



    <script type="text/javascript">
        $(document).ready(function () {
            LoadTable();
            $('#txtProductName').change(function () {
                LoadTable();
            });
            $('#cboCatId').change(function () {
                LoadTable();
            });
        });
        function Delete(pCode, pName) {
            alert("Xóa" + pName);
        }
        //Load danh sách dữ liệu cho bảng
        function LoadTable() {
            var pc = {
                ProductName: $('#txtProductName').val(),
                CategoryId: parseInt($('#cboCatId').val())
            };
            $.ajax({
                type: "POST",
                url: "../Services/ProductServices.asmx/GetAllProduct",
                data: JSON.stringify({ pc: pc }),
                dataType: "json",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    var result = $.parseJSON(response.d);
                    if (result.Status)
                        $('#table-content').html(result.Message);
                    else
                        ShowMessage(result.Message);
                },
                error: function (xhr, status, error) {
                    ShowMessage("LoadTable lỗi");
                }
            });
        }
        //Xóa dữ liệu bảng
        function Delete(productCode, productName) {
            $('#hdProductCode').val(productCode);
            $('.modal-body-delete').html("Bạn chắc chắn muốn xóa <b>" + productName + "</b>");
        }
        function ConfirmDelete() {
            var pc = {
                ProductCode: $('#hdProductCode').val()
            };
            $.ajax({
                type: "POST",
                url: "../Services/ProductServices.asmx/Delete",
                data: JSON.stringify({ pc: pc }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (responseData) {
                    var result = $.parseJSON(responseData.d);
                    if (result.Status) {//Không có lỗi
                        if (result.Message == "Ok") {//Xóa thành công
                            $('#btnClose').click();
                            LoadTable();
                        }
                        else //Xóa thất bại
                            ShowMessage(result.Message);
                    }
                    else
                        ShowMessage(result.Message);
                },
                error: function (xhr, status, error) {
                    ShowMessage("ConfirmDelete lỗi");
                }
            });
        }
    </script>
</asp:Content>
