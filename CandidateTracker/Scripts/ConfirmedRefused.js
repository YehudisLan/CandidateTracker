$(() => {
    $(".btn.confirm").on('click', function () {
        const id = $(this).data('candidate-id');
        console.log(id);
        $.post('/home/confirmPerson',{id}, function() {
            $.get('/home/getcounts', function (countobj) {
                $("#pending-layout").text(countobj.Pending);
                $("#confirmed-layout").text(countobj.Confirmed);
                $("#refused-layout").text(countobj.Refused);
            });
            $(".btn.confirm").hide();
            $(".btn.refuse").hide();
        });
    });
    $(".btn.refuse").on('click', function () {
        const id = $(this).data('candidate-id');
        const person = {
            id: id
        };
        console.log(id);
        $.post('/home/refusePerson', person, function () {
            //window.location.reload();
            $(".btn.confirm").hide();
            $(".btn.refuse").hide();
        });
    });
});