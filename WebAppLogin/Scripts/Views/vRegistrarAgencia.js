function vRegistrarAgencia() {

	this.service = 'agencia';
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

	var idUsuario = document.getElementById("txtIdUser");
	idUsuario.value = param;

	this.CreateAgencia = function () {
		var seleccionIdA = document.getElementById('tipo-id-Agencia').value;
		var agencia_Data = {};
		agencia_Data = this.ctrlActions.GetDataForm('frmEdition');
		agencia_Data.Tipo = seleccionIdA;
		agencia_Data.Estado = "Activo";
		this.ctrlActions.PostToAPI(this.service, agencia_Data, function () {
			document.getElementById('frmEdition').reset();
			document.getElementById('tipo-id-Agencia').getElementsByTagName('option')[0].selected = 'selected'
		});
	}
}

//ON DOCUMENT READY
$(document).ready(function () {
	var vR_Agencia = new vRegistrarAgencia();
});