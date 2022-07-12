var x = document.getElementById("status");

window.addEventListener("load", function () {
    console.log('sent the message!');
    window.postMessage(x.innerText);
});
