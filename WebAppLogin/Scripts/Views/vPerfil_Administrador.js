function vPerfil_Administrador() {
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();

    this.FillData = function () {

    }

    this.Update = function () {
        var usuario_Data = {};
        usuario_Data = this.ctrlActions.GetDataForm('forma_Admin_Upd');
        usuario_Data.Estado = "Activo";
        usuario_Data.Id_Rol = "01";
        usuario_Data.Id_Agencia = " ";
        usuario_Data.Verificado = "Y";
        this.ctrlActions.PutToAPI(this.service, usuario_Data, function () {
            var v_PerfilU = new vPerfil_Administrador();
            v_PerfilU.FillData();
        });
    }
}

$(document).ready(function () {
    var v_PerfilU = new vPerfil_Administrador();
    v_PerfilU.FillData();
});