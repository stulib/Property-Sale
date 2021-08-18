function vRegistrarPropiedades() {

	this.service = 'propiedad';
	this.ctrlActions = new ControlActions();


	const boton_foto = document.getElementById('upload_widget2');
	const imagen = document.getElementById('foto-propiedad');




	let widget_cloudinary = cloudinary.createUploadWidget({
		cloudName: 'techhouse',
		uploadPreset: 'bew0fohc',

	}, (err, result) => {
		if (!err && result && result.event === 'success') {
			console.log('Imagen subida con éxito', result.info);
			imagen.src = result.info.secure_url;
		}
	});

	boton_foto.addEventListener('click', () => {
		widget_cloudinary.open();
	}, false);


	this.CreateP = function () {
		var seleccionIdF = document.getElementById('tipo-id-Propiedad').value;
		var propiedad_Data = {};
		propiedad_Data = this.ctrlActions.GetDataForm('forma_Propiedad_Upd');
		propiedad_Data.Id = Math.floor(Math.random() * 9000) + 1000;
		propiedad_Data.Tipo = seleccionIdF;
		propiedad_Data.Fecha_Publicacion = new Date();
		propiedad_Data.Latitud = "9.934739";
		propiedad_Data.Longitud = "84.087502";
		propiedad_Data.Estado = "Activo";
		propiedad_Data.Provincia = "Heredia";
		propiedad_Data.Canton = "Santo Domingo";
		propiedad_Data.Distrito = "Santa Rosa";
		propiedad_Data.Longitud = "84.087502";
		propiedad_Data.Destacado = "No";
		propiedad_Data.Programado = "No";
		propiedad_Data.Visitas = 0;
		this.ctrlActions.PostToAPI(this.service, propiedad_Data, function () {
			var vregUFinal = new vRegistrarPropiedades();
			document.getElementById('frmRegistroUsuario').reset();
			document.getElementById('tipo-id-Final').getElementsByTagName('option')[0].selected = 'selected'
		});
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('forma_Propiedad_Upd', data);
	}
}

$(document).ready(function () {
	var vregistrarpropiedades = new vRegistrarPropiedades();
});