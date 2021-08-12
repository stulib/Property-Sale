function vRegistrarAgencia() {

	this.service = 'agencia';
	this.ctrlActions = new ControlActions();

	this.Create = function () {
		var agencia_Data = {};
		agencia_Data = this.ctrlActions.GetDataForm('frmEdition');
		agencia_Data.Estado = "Activo";
		this.ctrlActions.PostToAPI(this.service, agencia_Data);
		document.getElementById('frmEdition').reset();
	}
}

//ON DOCUMENT READY
$(document).ready(function () {
	var vRegistrarAgencia = new vRegistrarAgencia();
});