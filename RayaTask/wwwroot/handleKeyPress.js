    function handleKeyPress(event, id,count) {
        if (event.key === "Enter") {
            console.log(count)
            updateEmployee(id,count);
        }
    }

function updateEmployee(id,count) {
    console.log(count)
    var id = $('input[name="ID"]')[count].value;
    var email = $('input[name="Email"]')[count+1].value;
    console.log(email);
    var name = $('input[name="Name"]')[count+1].value;
        console.log(name);
    var job = $('input[name="Job"]')[count].value;
        console.log(job);

    var isApproved = $('select[name="IsApproved"]').value;//$('input[name="IsApproved"]')[count].value;
    console.log(isApproved);
    console.log("here")
    console.log(count)
    console.log(id)
       // isApproved.addEventListener("change")
    var salary = $('input[name="Salary"]')[count + 1].value;

        console.log(typeof (salary));

        console.log(salary);
    $.ajax({
        type: 'POST',
        url: '/Employee/Edit',
        data: { Id: id, Name: name, Salary: salary, Job: job, Email: email,IsApproved:isApproved},
        success: function () {
            alert("Edit Succeeded")
        location.reload();
            }
        });
    }
