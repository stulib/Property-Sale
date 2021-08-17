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
		suscripcionData.Estado = "Activa";
		this.ctrlActions.PostToAPI(this.service, suscripcionData, function () {
			var reload = new vSuscripcionAdmin();
			reload.ReloadTable();
			document.getElementById('frmEdition').reset();
			var campoId = document.getElementById('txtId');
			campoId.disabled = false;
		});
	}

	this.Update = function () {

		var suscripcionData = {};
		suscripcionData = this.ctrlActions.GetDataForm('frmEdition');
		this.ctrlActions.PutToAPI(this.service, suscripcionData, function () {
			var reload = new vSuscripcionAdmin();
			reload.ReloadTable();
			document.getElementById('frmEdition').reset();
			var campoId = document.getElementById('txtId');
			campoId.disabled = false;
		});
	}

	this.Delete = function () {

		var suscripcionData = {};
		suscripcionData = this.ctrlActions.GetDataForm('frmEdition');
		this.ctrlActions.DeleteToAPI(this.service, suscripcionData, function () {
			var reload = new vSuscripcionAdmin();
			reload.ReloadTable();
			document.getElementById('frmEdition').reset();
			var campoId = document.getElementById('txtId');
			campoId.disabled = false;
		});
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
		var campoId = document.getElementById('txtId');
		campoId.disabled = true;
	}

	this.ReleaseForm = function () {
		document.getElementById('frmEdition').reset();
		var campoId = document.getElementById('txtId');
		campoId.disabled = false;
	}
}

//ON DOCUMENT READY
$(document).ready(function () {
	var vsuscripcion = new vSuscripcionAdmin();
	vsuscripcion.RetrieveAll();
});

