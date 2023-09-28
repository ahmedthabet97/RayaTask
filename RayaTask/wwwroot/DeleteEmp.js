var Id = 0;
function AssignId(id)
{
    console.log("Before" + " " + Id)
    console.log(id)
    Id = id;
    console.log("Afte" + " " + Id)
}
function DeleteEmp()
{
    console.log(Id);
    $.ajax({
        type: 'POST',
        url: '/Employee/Delete',
        data: { Id: Id },
        success: function () {
            alert("Edit Succeeded")
            location.reload();
        }
    });

}