jQuery(document).ready(function($) {
    $(window).resize(function() {
        var height = $(window).height();
        var navbar1 = $('.navbar').height();
        var subnavbar = ($('.subnavbar').height() == undefined) ? 0:$('.subnavbar').height()+36;
        var footer = $('.footer').height();
        var clsForm = ($('.clsForm .container').height() == undefined) ? $('.clsForm').height() : $('.clsForm .container').height();
        var tH = height - navbar1 - footer - subnavbar;
        if(clsForm < tH){
            $('.clsForm').height(tH);
        }
        $('.clsForm').css('min-height', 300);
    }).resize();
});