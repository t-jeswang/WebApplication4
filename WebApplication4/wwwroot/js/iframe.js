var x = document.getElementById("status");
x.addEventListener("load", function () {
    console.log('sent the message!')
    top.postMessage(document.getElementById('status'));
});
