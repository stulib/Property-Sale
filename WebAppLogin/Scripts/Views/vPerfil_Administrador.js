function vPerfil_Administrador() {
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();

    this.getURLParams = function () {
        var results = window.location.href;
        var section = results.split("/");
        if (results == null) {
            return null;
        }
        return section[5];
    }

    var param = this.getURLParams();

    async function GetToApi(service, callBackFunction) {
        this.ctrlActions = new ControlActions();
        var jqxhr = await $.get(this.ctrlActions.GetUrlApiService(service), function (response) {
            if (response.Data != null & callBackFunction) {
                callBackFunction(response.Data);
            }
            FillData(response.Data)
            return response.Data;
        });
    };

    async function FillData(usuario) {
        this.ctrlActions.BindFields("forma_Admin_Upd", usuario);
        console.log(usuario);
    }

    this.Update = function () {
        usuario_Data = this.ctrlActions.GetDataForm('forma_Admin_Upd');
        usuario_Data.Estado = "Activo";
        usuario_Data.Id_Rol = "01";
        usuario_Data.Id_Agencia = " ";
        usuario_Data.Verificado = "Y";
        this.ctrlActions.PutToAPI(this.service, usuario_Data, function () {
            var v_PerfilU = new vPerfil_Administrador();
        });
    }

    GetToApi(this.service + '?id=' + param);
}

$(document).ready(function () {
    var v_PerfilU = new vPerfil_Administrador();
});