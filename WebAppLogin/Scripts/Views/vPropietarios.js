﻿function vPropietarios() {

	this.service = 'usuario';
	this.ctrlActions = new ControlActions();

	this.CreateProp = function () {
		var seleccionIdP = document.getElementById('tipo-id-Prop').value;
		var propietario_Data = {};
		propietario_Data = this.ctrlActions.GetDataForm('frmPropietario');
		propietario_Data.Tipo_Id = seleccionIdP;
		propietario_Data.Estado = "Activo";
		propietario_Data.Id_Rol = "02";
		propietario_Data.Id_Agencia = "0";
		propietario_Data.Verificado = "N";
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, propietario_Data, function () {
			var vpropietario = new vPropietarios();
			document.getElementById('frmPropietario').reset();
			document.getElementById('tipo-id-Prop').getElementsByTagName('option')[0].selected = 'selected'
		});
	}

	this.ShowPwdP = function () {
		var input = document.getElementById('txtPwdP');
		input.type = 'text';
		var showHiddenBtn = document.getElementById('ocultarPwdP');
		showHiddenBtn.hidden = false;
		var hideCurrentBtn = document.getElementById('mostrarPwdP');
		hideCurrentBtn.hidden = true;
	}

	this.HidePwdP = function () {
		var input = document.getElementById('txtPwdP');
		input.type = 'password';
		var showHiddenBtn = document.getElementById('mostrarPwdP');
		showHiddenBtn.hidden = false;
		var hideCurrentBtn = document.getElementById('ocultarPwdP');
		hideCurrentBtn.hidden = true;
	}
}

//ON DOCUMENT READY
$(document).ready(function () {
	var vpropietario = new vPropietarios();
	var hideBtn = document.getElementById('ocultarPwdP');
	hideBtn.hidden = true;
});