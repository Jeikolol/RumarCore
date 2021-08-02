function validate(ced) {
	var validacion = validate_identification(ced);
	if (validacion === false) {
		toastr.error('La cédula está no es correcta');
		$(this).focus();
	}
}


function validate_identification(ced) {
	var c = ced.replace(/-/g, '');
	var cedula = c.substr(0, c.length - 1);
	var verificador = c.substr(c.length - 1, 1);
	var suma = 0;
	var cedulaValida = false;
	if (ced.length < 11) { return false; }
	for (i = 0; i < cedula.length; i++) {
		mod = "";
		if ((i % 2) == 0) { mod = 1 } else { mod = 2 }
		res = cedula.substr(i, 1) * mod;
		if (res > 9) {
			res = res.toString();
			uno = res.substr(0, 1);
			dos = res.substr(1, 1);
			res = eval(uno) + eval(dos);
		}
		suma += eval(res);
	}
	el_numero = (10 - (suma % 10)) % 10;
	if (el_numero == verificador && cedula.substr(0, 3) != "000") {
		cedulaValida = true;
	}
	else {
		cedulaValida = false;
	}
	return cedulaValida;
	
}