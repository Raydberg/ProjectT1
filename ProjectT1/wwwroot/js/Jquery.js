$(document).ready(function () {
    $("#marcaDropdown").change(function () {
        var idMarca = $(this).val();
        $("#modeloDropdown").empty().append('<option value="">Seleccione Modelo</option>').prop("disabled", true);
        if (idMarca) {
            $.ajax({
                url: "/Vehiculos/ObtenerModelos",
                type: "GET",
                data: { idMarca: idMarca },
                success: function (modelos) {
                    $.each(modelos, function (index, modelo) {
                        $("#modeloDropdown").append('<option value="' + modelo.idModelo + '">' + modelo.nomModelo + '</option>');
                    });
                    $("#modeloDropdown").prop("disabled", false);
                }
            })
        }
    })
})


$(document).ready(function () {

    $("#marcaDropdown").change(function () {
        var marcaID = $(this).val();
        console.log("idMarca : " + marcaID)

    })

})