const email = document.getElementById('email');

function checkInput() {
    const emailValue = email.value();
    $.ajax({
        if(emailValue === '') {
        setErrorFor(email, 'please input email');
    });
}
function setErrorFor(input, message) {
    const big = input.parentElement;
    const small = big.querySelector('small');

    small.innerText = message;
    small.className = 'small';
}