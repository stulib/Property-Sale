function vPerfil_Administrador() {
    this.service = 'usuario?id=';
    this.ctrlActions = new ControlActions();
    this.columns = "Id,Nombre,Apellidos,Fecha_Nac,Contrasenna,Email,Telefono,Nombre_Rol";

    this.getURLParams = function () {
        var results = window.location.href;
        var section = results.split("/");
        if (results == null) {
            return null;
        }
        return section[5];
    }

    var param = this.getURLParams();

    console.log(param);

    var usuario_Data = {};
    usuario_Data = this.ctrlActions.GetToApi(this.service, this.FillData);

    /*this.FillData = function (usuario_Data) {
        this.ctrlActions.BindFields("forma_Admin_Upd", usuario_Data);
        return data;
    }*/

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

    this.mostrarPWD = function () {
        $('#verPassword').on('mousedown', function () {
            $('#Password').attr("type", "text");
        });

        $('#verPassword').on('mouseup mouseleave', function () {
            $('#Password').attr("type", "password");
        });

    }

    this.mostrarPWDC = function () {
        $('#verPasswordC').on('mousedown', function () {
            $('#Password').attr("type", "text");
        });

        $('#verPasswordC').on('mouseup mouseleave', function () {
            $('#Password').attr("type", "password");
        });

    }
}

$(document).ready(function () {
    var v_PerfilU = new vPerfil_Administrador();
    //v_PerfilU.FillData();
});