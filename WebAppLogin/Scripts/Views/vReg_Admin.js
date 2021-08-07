function vReg_Admin() {
    this.tblUsuariosAdmin = 'tblUsuariosAdmin';
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();
    this.columns = "Id,Nombre,Apellidos,Fecha_Nac,Contrasenna,Email,Telefono,Nombre_Rol";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTableAdmin(this.service, this.tblUsuariosAdmin, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTableAdmin(this.service, this.tblUsuariosAdmin, true);
    }

    this.SaveSelecteduser = function (data) {
        this.ctrlActions.BindFields('forma_Usuario_Upd', data);
        this.ctrlActions.BindFields('forma_Usuario_Display', data);
        return data;
    }


    this.Create = function () {
        var usuario_Data = {};
        usuario_Data = this.ctrlActions.GetDataForm('forma_Reg_Admin');
        usuario_Data.Contrasenna = "tempTest1!";
        usuario_Data.Estado = "Activo";
        usuario_Data.Id_Rol = "01";
        usuario_Data.Id_Agencia = "";
        usuario_Data.Verificado = "N";
        this.ctrlActions.PostToAPI(this.service, usuario_Data, function () {
            var v_Gestion_Admin = new vReg_Admin();
            v_Gestion_Admin.ReloadTable();
        });
    }

    this.Enable = function () {
        var usuario_Data = {};
        usuario_Data = this.ctrlActions.GetDataForm('forma_Usuario_Upd');
        usuario_Data.Estado = "Activo";
        this.ctrlActions.PutToAPI(this.service, usuario_Data, function () {
            var v_Gestion_Admin = new vReg_Admin();
            v_Gestion_Admin.ReloadTable();
        });
    }

    this.Disable = function () {
        var usuario_Data = {};
        usuario_Data = this.ctrlActions.GetDataForm('forma_Usuario_Upd');
        usuario_Data.Estado = "Inactivo";
        console.log(usuario_Data);
        this.ctrlActions.PutToAPI(this.service, usuario_Data, function () {
            var v_Gestion_Admin = new vReg_Admin();
            v_Gestion_Admin.ReloadTable();
        });
    }

    this.Delete = function () {
        var usuario_Data = {};
        usuario_Data = this.ctrlActions.GetDataForm('forma_Usuario_Upd');
        this.ctrlActions.DeleteToAPI(this.service, usuario_Data, function () {
            var v_Gestion_Admin = new vReg_Admin();
            v_Gestion_Admin.ReloadTable();
        });
    }

    this.ShowPwd = function () {
        var input = document.getElementById('txtPwd');
        input.type = 'text';
        var showHiddenBtn = document.getElementById('ocultarPwd');
        showHiddenBtn.hidden = false;
        var hideCurrentBtn = document.getElementById('mostrarPwd');
        hideCurrentBtn.hidden = true;
    }

    this.HidePwd = function () {
        var input = document.getElementById('txtPwd');
        input.type = 'password';
        var showHiddenBtn = document.getElementById('mostrarPwd');
        showHiddenBtn.hidden = false;
        var hideCurrentBtn = document.getElementById('ocultarPwd');
        hideCurrentBtn.hidden = true;
    }
}

$(document).ready(function () {
    var v_Gestion_Admin = new vReg_Admin();
    var hideBtn = document.getElementById('ocultarPwd');
    hideBtn.hidden = true;
    v_Gestion_Admin.RetrieveAll();
});