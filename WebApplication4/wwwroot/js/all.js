document.getElementById("clientKey").style.display = "none";
document.getElementById("type").style.display = "none";

var x = document.getElementsById("status");
x.addEventListener("beforeprint", function () {
    top.postMessage(document.getElementById('status'));
});

