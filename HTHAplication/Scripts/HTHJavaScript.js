//Lấy danh sách kho theo hàng hóa
function GetKho(ma_hh) {
    var mess = "<option value='0'> Please wait...</option>";
    $("#kho_hang").html('');
    $("#kho_hang").append(mess);
    var url = "/XuatHang/GetKhoByHangId/";
    $.ajax({
        type: "POST",
        url: url,
        data: { mahh: ma_hh },
        dataType: 'Json',
        cache: false,
        success: function (data) {
            var markup = '';
            for (var x = 0; x < data.length; x++) {
                markup += '<option value=' + data[x].Value + '>' + data[x].Text + '</option>';
            }
            $("#kho_hang").html(markup);
            $('#kho_hang').selectpicker('refresh');
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
    var li = document.getElementById("ul_mh").getElementsByTagName("li")[ma_mh.selectedIndex];
    document.getElementById("ten_mh").value = li.getElementsByTagName("input")[0].value;
    document.getElementById("dvt").value = li.getElementsByTagName("input")[1].value;
    document.getElementById("dgNhap").value = li.getElementsByTagName("input")[2].value.replace(/\D/g, '')
                                   .replace(/\B(?=(\d{3})+(?!\d))/g, ',');;
    $('#slCon').val('');


}
//Ajax: Thay đổi số lượng hàng hóa khi thay đổi kho hàng
function changeKho(select_ma_kho) {
    var ma_hh = $('#ma_mh option:selected').val();
    var ma_kho = parseInt(select_ma_kho.value);
    var data = {
        makho: ma_kho,
        mahh: ma_hh
    };
    $.ajax({
        type: "Post",
        url: "/XuatHang/GetQuantityProduct",
        data: data,
        dataType: "Json",
        success: function (result) {
            var j_result = JSON.parse(JSON.stringify(result));
            $('#slCon').val(j_result.soluong);
        },
        error: function (result) {
            alert("Ajax: Error!");
        }
    });
    return false;
}
// Func: Thay đổi tên mặt hàng/nhà cung cấp/đơn vị tính/hạn sử dụng/diễn giải khi mua/tên kho ngầm định ứng với mã mặt hàng
function changeMMH(select_ma_mh) {
    var li = document.getElementById("ul_mh").getElementsByTagName("li")[select_ma_mh.selectedIndex];
    document.getElementById("ten_mh").value = li.getElementsByTagName("input")[0].value;
    document.getElementById("dvt").value = li.getElementsByTagName("input")[1].value;
}
// Func: Thêm một mặt hàng
function themMatHang(form) {
    var tag_tbody = document.getElementById("tb_mat_hang").getElementsByTagName("tbody")[0];
    var tag_tr_new = document.createElement("tr");
    for (var i = 1; i < tag_tbody.childElementCount; i++) {
        var tag_tr_old = tag_tbody.getElementsByTagName("tr")[i];
        if (tag_tr_old.getElementsByTagName("td")[0].innerText == form.ma_mh.value) {
            var so_luong = parseInt(form.sl.value) + parseInt(tag_tr_old.getElementsByTagName("td")[4].innerText);
            var thanh_tien = form.sl.value * form.dg.value + parseFloat(tag_tr_old.getElementsByTagName("td")[5].innerText);
            tag_tr_new.innerHTML = "<tr>" +
                                     "<td>" + form.ma_mh.value + "</td>" +
                                     "<td>" + form.ten_mh.value + "</td>" +
                                     "<td>" + form.kho_hang.value + "</td>" +
                                     "<td>" + so_luong + "</td>" +
                                     "<td>" + form.dg.value + "</td>" +
                                     "<td>" + thanh_tien + "</td>" +
                                     "<td><a rel='#' href='#' onclick='return deleteMatHang(this);'>Xóa</a></td>" +
                                     "</tr>";

            tag_tbody.replaceChild(tag_tr_new, tag_tr_old);

            return false;
        }
    }

    tag_tr_new.innerHTML = "<tr>" +
                                "<td>" + form.ma_mh.value + "</td>" +
                                "<td>" + form.ten_mh.value + "</td>" +
                                "<td>" + form.kho_hang.value + "</td>" +
                                "<td>" + form.sl.value + "</td>" +
                                "<td>" + form.dg.value + "</td>" +
                                "<td>" + (form.sl.value * form.dg.value) + "</td>" +
                                "<td align='center'><a rel='#' href='#' onclick='return deleteMatHang(this);'>Xóa</a></td>" +
                               "</tr>";

    $(tag_tr_new).insertAfter(tag_tbody.lastChild);
    return false;
}
// Func: Thêm mặt hàng để bán
function themMatHangBan(form) {
    var tag_tbody = document.getElementById("tb_mat_hang").getElementsByTagName("tbody")[0];
    var tag_tr_new = document.createElement("tr");
    for (var i = 1; i < tag_tbody.childElementCount; i++) {
        var tag_tr_old = tag_tbody.getElementsByTagName("tr")[i];
        if (tag_tr_old.getElementsByTagName("td")[0].innerText == form.ma_mh.value) {
            var so_luong = parseInt(form.sl.value) + parseInt(tag_tr_old.getElementsByTagName("td")[4].innerText);
            var thanh_tien = form.sl.value * form.dg.value + parseFloat(tag_tr_old.getElementsByTagName("td")[5].innerText);
            tag_tr_new.innerHTML = "<tr>" +
                                     "<td>" + form.ma_mh.value + "</td>" +
                                     "<td>" + form.ten_mh.value + "</td>" +
                                     "<td>" + form.kho_hang.value + "</td>" +
                                     "<td>" + so_luong + "</td>" +
                                     "<td>" + form.dg.value + "</td>" +
                                     "<td>" + thanh_tien + "</td>" +
                                     "<td><a rel='#' href='#' onclick='return deleteMatHang(this);'>Xóa</a></td>" +
                                     "</tr>";
            tag_tbody.replaceChild(tag_tr_new, tag_tr_old);
            return false;
        }
    }
    tag_tr_new.innerHTML = "<tr>" +
                                "<td>" + form.ma_mh.value + "</td>" +
                                "<td>" + form.ten_mh.value + "</td>" +
                                "<td>" + form.kho_hang.value + "</td>" +
                                "<td>" + form.sl.value + "</td>" +
                                "<td>" + form.dg.value + "</td>" +
                                "<td>" + (form.sl.value * form.dg.value) + "</td>" +
                                "<td align='center'><a rel='#' href='#' onclick='return deleteMatHang(this);'>Xóa</a></td>" +
                               "</tr>";
    $(tag_tr_new).insertAfter(tag_tbody.lastChild);
    return false;
}
// Func: Xóa một mặt hàng
function deleteMatHang(tag_a) {
    var tag_tr = tag_a.parentNode.parentNode;
    document.getElementById("tb_mat_hang").getElementsByTagName("tbody")[0].removeChild(tag_tr);
    alert("Kết quả: Xóa mặt hàng thành công.");
}

// Ajax: Thực hiện thao tác nhập kho
function executeNhapKho(form) {
    //Thêm phiếu nhập kho ->Thêm chi tiết phiếu nhập kho
    themPhieuNhapKho(form);
    return false;
}
// Ajax: Thêm phiếu nhập kho -> 
function themPhieuNhapKho(form) {
    debugger;
    var tong_tien = 0;
    var lst_tr_LH = document.getElementById("tb_mat_hang").getElementsByTagName("tr");

    for (var i = 1; i < lst_tr_LH.length; i++) {
        tong_tien += parseFloat(lst_tr_LH[i].getElementsByTagName("td")[5].innerText);
    }
    var data = {
        ma: form.txt_ctNumber.value,
        ngay_nhap: form.datepicker.value,
        ma_ncc: form.sl_staff.value,
        nguoi_lap_phieu: form.txt_nguoi_lap_phieu.value,
        nguoi_giao: form.txt_nguoi_giao.value,
        dien_giai: form.txt_des.value,
        tong_tien: tong_tien
    };

    $.ajax({
        type: "POST",
        url: "/NhapHang/CreatePNK",
        data: data,
        dataType: "Json",
        success: function (result) {
            var j_result = JSON.parse(JSON.stringify(result));
            //alert(j_result.message);            
            themCT_PhieuNhapKho(form);
        },
        error: function (result) {
            alert('Lỗi thêm phiếu nhập kho!');
        }

    });
    return false;
}

// Ajax: Thêm chi tiết phiếu nhập kho -> Kết thúc
function themCT_PhieuNhapKho(form) {    
    var lst_ma_hang = new Array();
    var lst_ma_kho = new Array();
    var lst_so_luong = new Array();
    var lst_don_gia = new Array();

    var lst_tr_LH = document.getElementById("tb_mat_hang").getElementsByTagName("tr");

    for (var i = 1; i < lst_tr_LH.length; i++) {
        lst_ma_hang.push(lst_tr_LH[i].getElementsByTagName("td")[0].innerText);
        lst_ma_kho.push(lst_tr_LH[i].getElementsByTagName("td")[2].innerText);
        lst_so_luong.push(lst_tr_LH[i].getElementsByTagName("td")[3].innerText);
        lst_don_gia.push(lst_tr_LH[i].getElementsByTagName("td")[4].innerText);
    }

    var data = {
        ma_pnk: form.txt_ctNumber.value,
        ma_hang_s: lst_ma_hang.join(","),
        ma_kho_s: lst_ma_kho.join(","),
        so_luong_s: lst_so_luong.join(","),
        don_gia_s: lst_don_gia.join(",")
    };

    $.ajax({
        type: "Post",
        url: "/NhapHang/CreateCT_PNK",
        data: data,
        dataType: "Json",
        success: function (result) {
            var j_result = JSON.parse(JSON.stringify(result));
            alert(j_result.message);
            export_NhapKho(form.txt_ctNumber.value);
        },
        error: function (result) {
            alert("Ajax: Error!");
        }
    });
    return false;
}

// Ajax: Xuất báo cáo
function export_NhapKho(ma) {
    var data = {
        ma: ma
    };
    $.ajax({
        type: "Post",
        url: "/NhapHang/PostExport",
        data: data,
        dataType: "Json",
        success: function (result) {
            window.open("/NhapHang/GetExport", "Thông tin phiếu nhập kho", "width=" + screen.width + ",height=" + screen.height);
            document.location.reload();
        },
        error: function (result) {
            alert("Ajax: Error!");
        }
    });

    return false;
}
// Ajax: Thực hiện thao tác nhập kho
function executeXuatKho(form) {
    //Thêm phiếu xuất kho ->Thêm chi tiết phiếu xuất kho
    themPhieuXuatKho(form);
    return false;
}
// Ajax: Thêm phiếu xuất kho -> 
function themPhieuXuatKho(form) {
    debugger;
    var tong_tien = 0;
    var lst_tr_LH = document.getElementById("tb_mat_hang").getElementsByTagName("tr");

    for (var i = 1; i < lst_tr_LH.length; i++) {
        tong_tien += parseFloat(lst_tr_LH[i].getElementsByTagName("td")[5].innerText);
    }
    var data = {
        khach_hang: form.txt_tenkh.value,
        sdt: form.txt_sdt.value,
        dia_chi: form.txt_diachi.value,
        ngay_xuat: form.datepicker.value,
        ma: form.txt_soct.value,
        thu_kho: form.txt_thukho.value,
        nguoi_lap_phieu: form.txt_nguoilapphieu.value,
        dien_giai: form.txt_des.value,
        tong_tien: tong_tien
    };
    $.ajax({
        type: "POST",
        url: "/XuatHang/CreatePXK",
        data: data,
        dataType: "Json",
        success: function (result) {            
            var j_result = JSON.parse(JSON.stringify(result));
            //alert(j_result.message);
            themCT_PhieuXuatKho(form);
        },
        error: function (result) {
            alert('Lỗi thêm phiếu xuất kho!');
        }

    });
    return false;
}
// Ajax: Thêm chi tiết phiếu xuất kho -> Kết thúc
function themCT_PhieuXuatKho(form) {   
    var lst_ma_hang = new Array();
    var lst_ma_kho = new Array();
    var lst_so_luong = new Array();
    var lst_don_gia = new Array();

    var lst_tr_LH = document.getElementById("tb_mat_hang").getElementsByTagName("tr");

    for (var i = 1; i < lst_tr_LH.length; i++) {
        lst_ma_hang.push(lst_tr_LH[i].getElementsByTagName("td")[0].innerText);
        lst_ma_kho.push(lst_tr_LH[i].getElementsByTagName("td")[2].innerText);
        lst_so_luong.push(lst_tr_LH[i].getElementsByTagName("td")[3].innerText);
        lst_don_gia.push(lst_tr_LH[i].getElementsByTagName("td")[4].innerText);
    }

    var data = {
        ma_pxk: form.txt_soct.value,
        ma_hang_s: lst_ma_hang.join(","),
        ma_kho_s: lst_ma_kho.join(","),
        so_luong_s: lst_so_luong.join(","),
        don_gia_s: lst_don_gia.join(",")
    };

    $.ajax({
        type: "Post",
        url: "/XuatHang/CreateCT_PXK",
        data: data,
        dataType: "Json",
        success: function (result) {
            var j_result = JSON.parse(JSON.stringify(result));
            //alert(j_result.message);
            export_XuatKho(form.txt_soct.value);
        },
        error: function (result) {
            alert("Ajax: Error!");
        }
    });
    return false;
}
// Ajax: Xuất báo cáo bán hàng
function export_XuatKho(ma) {
    var data = {
        ma: ma
    };
    $.ajax({
        type: "Post",
        url: "/XuatHang/PostExport",
        data: data,
        dataType: "Json",
        success: function (result) {
            window.open("/XuatHang/GetExport", "Thông tin phiếu xuất kho", "width=" + screen.width + ",height=" + screen.height);
            document.location.reload();
        },
        error: function (result) {
            alert("Ajax: Error!");
        }
    });

    return false;
}
