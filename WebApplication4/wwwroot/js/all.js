document.getElementById("clientKey").style.display = "none";
document.getElementById("type").style.display = "none";

var x = document.getElementsByClassName("status-container");
x.querySelector("status").addEventListener("beforeprint", function () {
    top.postMessage(document.getElementById('status'));
});

