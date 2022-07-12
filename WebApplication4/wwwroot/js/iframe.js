var x = document.getElementById("status");
x.addEventListener("beforeprint", function () {
    top.postMessage(document.getElementById('status'));
});
