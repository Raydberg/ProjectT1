$(document).ready(function () {

    $("#modeloDropdown").change(function () {
        var modeloID = $(this).val();

        if (modeloID) {
            $.ajax({
                url: "/Vehiculos/ObtenerMarcas",
                type: "GET",
                data: { modeloID: modeloID },
                success: function (marcas) {
                    $("#marcaDropdown").empty().append("<option value = ''> Selecione una marca </option>").prop("disabled", false);
                    $.each(marcas, function (index, marca) {
                        $("#marcaDropdown").append("<option value = '" + marca.IdMarca + "'>" + marca.NomMarca + "</option>");
                    });

                    $("#marcaDropdown").prop("disabled", false);
                }
            })
        }
        else {
            $("#marcaDropdown").empty().append("<option value = ''> Selecione una marca </option>").prop("disabled", true);
        }
    });
});
