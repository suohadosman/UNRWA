let userNameInput = document.getElementById("email");
let passwordInput = document.getElementById("password");
let submitBtn = document.getElementById("submit-btn");
let emailErrorMessage = document.getElementById("email-error-message");
let passwordErrorMessage = document.getElementById("password-error-message");
let faildLoginSpan = document.getElementById("faild-login");
let faildLoginText = document.createTextNode("Invalid UserName Or Password !")
document.forms[0].onsubmit = function (e) {
    let UserNameValid = false;
    let passwordValid = false;

    if (userNameInput.value !== "") {
        UserNameValid = true;
        userNameInput.className = "valid";
        emailErrorMessage.className = "Valid-Message";
      
    }
    else {
        userNameInput.className = "error";
        emailErrorMessage.className = "Error-Message";
    }
    if (passwordInput.value !== "") {
        passwordValid = true;
        passwordInput.className = "valid";
        passwordErrorMessage.className = "Valid-Message"

    }
    else {
        passwordInput.className = "error";
        passwordErrorMessage.className = "Error-Message"
    }
    if (passwordValid === false || UserNameValid === false) {
        e.preventDefault();
    }
    else {
        e.preventDefault();
        $.ajax({
            url: '/Home/Login',
            type: "POST",
            data: {
                UserName: userNameInput.value,
                Password: passwordInput.value
            },
            success: function (result) {
                if (result === false) {

                    faildLoginSpan.className = "faild-login";
                    faildLoginSpan.appendChild(faildLoginText);
                    userNameInput.className = "normal-input";
                    passwordInput.className = "normal-input";
                    emailErrorMessage.className = "normal-validation-message";
                    passwordErrorMessage.className = "normal-validation-message";
                    passwordInput.value = "";
                }
                else {
                    $.ajax({
                        url: '/Home/RedirectTheUser',
                        type: "POST",
                        data: {
                            
                            UserName: userNameInput.value,
                            Password: passwordInput.value
                        },
                        success: function (response) {
                            document.forms[0].innerHTML = ' <div id="loading"> </div > ';

                            window.location.href = response.redirectUrl;

                        }
                    });
                }
            },
            error: function () {
                var x = document.getElementById("snackbar");
                x.className = "error";
                x.innerText = "login failed"
                setTimeout(function () { x.className = x.className.replace("error", ""); }, 3000);
            }
        }
        );
    }
}


