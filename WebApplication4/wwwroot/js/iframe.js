var x = document.getElementById("status");
console.log(x.innerText);
x.addEventListener("load", function () {
    console.log('sent the message!');
    top.postMessage(document.getElementById('status').innerText);
});
