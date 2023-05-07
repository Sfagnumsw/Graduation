
$('.complete-button').click(function() {
    var Id = $('.active-row').find("td").eq(0).html();
    $.ajax({
        url: "/Task/Complete",
        type: "POST",
        data:  {TaskId: Id} ,
        success: function(data) {
            $('.active-row').css('visibility', 'collapse');
        },
    });
});