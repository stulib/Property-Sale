
function vPropietarios() {

	this.tblCustomersId = 'tblCustomers';
	this.service = 'usuario';
	this.ctrlActions = new ControlActions();
	this.columns = "Identification,Nombre,Apellidos,Telefono";

	this.Create = function () {
		var propietario_Data = {};
		propietario_Data = this.ctrlActions.GetDataForm('frmEdition');
		propietario_Data.Contrasenna = "Contrasenna123!";
		propietario_Data.Estado = "Activo";
		propietario_Data.Id_Rol = "02";
		propietario_Data.Id_Agencia = "0";
		propietario_Data.Verificado = "N";
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, propietario_Data);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, customerData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var customerData = {};
		customerData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, customerData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {
	var vpropietario = new vPropietarios();
});