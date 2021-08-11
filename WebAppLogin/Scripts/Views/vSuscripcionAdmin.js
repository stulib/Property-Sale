
function vSuscripcionAdmin() {

	this.tblSuscripcionesId = 'tblSuscripcion';
	this.service = 'suscripcion';
	this.ctrlActions = new ControlActions();
	this.columns = "Id,Nombre,Cantidad_Anuncios,Periodo_Facturacion";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblSuscripcionesId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblSuscripcionesId, true);
	}

	this.Create = function () {
		var suscripcionData = {};
		suscripcionData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, suscripcionData, function () {
			var reload = new vSuscripcionAdmin();
			reload.ReloadTable();
		});
	}

	this.Update = function () {

		var suscripcionData = {};
		suscripcionData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, suscripcionData, function () {
			var reload = new vSuscripcionAdmin();
			reload.ReloadTable();
		});
	}

	this.Delete = function () {

		var suscripcionData = {};
		suscripcionData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, suscripcionData, function () {
			var reload = new vSuscripcionAdmin();
			reload.ReloadTable();
		});
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {
	var vsuscripcion = new vSuscripcionAdmin();
	vsuscripcion.RetrieveAll();

});

