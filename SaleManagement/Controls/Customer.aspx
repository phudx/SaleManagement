<%@ Page Title="Khách hàng" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="SaleManagement.Controls.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../vendor/datatables-plugins/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="../vendor/datatables-responsive/dataTables.responsive.css" rel="stylesheet" />
    <script src="../vendor/datatables/js/jquery.dataTables.js"></script>
    <script src="../vendor/datatables-plugins/dataTables.bootstrap.min.js"></script>
    <script src="../vendor/datatables-responsive/dataTables.responsive.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12 title-control-page">
            <h1 class="page-header">Khách hàng</h1>
            <button type="button" id="AddNew" data-toggle="modal" data-target="#InsertOrUpdate" class="btn btn-primary btnFunction" onclick="InsertOrUpdate(0,'','','','','')">Thêm mới</button>
            <button type="button" id="ExportExcel" class="btn btn-primary btnFunction">Xuất Excel</button>
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
    <%--Cập nhật--%>
    <div class="modal fade" id="InsertOrUpdate" tabindex="-1" role="dialog" aria-labelledby="lable-InsertOrUpdate" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="lable-InsertOrUpdate">Cập nhật khách hàng</h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div id="validate-form" class="validate-form"></div>
                        <div class="form-group">
                            <label class="control-label col-sm-3" for="CustomerCode">Mã khách hàng:</label>
                            <div class="col-sm-9">
                                <input type="text" class="form-control" id="CustomerCode" disabled="disabled" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-3" for="CustomerName">Tên khách hàng<b style="color: #ff0000;">*</b>:</label>
                            <div class="col-sm-9">
                                <input type="text" class="form-control" id="CustomerName" placeholder="Mời nhập thông tin" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-3" for="Phone">Số điện thoại <b style="color: #ff0000;">*</b>:</label>
                            <div class="col-sm-9">
                                <input type="text" class="form-control" id="Phone" placeholder="Mời nhập thông tin" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-3" for="Address">Địa chỉ <b style="color: #ff0000;">*</b>:</label>
                            <div class="col-sm-9">
                                <input type="text" class="form-control" id="Address" placeholder="Mời nhập thông tin" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-3" for="GroupId">Nhóm địa chỉ <b style="color: #ff0000;">*</b>:</label>
                            <div class="col-sm-9">
                                <input type="hidden" id="hdGroupId" />
                                <input type="text" class="form-control" id="GroupName" placeholder="Mời nhập thông tin" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-3" for="Note">Ghi chú:</label>
                            <div class="col-sm-9">
                                <textarea class="form-control" rows="5" id="Note"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" onclick="ConfirmInsertOrUpdate()" class="btn btn-primary">Lưu lại</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Đóng</button>
                </div>
            </div>
        </div>
    </div>
    <%--Kết thúc cập nhật--%>
    <%--Xóa--%>
    <div class="modal fade" id="Delete" tabindex="-1" role="dialog" aria-labelledby="lable-Delete" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="lable-Delete">Xóa thông tin khách hàng</h4>
                </div>
                <input type="hidden" id="hdCustomerCode" />
                <div class="modal-body-delete">
                    Bạn muốn xóa?
                </div>
                <div class="modal-footer">
                    <button type="button" onclick="ConfirmDelete()" class="btn btn-primary">Xác nhận</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Đóng</button>
                </div>
            </div>
        </div>
    </div>
    <%--Kết thúc Xóa--%>

    <script type="text/javascript">
        $(document).ready(function () {
            LoadTable();
            $('#dataTables-example').DataTable({
                responsive: true
            });
        });
        //Lấy mã khách hàng cho insert
        function GetCustomerCodeInsert() {
            $.ajax({
                type: "POST",
                url: "../Services/CustomerServices.asmx/GetCustomerCodeInsert",
                data: '',
                dataType: "json",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    var result = $.parseJSON(response.d);
                    if (result.Status)
                        $('#CustomerCode').val(result.Message);
                    else
                        ShowMessage(result.Message);
                },
                error: function (xhr, status, error) {
                    ShowMessage("GetCustomerCodeInsert lỗi");
                    console.log("GetCustomerCodeInsert lỗi: " + xhr.responseText);
                }
            });
        }
        //Load danh sách dữ liệu cho bảng
        function LoadTable() {
            $.ajax({
                type: "POST",
                url: "../Services/CustomerServices.asmx/GetAllCustomer",
                data: '',
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
                    console.log("LoadTable lỗi: " + xhr.responseText);
                }
            });
        }
        //Xóa dữ liệu bảng
        function Delete(customerCode, customerName) {
            $('#hdCustomerCode').val(customerCode);
            $('.modal-body-delete').html("Bạn chắc chắn muốn xóa <b>" + customerName + "</b>");
        }
        function ConfirmDelete() {
            var cc = {
                CustomerCode: $('#hdCustomerCode').val()
            };
            $.ajax({
                type: "POST",
                url: "../Services/CustomerServices.asmx/DeleteCustomer",
                data: JSON.stringify({ cc: cc }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (responseData) {
                    var result = $.parseJSON(response.d);
                    if (result.Status) {
                        if (result.Message == "Ok")
                            LoadTable();
                        else
                            ShowMessage(result.Message);
                    }
                    else
                        ShowMessage(result.Message);
                },
                error: function (xhr, status, error) {
                    ShowMessage("ConfirmDelete lỗi");
                    console.log("ConfirmDelete lỗi: " + xhr.responseText);
                }
            });
        }
        //Cập nhật thông tin khách hàng
        function InsertOrUpdate(pCustomerCode, pCustomerName, pPhone, pAddress, pGroupName, pNote) {
            SuggestionGroup();//Gợi ý thông tin của nhóm địa chỉ
            $('#lable-InsertOrUpdate').val('Sửa thông tin khách hàng');
            $('#CustomerCode').val(pCustomerCode);
            $('#CustomerName').val(pCustomerName);
            $('#Phone').val(pPhone);
            $('#Address').val(pAddress);
            $('#GroupName').val(pGroupName);
            $('#Note').val(pNote);
            if (pCustomerCode == 0) {
                $('#lable-InsertOrUpdate').val('Thêm mới khách hàng');
                GetCustomerCodeInsert();
            }
        }
        function ConfirmInsertOrUpdate() {
            if (Validate()) {
                var cc = {
                    CustomerCode: $('#CustomerCode').val(),
                    CustomerName: $('#CustomerName').val(),
                    Address: $('#Address').val(),
                    Phone: $('#Phone').val(),
                    GroupId: $('#hdGroupId').val(),
                    Note: $('#Note').val(),
                }
                $.ajax({
                    type: "POST",
                    url: "../Services/CustomerServices.asmx/InsertOrUpdateCustomer",
                    data: JSON.stringify({ cc: cc }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (responseData) {
                        var result = $.parseJSON(response.d);
                        if (result.Status) {
                            if (result.Message == "Ok")
                                LoadTable();
                            else
                                ShowMessage(result.Message);
                        }
                        else
                            ShowMessage(result.Message);
                    },
                    error: function (xhr, status, error) {
                        ShowMessage("ConfirmInsertOrUpdate lỗi");
                        console.log("ConfirmInsertOrUpdate lỗi: " + xhr.responseText);
                    }
                });
            }
        }
        //Validate dữ liệu form thêm mới, chỉnh sửa
        function Validate() {
            if ($('#CustomerName').val() == '' || $('#CustomerName').val() == null) {
                ShowMessage("Bạn chưa nhập <b>Tên khách hàng</b>");
                CustomerName.focus();
                return false;
            }
            if ($('#Phone').val() == '' || $('#Phone').val() == null) {
                ShowMessage("Bạn chưa nhập <b>Số điện thoại</b>");
                Phone.focus();
                return false;
            }
            if ($('#Address').val() == '' || $('#Address').val() == null) {
                ShowMessage("Bạn chưa nhập <b>Địa chỉ</b>");
                Address.focus();
                return false;
            }
            if ($('#GroupName').val() == '' || $('#GroupName').val() == null) {
                ShowMessage("Bạn chưa nhập <b>Nhóm địa chỉ</b>");
                GroupName.focus();
                return false;
            }
            return true
        }
        //Load danh sách gợi ý cho trường nhóm địa chỉ
        function SuggestionGroup() {
            var groupSelected;
            $("#GroupName").autocomplete({
                source: function () {
                    $.ajax({
                        url: "../Services/CustomerServices.asmx/SuggestionGroup",
                        data: '',
                        dataType: "json",
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            $.map(data.d, function (item) {
                                return {
                                    val: parseInt(item.split(',')[0]),
                                    label: item.split(',')[1]
                                }
                            });
                        },
                        error: function (response) {
                            ShowMessage(response.responseText);
                        },
                        failure: function (response) {
                            ShowMessage(response.responseText);
                        }
                    });
                },
                minLength: 1,
                close: function (event, ui) {
                    if (groupSelected != "")
                        $(this).val(groupSelected);
                    LoadTable();
                },
                focus: function (event, ui) {
                    return false;
                },
                open: function (event, ui) {
                    groupSelected = "";
                },
                autoFocus: true,
                select: function (event, ui) {
                    groupSelected = ui.item.label;
                    $('#hdGroupId').val(ui.item.val);
                }
            });
        }
    </script>
</asp:Content>
