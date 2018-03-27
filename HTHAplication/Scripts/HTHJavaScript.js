// Func: Thay đổi tên/địa chỉ ứng với mã nhà cung cấp
function changeNCC(select_ncc) {
    var li = document.getElementById("ul_staff").getElementsByTagName("li")[select_ncc.selectedIndex];
    document.getElementById("txt_staffName").value = li.getElementsByTagName("input")[0].value;   
}