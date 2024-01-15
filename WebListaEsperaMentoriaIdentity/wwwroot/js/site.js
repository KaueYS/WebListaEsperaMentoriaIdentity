// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(".alert").ready(function () {
    $(".alert").fadeIn(300).delay(4000).fadeOut(400);
});




//$(function () {
//    var PlaceHolderElement = $('#PlaceHolderHere')
//    $('button[data-bs-toggle="modal"]').click(function (event){
//        var url = $(this).data('url');
//        var decodedUrl = decodeURIComponent(url);
//        $.get(decodedUrl).done(function (data){

//            PlaceHolderElement.html(data);
//            PlaceHolderElement.find('.modal').modal('show');
//        })
//    })

//    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
//        var form = $(this).parents('.modal').find('form');
//        var actionUrl = form.attr('action');
//        var sendData = form.serialize();
//        $.post(actionUrl, sendData).done(function (data) {
//            PlaceHolderElement.find('.modal').modal('hide');
//        })
//    })
//})