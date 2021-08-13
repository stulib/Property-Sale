function UsuarioProfile() {
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
        this.ctrlActions.BindFields("forma_Usuario_Upd", usuario);
        var seleccionIdU = document.getElementById('tipo-id-U');
        var tipoID = usuario.Tipo_Id;
        if (tipoID == "Física" | tipoID == "Fisica") {
            seleccionIdU.getElementsByTagName('option')[1].selected = 'selected'
        } else if (tipoID == "Jurídica" | tipoID == "Juridica") {
            seleccionIdU.getElementsByTagName('option')[2].selected = 'selected'
        } else if (tipoID == "DIMEX") {
            seleccionIdU.getElementsByTagName('option')[3].selected = 'selected'
        } else if (tipoID == "Pasaporte") {
            seleccionIdU.getElementsByTagName('option')[4].selected = 'selected'
        }
        var date_B = document.getElementById('txtDOB');
        dateFormat = moment(usuario.Fecha_Nac, 'YYYY-MM-DDTHH:mm:ss').format('YYYY-MM-DD')
        date_B.value = dateFormat;
    }

    this.UpdateU = function () {
        var seleccionIdU = document.getElementById('tipo-id-U').value;
        usuario_Data = this.ctrlActions.GetDataForm('forma_Usuario_Upd');
        usuario_Data.Tipo_Id = seleccionIdU;
        this.ctrlActions.PutToAPI(this.service, usuario_Data, function () {
            var v_PerfilU = new UsuarioProfile();
        });
    }

    GetToApi(this.service + '?id=' + param);
}

$(document).ready(function () {
    var vUPerfil = new UsuarioProfile();
});