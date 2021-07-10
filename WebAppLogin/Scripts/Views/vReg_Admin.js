function vReg_Admin() {
	this.tblCustomersId = 'tblUsuariosAdmin';
	this.service = 'usuario';
	this.ctrlActions = new ControlActions();
	this.columns = "Id, Tipo_Id, Nombre, Apellidos, Fecha_Nac, Contrasenna, Email, Telefono";

	this.Create = function () {
		var usuario_Data = {};
		usuario_Data = this.ctrlActions.GetDataForm('forma_Reg_Admin');
		this.ctrlActions.PostToAPI(this.service, usuario_Data, function () {
			var v_Gestion_Admin = new vReg_Admin();
			v_Gestion_Admin.ReloadTable();
		});
	}

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblCustomersId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblCustomersId, true);
	}

	this.Update = function () {

		var usuario_Data = {};
		usuario_Data = this.ctrlActions.GetDataForm('frmEdition');
		this.ctrlActions.PutToAPI(this.service, usuario_Data, function() {
			var v_Gestion_Admin = new vReg_Admin();
			v_Gestion_Admin.ReloadTable();
		});
	}

	this.Delete = function () {

		var usuario_Data = {};
		usuario_Data = this.ctrlActions.GetDataForm('frmEdition');
		this.ctrlActions.DeleteToAPI(this.service, usuario_Data, function () {
			var v_Gestion_Admin = new vReg_Admin();
			v_Gestion_Admin.ReloadTable();
		});
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

$(document).ready(function () {
	var v_Gestion_Admin = new vReg_Admin();
	v_Gestion_Admin.RetrieveAll();

});