function InsertarBarrio() {
var Barrio = new Object();
    Barrio.NomBarrio = $("#lblNomBarrio").val();
Barrio.Ciudad = $("#txtCiudad").val();
    $.ajax({
        url: '/Ahorro/CrearBarrio',
        type: "POST",
        dataType: "JSON",
        data: {
            objBarrio : JSON.stringify(Barrio)
          },
        success: function (data) {
            if (data.Resultado == 1) {
                alert("guardado con exito");
              
            } else {
                alert("No se guardo el dato");
            }
        }
    
    });
};

function ListarBarrios(){
    $.ajax({
        url: '/Ahorro/ListarBarrios',
        type:"POST",
        dataType: "JSON",
        success: function(data)
        {
        for(var i=0;i < data.length; i++)
        {
        $("<option value='" + data[i].IdBarrio + "'>" + data[i].NomBarrio + "</option>").appendTo("#CbxBarrio");
        }

      }

   });

}

function ValidarCampos()
{
var respuesta=true;
if($('#txtNomsocio').val()==''){
respuesta=false;
}
if($('#txtCedula').val()==''){
respuesta=false;
}
if($('#txtDireccion').val()==''){
respuesta=false;
}
if($('#txtValAhorro').val()==''){
respuesta=false;
}
return respuesta;
}



function CrearSocio()
{

if(ValidarCampos()){
var Socio = new Object();
Socio.NomSocio= $("#txtNomsocio").val();
Socio.Cedula= $("#txtCedula").val();
Socio.IdBarrio= $("#CbxBarrio").val();
Socio.Direccion= $("#txtDireccion").val();
Socio.ValAhorro= $("#txtValAhorro").val();
alert( JSON.stringify(Socio));
$.ajax({
    url: '/Ahorro/CrearSocio',
    type:"POST",
    dataType:"JSON",
    data:{
    objSocio : JSON.stringify(Socio)
        },
        success: function(data)
    {
        if(data.Resultado == 1)
        {
        alert("Socio Guardado con exito");
        ListarSocios();
        }else
            {
        alert("No se pudo guardar el socio");
            }
    }

    });

}else{
alert("campos vacios");
}

}

function ActualizarSocio(id)
{
var Socio = new Object();
Socio.IdSocio=id;
Socio.NomSocio= $("#txtNomsocio").val();
Socio.Cedula= $("#txtCedula").val();
Socio.IdBarrio= $("#CbxBarrio").val();
Socio.Direccion= $("#txtDireccion").val();
Socio.ValAhorro= $("#txtValAhorro").val();
$.ajax({
    url: '/Ahorro/ActualizarSocio',
    type:"POST",
    dataType:"JSON",
    data:{
    objSocio : JSON.stringify(Socio)
        },
        success: function(data)
    {
        if(data.Resultado == 1)
        {
        alert("Socio Actualizado con exito");
         location.reload();
        }else
            {
        alert("No se pudo Actualizar el socio");
            }
    }

    });
}

function EliminarSocio(id)
{
var Socio = new Object();
Socio.IdSocio=id;
$.ajax({
    url: '/Ahorro/EliminarSocio',
    type:"POST",
    dataType:"JSON",
    data:{
    objSocio : JSON.stringify(Socio)
        },
        success: function(data)
    {
        if(data.Resultado == 1)
        {
        alert("Socio Eliminado con exito");
         location.reload();
     
        }else
            {
        alert("No se pudo Eliminar el socio");
            }
    }

    });
}

function ListarSocios() {
 $('#Registro').remove();
    $.ajax({
        url: '/Ahorro/ListarSocios',
        type: "POST",
        dataType: "JSON",
        success: function (data) {
            if (data != null){
                for (var i = 0; i < data.length; i++) {
                    html = "";
                    html += "<tr id='Registro'>";
                    html += "<td>"+data[i].IdSocio+"</td>";
                    html += "<td>"+data[i].NomSocio+"</td>";
                    html += "<td>"+data[i].Cedula+"</td>";
                    html += "<td>"+data[i].NomBarrio+"</td>";
                    html += "<td>"+data[i].ValAhorro+"</td>";
                    html += "<td>"+data[i].Direccion+"</td>";
                    html += "<td><span class='glyphicon glyphicon-trash'onClick='EliminarSocio(" + data[i].IdSocio + ")'>&nbsp</span><span class='glyphicon glyphicon-pencil' onClick='ActualizarSocio(" + data[i].IdSocio +")'></span></td>"
                    html += "</tr>";
                    $(html).appendTo("#tblSocios");
                }
            }
        }
    });
};


$(document).ready(function () {
$('.fondo').css('background','red');
ListarBarrios();
ListarSocios();
 $('#btnBarrio').click(function () {
        InsertarBarrio();
        location.reload();
       $('input[type="text"]').val('');
    });

$('#btnSocio').click(function () {
        CrearSocio();
 $('input[type="text"]').val('');
});
   
});