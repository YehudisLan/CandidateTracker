$(() => {
    $(".btn.confirm").on('click', function () {
        const id = $(this).data('candidate-id');
        console.log(id);
        $.post('/home/confirmPerson',{ id }, function () {
            getCounts();
            $("#status").text('confirmed');
            });
             
    });
    $(".btn.refuse").on('click', function () {
        const id = $(this).data('candidate-id');
        const person = {
            id: id
        };

        $.post('/home/refusePerson', person, function () {
            getCounts();
            $("#status").text('refused');
            
        });
        console.log("hello");
    });
    function getCounts() {
        $.get('/home/getcounts', function (countobj) {
            $("#pending-layout").text(countobj.Pending);
            $("#confirmed-layout").text(countobj.Confirmed);
            $("#refused-layout").text(countobj.Refused);
            $(".btn").hide();
            
        });
    };
});