﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    getDatatable('#table-pacientes');
    getDatatable('#table-profissionaisPacientes');
    $("#Telefone").mask("(00) 00000-0000");
   
})

function enviarWhatsApp(nomeProfissional, nomePaciente, telefone, id) {
    var agendamento = document.querySelector('[data-agendamento="'+id+'"]').value;
    //console.log(nomeProfissional);
    //console.log(nomePaciente);
    //console.log(telefone);
    //console.log(agendamento);
    var dataAgendamento = new Date(agendamento);
    agendamento = dataAgendamento.toLocaleDateString('pt-BR') + " " + dataAgendamento.toLocaleTimeString('pt-BR');



    //var mensagem = "?text=Olá+" + nomePaciente + ",+surgiu+um+horário+para+antecipar+sua+consulta+com+o+médico+" + nomeProfissional +"+na+data+"+agendamento+".+Caso+tenha+interesse,+responda+esse+WhatsApp!";
    //var mensagem = "?text=Olá+" + nomePaciente + ",+você+tem+uma+consulta+no+GASTROCENTRO+agendada+com+o+médico: " + nomeProfissional + ", +na+data:+" +agendamento+". +Para+Confirmar,+responda+esse+WhatsApp!";
    var mensagem = "?text=Olá+" + nomePaciente + ", você tem uma consulta no GASTROCENTRO agendada com o médico: " + nomeProfissional + ", na data: " +agendamento+".  Para confirmar, responda esse WhatsApp!";
    var urlWhatsApp = "https://wa.me/55" + telefone + mensagem;

    window.open(urlWhatsApp, "_blank");
}

function getDatatable(id) {
    $(id).DataTable({
        //"columnDefs": [
        //    { "type": "date", "targets": 2 }
        //],
        "order": [[3, 'desc'], [2, 'asc']],
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ at&eacute; _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 at&eacute; 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}

$(".alert").ready(function () {
    $(".alert").fadeIn(300).delay(4000).fadeOut(400);
});