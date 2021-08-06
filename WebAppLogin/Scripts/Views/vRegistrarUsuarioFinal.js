function vRegistrarUsuarioFinal() {
	this.service = 'usuario';
	this.ctrlActions = new ControlActions();
	
	this.CreateU = function () {
		var usuario_Data = {};
		usuario_Data = this.ctrlActions.GetDataForm('frmRegistroUsuario');
		usuario_Data.Estado = "Activo";
		usuario_Data.Id_Rol = "03";
		usuario_Data.Id_Agencia = "";
		usuario_Data.Verificado = "N";
		this.ctrlActions.PostToAPI(this.service, usuario_Data);
		getElementById('frmRegistroUsuario').reset();
	}

	this.ShowPwd = function () {
		var input = document.getElementById('txtPwd');
		input.type = 'text';
		var showHiddenBtn = document.getElementById('ocultarPwd');
		showHiddenBtn.hidden = false;
		var hideCurrentBtn = document.getElementById('mostrarPwd');
		hideCurrentBtn.hidden = true;
	}

	this.HidePwd = function () {
		var input = document.getElementById('txtPwd');
		input.type = 'password';
		var showHiddenBtn = document.getElementById('mostrarPwd');
		showHiddenBtn.hidden = false;
		var hideCurrentBtn = document.getElementById('ocultarPwd');
		hideCurrentBtn.hidden = true;
	}
}

$(document).ready(function () {
	var vpropietario = new vPropietarios();
	var hideBtn = document.getElementById('ocultarPwd');
	hideBtn.hidden = true;
});