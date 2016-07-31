$(function () {

    $('.carousel').carousel();
    var i = 1;
    $('#btnAddImage').click(function () {
        if (i != 3) {
            var template = `<div class="col-sm-4">
                            <fieldset class="myFieldSet">
                                <input type="file" name="Images[${i}].FileName" /><br />
                                <input class="form-control" type="number" name="Images[${i}].Order" placeholder="Order" /><br />
                                <input type="checkbox" name="Images[${i}].IsEnabled" /> Is Enabled?
                                <input type="checkbox" name="Images[${i}].IsCoverPhoto" /> Cover photo?
                            </fieldset>
                </div>`;
            i++;
            $('#imageHolder').append(template);
        } else {
            alert("You can only add three items");
        }
    });

    $('.btnDeleteImg').click(function (event) {
        event.preventDefault()
        var name = $(this).data('image');
        console.log(name);
        $.ajax({
            type: 'POST',
            url: '/api/deleteImage/' + name,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                alert('image deleted!');
            }
        });
    });
});