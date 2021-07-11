function vReg_Admin() {
	this.tblUsuariosAdmin = 'tblUsuariosAdmin';
	this.service = 'usuario';
	this.ctrlActions = new ControlActions();
	this.columns = "Id,Nombre,Apellidos,Fecha_Nac,Contrasenna,Email,Telefono,Nombre_Rol";


	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblUsuariosAdmin, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblUsuariosAdmin, true);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('forma_Reg_Admin', data);
	}

	this.Create = function () {
		var usuario_Data = {};
		usuario_Data = this.ctrlActions.GetDataForm('forma_Reg_Admin');
		this.ctrlActions.PostToAPI(this.service, usuario_Data, function () {
			var v_Gestion_Admin = new vReg_Admin();
			v_Gestion_Admin.ReloadTable();
		});
	}

	this.Update = function () {

		var usuario_Data = {};
		usuario_Data = this.ctrlActions.GetDataForm('forma_Reg_Admin');
		this.ctrlActions.PutToAPI(this.service, usuario_Data, function() {
			var v_Gestion_Admin = new vReg_Admin();
			v_Gestion_Admin.ReloadTable();
		});
	}

	this.Disable = function () {
		var usuario_Data = {};
		usuario_Data = this.ctrlActions.GetDataForm('forma_Reg_Admin');
		usuario_Data = {
			Estado : "Desactivado"
		};
		this.ctrlActions.PutToAPI(this.service, usuario_Data, function () {
			var v_Gestion_Admin = new vReg_Admin();
			v_Gestion_Admin.ReloadTable();
		});
	}

	this.Delete = function () {

		var usuario_Data = {};
		usuario_Data = this.ctrlActions.GetDataForm('forma_Reg_Admin');
		this.ctrlActions.DeleteToAPI(this.service, usuario_Data, function () {
			var v_Gestion_Admin = new vReg_Admin();
			v_Gestion_Admin.ReloadTable();
		});
	}
}

$(document).ready(function () {
	var v_Gestion_Admin = new vReg_Admin();
	v_Gestion_Admin.RetrieveAll();

});