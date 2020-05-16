var url = "handler/UserManagerhandler.ashx";


$(function () {
    $.post(url, function (jsonData) {
     //加载,拼接dom
        loadData(jsonData);
    },"json");
}
)

//用来处理请求结果，生成表格
function loadData(data) {
    $.post(url, { type: "role" }, function (jsonData) {
        $("tbody").empty();
        for (var i = 0; i < data.length; i++) {
            var u = data[i];
            var $tr = $("<tr></tr>");
            $tr.append("<td>" + u.UserId + "</td>");
            $tr.append("<td>" + u.LoginId + "</td>");
            $tr.append("<td>" + u.UserName + "</td>");
            $tr.append("<td>" + u.Phone + "</td>");
            $tr.append("<td>" + u.UserStatus + "</td>");
            $tr.append("<td>" + u.DateCreated + "</td>");
            //生成角色的单元格
            var $roleId = $("<td></td>");
            var $roleSelect = $("<select id='ddlRoles" + u.UserId + "'></select>");
            for (var j = 0; j < jsonData.length; j++) {
                var role = jsonData[j];//角色数据
                if (u.RoleId == role.RoleId) {
                    $roleSelect.append("<option value=' " + role.RoleId + "' selected='true'>" + role.Name + "</option>");

                }
                else {
                    $roleSelect.append("<option value=' " + role.RoleId + "'>" + role.Name + "</option>");

                }
            }
            $roleId.append($roleSelect);
            $roleId.append("<input type='button' class='pure-button pure-button-primary' value='修改'  onclick='changeRole(\"#ddlRoles" + u.UserId + "\"," + u.UserId + ")' >");
            $tr.append($roleId);//将单元格拼接到行上
            if (u.RoleId == 1) {
                $tr.append("<td>  -  </td>");
            } else {
                $tr.append("<td>  <input type='button' class='pure-button' value='禁用'></td>");
            }
            $("tbody").append($tr);


        }
    },"json");
}


function changeRole(ddl, uid) {
    var roleId = $(ddl).val();
    $.post(url, { uid: uid, rid: roleId }, function (jsonData) {
        alert("修改成功");
        loadData(jsonData);

    })
}