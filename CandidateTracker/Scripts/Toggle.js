$(() => {

    console.log("hello");
    $(".btn.toggle-notes").on('click', function () {
        //$('td:nth-child(5),th:nth-child(5)').toggle
        $(".notes-toggle").toggle();
    });
   
});