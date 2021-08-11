function vRegistrarBanco() {

	this.service = 'account';
	this.ctrlActions = new ControlActions();


	this.CreateBanco = function () {
		var seleccionIdb = document.getElementById('tipo-id-Banco').value;
		var banco_Data = {};
		banco_Data = this.ctrlActions.GetDataForm('frmBanco');
		banco_Data.Tipo_Id = seleccionIdb;
		banco_Data.Estado = "Activo";
		banco_Data.Id_Rol = "05";
		banco_Data.Id_Agencia = "0";
		banco_Data.Verificado = "N";
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, banco_Data, function () {
			var v_Gestion_Banco = new vRegistrarBanco();
		});
		document.getElementById('frmBanco').reset();
	}

	this.ShowPwdB = function () {
		var input = document.getElementById('txtPwdB');
		input.type = 'text';
		var showHiddenBtn = document.getElementById('ocultarPwdB');
		showHiddenBtn.hidden = false;
		var hideCurrentBtn = document.getElementById('mostrarPwdB');
		hideCurrentBtn.hidden = true;
	}

	this.HidePwdB = function () {
		var input = document.getElementById('txtPwdB');
		input.type = 'password';
		var showHiddenBtn = document.getElementById('mostrarPwdB');
		showHiddenBtn.hidden = false;
		var hideCurrentBtn = document.getElementById('ocultarPwdB');
		hideCurrentBtn.hidden = true;
	}


}

//ON DOCUMENT READY
$(document).ready(function () {
	var v_Gestion_Banco = new vRegistrarBanco();
	var hideBtn = document.getElementById('ocultarPwdB');
	hideBtn.hidden = true;
});