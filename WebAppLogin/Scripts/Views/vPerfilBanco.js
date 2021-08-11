function vPerfilBanco() {

	this.service = 'account';
	this.ctrlActions = new ControlActions();


	this.UpdateBanco = function () {
		var banco_Data = {};
		banco_Data = this.ctrlActions.GetDataForm('frmPerfil');
		this.ctrlActions.PutToAPI(this.service, banco_Data, function () {
			var v_Gestion_Banco = new vRegistrarBanco();
			/*vCustomer.ReloadTable();*/
		});

	}
}

//ON DOCUMENT READY
$(document).ready(function () {
	var v_Gestion_Banco = new vRegistrarBanco();
});