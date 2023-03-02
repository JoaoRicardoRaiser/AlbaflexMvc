// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

setTimeout(function () {
    $('.alert').hide('hide')
}, 5000)

$('.close-alert').click(function () {
    $('.alert').hide('hide');
})


$(document).ready(function () {
    $('#products-table').DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
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
});

$(document).ready(function () {
    $('.measurement').mask('0,00');
});


$(document).ready(function () {
    let largura = document.getElementById('budget-width')
    let altura = document.getElementById('budget-height')

    largura.addEventListener('focusout', function () {
        let tamanhoAltura = altura.value.length
        let tamanhoLargura = largura.value.length
        if (tamanhoAltura === 4 & tamanhoLargura === 4) {
            document.getElementById("blind-price").value = "100"
        } else {
            document.getElementById("blind-price").value = ""
        }
    })
})

$(document).ready(function () {
    let largura = document.getElementById('budget-width')
    let altura = document.getElementById('budget-height')

    altura.addEventListener('focusout', function () {
        let tamanhoAltura = altura.value.length
        let tamanhoLargura = largura.value.length
        if (tamanhoAltura === 4 & tamanhoLargura === 4) {
            document.getElementById("blind-price").value = "100"
        }
        else {
            document.getElementById("blind-price").value = ""
        }
    })
})