function Validation() {
    debugger;
    var Owner_Email = document.getElementById('txtOwnerEmail');
    var Name = document.getElementById('txtName');
    var Age = document.getElementById('txtAge');
    var Gender = document.getElementsByName('Gender');
    var PhoneNo = document.getElementById('txtPhone');
    var Pan_Number = document.getElementById('Image');
    var Aadhar_Number = document.getElementById('Image1');
    var Password = document.getElementById('txtPwd');
    var Address = document.getElementById('currentaddress');
    var PerAddress = document.getElementById('permanentaddress');
    var Owner_Image = document.getElementById('Image2');


    //Current_Address,Permanent_Address

    var passwordExpression = '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{8,12})';
    var EmailExpression = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    var phoneno = /^\d{10}$/;
    var AdharNo = /^\d{4}\s\d{4}\s\d{4}$/;
    var PanNumber = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;

    if (Owner_Email.value == '') {
        alert("Please Enter Email Id");
        return false;
    }
    else if (!Owner_Email.value.match(EmailExpression)) {
        alert("Please enter Valid Mail id");
        return false;
    }
    if (Name.value == '') {
        alert("Please Enter Name");
        return false;
    }
    else if (!isNaN(Name.value)) {
        alert("Please Enter Text Only");
        return false;
    }
    if (Age.value == '') {
        alert("Please Enter Age");
        return false;
    }
    else if (isNaN(Age.value)) {
        alert("only Numbers");
        return false;
    }
    else if (Age.value < 23) {
        alert("You must be over 24 to register");
        return false
    }
    var count = 0;
    for (var i = 0; i < Gender.length; i++) {
        if (Gender[i].checked) {
            count++;
        }
    }
    if (count == 0) {
        alert("Please Select Gender");
        return false;
    }
    if (PhoneNo.value == '') {
        alert("Please Enter Phone Number");
        return false;
    }
    else if (!PhoneNo.value.match(phoneno)) {
        alert("Please Enter 10 Numbers");
        return false;

    }
    //if (Pan_Number.value == '') {
    //    alert("Please Enter Pan Number");
    //    return false;
    //}
    //else if (!Pan_Number.value.match(PanNumber)) {
    //    alert("Please Enter Valid Pan Car Number");
    //    return false;
    //}
    //if (Aadhar_Number.value == '') {
    //    alert("Please Enter Aadhar Number");
    //    return false;
    //}
    //else if (!Aadhar_Number.value.match(AdharNo)) {
    //    alert("Please Enter 12 to 16 Numbers");
    //    return false;
    //}
    if (Password.value == '') {
        alert("Please Enter Password");
        return false;
    }
    else if (!Password.value.match(passwordExpression)) {
        alert("Please enter 8 to 15 characters only");
        return false;
    }
    if (Address.value == '') {
        alert("Please Enter Address");
        return false;
    }
    if (PerAddress.value == '') {
        alert("Please Enter permenent Address");
        return false;
    }
    
    return true;
}
function show_image(id) {
    if (id == 'Image1') {
        $("#Image").hide();
        $("#Image2").show();
    }
    else if (id == 'Image') {
        $("#Image").show();
        $("#Image1").hide();
    }
    return true;
} 
$(document).ready(function () {
    $("#Register").click(function () {
        Validation();
        show_image(id)
    });
});