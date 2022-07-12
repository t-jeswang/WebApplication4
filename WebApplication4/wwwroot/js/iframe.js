var x = document.getElementById("status");

window.addEventListener("load", function () {
    console.log('sent the message!');
    window.parent.postMessage(x.innerText);
});
