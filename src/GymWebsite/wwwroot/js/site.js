$(function () {
    var i = 1;
    $('#btnAddImage').click(function () {
        if (i != 3) {
            var template = `<div class="col-sm-4">
                            <fieldset class="myFieldSet">
                                <input type="file" name="Images[${i}].FileName" /><br />
                                <input class="form-control" name="Images[${i}].Order" placeholder="Order" /><br />
                                <input type="checkbox" name="Images[${i}].IsEnabled" /> Is Enabled?
                            </fieldset>
                </div>`;
            i++;
            $('#imageHolder').after(template);
        } else {
            alert("You can only add three items");
        }
    });
});