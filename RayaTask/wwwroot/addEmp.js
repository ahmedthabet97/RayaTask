function handleKeyPressNew(event) {
    if (event.key === "Enter") {
        AddEmployee();
    }
}
function AddEmployee() {

    var emailNew = document.getElementById("EmailNew").value;
    console.log(emailNew);

    var nameNew = document.getElementById("NameNew").value;
    console.log(nameNew);
    var jobNew = document.getElementById("JobNew").value;
    console.log(jobNew);

    var salaryNew = document.getElementById("SalaryNew").value;

    console.log(typeof (salaryNew));

    $.ajax({
        type: 'POST',
        url: '/Employee/Add',
        data: {  Name: nameNew, Salary: salaryNew, Job: jobNew, Email: emailNew},
        success: function () {
            alert("Added Succeeded")
            location.reload();
        }
    });
}