function AccountProfile() {

	this.service = 'account';
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
        this.ctrlActions.BindFields("frmPerfil", usuario);
        var seleccionIdU = document.getElementById('tipo-id-U');
        var tipoID = usuario.TIPO_ID;
        if (tipoID == "Física") {
            seleccionIdU.getElementsByTagName('option')[1].selected = 'selected'
        } else if (tipoID == "Jurídica") {
            seleccionIdU.getElementsByTagName('option')[2].selected = 'selected'
        } else if (tipoID == "DIMEX") {
            seleccionIdU.getElementsByTagName('option')[3].selected = 'selected'
        } else if (tipoID == "Pasaporte") {
            seleccionIdU.getElementsByTagName('option')[4].selected = 'selected'
        }
    }

	this.UpdateBanco = function () {
		var banco_Data = {};
		var seleccionIdU = document.getElementById('tipo-id-U').value;
		banco_Data = this.ctrlActions.GetDataForm('frmPerfil');
        banco_Data.TIPO_ID = seleccionIdU;
		this.ctrlActions.PutToAPI(this.service, banco_Data, function () {
            var v_Gestion_Perfil_Banco = new AccountProfile();
		});

    }

    GetToApi(this.service + '?id=' + param);
}

//ON DOCUMENT READY
$(document).ready(function () {
    var v_Gestion_Perfil_Banco = new AccountProfile();
});