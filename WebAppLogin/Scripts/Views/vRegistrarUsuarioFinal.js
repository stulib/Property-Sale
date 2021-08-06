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
		frmRegistroUsuario.reset();
	}
}

$(document).ready(function () {
	var vpropietario = new vPropietarios();
});