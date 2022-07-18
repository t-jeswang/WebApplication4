const clientKey = document.getElementById("clientKey").innerHTML;

// Used to finalize a checkout call in case of redirect
const urlParams = new URLSearchParams(window.location.search);
const sessionId = urlParams.get('sessionId'); // Unique identifier for the payment session
const redirectResult = urlParams.get('redirectResult');

// Typical checkout experience
async function startSession() {
    // Used in the demo to know which type of checkout was chosen

    try {
        const checkoutSessionResponse = await callServer("/api/sessions");
        console.log('session complete');
        console.log(checkoutSessionResponse);
        //var url = '/'+ checkoutSessionResponse['id'] + '?channel=' + checkoutSessionResponse['channel'] + '&countryCode=' + checkoutSessionResponse['countryCode'];
        //url = url + "&expiresAt=" + checkoutSessionResponse['expiresAt'] + '&merchantAccount=' + checkoutSessionResponse['merchantAccount'] + '&reference=' + checkoutSessionResponse['reference'];
        //url = url + "&sessionData=" + checkoutSessionResponse['sessionData'] + '&returnUrl=' + checkoutSessionResponse['returnUrl'] ;
        var url = '/' + checkoutSessionResponse['id'] + '?sessionData=' + checkoutSessionResponse['sessionData'];
        var currentURL = window.location.href;
        window.location.href = currentURL + url;
    } catch (error) {
        console.error(error);
        alert("Error occurred. Look at console for details");
    }
}



// Calls your server endpoints
async function callServer(url, data) {
  const res = await fetch(url, {
    method: "POST",
    body: data ? JSON.stringify(data) : "",
    headers: {
      "Content-Type": "application/json",
    },
  });

  return await res.json();
}
