function vVerificarUsuario() {
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();

    this.getURLParams = function () {
        var results = window.location.href;
        var section = results.split("/");
        if (results == null) {
            return null;
        }
        return section[5];
    }

    var param = this.getURLParams();

    this.VerifyNew = function () {
        var usuario_Data = {};
        usuario_Data.Id = param;
        usuario_Data.Cod_Email = document.getElementById('txtCodEmail').value;
        usuario_Data.Cod_Celular = document.getElementById('txtCodCel').value;
        this.ctrlActions.PostToAPI(this.service, usuario_Data, function () {
            var url = 'http://localhost:52014/Home/vVerificacionCompleta';
            window.location.href = url;
        });
    }
}

$(document).ready(function () {
    var v_Verificar = new vVerificarUsuario();
});