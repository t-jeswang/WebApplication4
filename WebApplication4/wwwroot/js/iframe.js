var x = document.getElementsById("status");
x.addEventListener("beforeprint", function () {
    top.postMessage(document.getElementById('status'));
});
