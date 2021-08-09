function vRegistrarBanco() {

	this.service = 'account';
	this.ctrlActions = new ControlActions();


	this.CreateBanco = function () {
		var banco_Data = {};
		banco_Data = this.ctrlActions.GetDataForm('frmBanco');
		banco_Data.Estado = "Activo";
		banco_Data.Id_Rol = "05";
		banco_Data.Id_Agencia = "0";
		banco_Data.Verificado = "N";
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, banco_Data, function () {
			var v_Gestion_Banco = new vRegistrarBanco();
		});
	}

	this.UpdateBanco = function () {
		var banco_Data = {};
		banco_Data = this.ctrlActions.GetDataForm('frmBanco');
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