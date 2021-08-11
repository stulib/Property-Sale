function vRegistrarUsuarioFinal() {
	this.service = 'usuario';
	this.ctrlActions = new ControlActions();
	
	this.CreateU = function () {
		var seleccionIdF = document.getElementById('tipo-id-Final').value;
		var usuario_Data = {};
		usuario_Data = this.ctrlActions.GetDataForm('frmRegistroUsuario');
		usuario_Data.Tipo_Id = seleccionIdF;
		usuario_Data.Estado = "Activo";
		usuario_Data.Id_Rol = "03";
		usuario_Data.Id_Agencia = "";
		usuario_Data.Verificado = "N";
		this.ctrlActions.PostToAPI(this.service, usuario_Data);
		document.getElementById('frmRegistroUsuario').reset();
		seleccionIdF.reset();
	}

	this.ShowPwdF = function () {
		var input = document.getElementById('txtPwdFinal');
		input.type = 'text';
		var showHiddenBtn = document.getElementById('ocultarPwdFinal');
		showHiddenBtn.hidden = false;
		var hideCurrentBtn = document.getElementById('mostrarPwdFinal');
		hideCurrentBtn.hidden = true;
	}

	this.HidePwdF = function () {
		var input = document.getElementById('txtPwdFinal');
		input.type = 'password';
		var showHiddenBtn = document.getElementById('mostrarPwdFinal');
		showHiddenBtn.hidden = false;
		var hideCurrentBtn = document.getElementById('ocultarPwdFinal');
		hideCurrentBtn.hidden = true;
	}
}

$(document).ready(function () {
	var vregUFinal = new vRegistrarUsuarioFinal();
	var hideBtn = document.getElementById('ocultarPwdFinal');
	hideBtn.hidden = true;
});