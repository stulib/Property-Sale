function vRegistrarPropiedades() {

	this.service = 'propiedad';
	this.ctrlActions = new ControlActions();



	this.Update = function () {
		var propiedad_Data = {};
		propiedad_Data = this.ctrlActions.GetDataForm('forma_Propiedad_Upd');
		this.ctrlActions.PutToAPI(this.service, propiedad_Data, function () {
			var vpropiedad = new vPropiedades();
			vpropiedad.ReloadTable();
		});
	}

	this.Enable = function () {
		var propiedad_Data = {};
		propiedad_Data = this.ctrlActions.GetDataForm('forma_Propiedad_Upd');
		propiedad_Data.Estado = "Activa";
		this.ctrlActions.PutToAPI(this.service, propiedad_Data, function () {
			var vpropiedad = new vPropiedades();
			vpropiedad.ReloadTable();
		});
	}

	this.Disable = function () {
		var propiedad_Data = {};
		propiedad_Data = this.ctrlActions.GetDataForm('forma_Propiedad_Upd');
		propiedad_Data.Estado = "Inactiva";
		this.ctrlActions.PutToAPI(this.service, propiedad_Data, function () {
			var vpropiedad = new vPropiedades();
			vpropiedad.ReloadTable();
		});
	}

	this.Delete = function () {
		var propiedad_Data = {};
		propiedad_Data = this.ctrlActions.GetDataForm('forma_Propiedad_Upd');
		this.ctrlActions.DeleteToAPI(this.service, propiedad_Data, function () {
			var vpropiedad = new vPropiedades();
			vpropiedad.ReloadTable();
		});
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('forma_Propiedad_Upd', data);
	}
}

$(document).ready(function () {
	var vregistrarpropiedades = new vRegistrarPropiedades();
	vregistrarpropiedades.RetrieveAll();
});