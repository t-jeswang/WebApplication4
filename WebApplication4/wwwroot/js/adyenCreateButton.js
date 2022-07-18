const clientKey = document.getElementById("clientKey").innerHTML;



// Typical checkout experience
async function startCheckout() {
    // Used in the demo to know which type of checkout was chosen
    try {
        const amount = {
            "currency": "USD",
            "value":1000
        }
        
        const checkoutSessionResponse = {
            "amount": amount,
            "channel": document.getElementById("channel").innerHTML,
            "countryCode": document.getElementById("countryCode").innerHTML,
            "expiresAt": document.getElementById("expiresAt").innerHTML,
            "id": document.getElementById("id").innerHTML,
            "merchantAccount": document.getElementById("merchantAccount").innerHTML,
            "reference": document.getElementById("reference").innerHTML,
            "returnUrl": document.getElementById("returnUrl").innerHTML,
            "sessionData": document.getElementById("sessionData").innerHTML,
        }
        //const checkoutSessionResponse = { "id": document.getElementById("id").innerHTML };
        const checkout1 = await createAdyenCheckout(checkoutSessionResponse);
        const config = {

            configuration: { gatewayMerchantId: "Microsoft519_000001_TEST" },
        }
        const googlePayComponent = checkout1.create("googlepay", config);

        googlePayComponent
            .isAvailable()
            .then(() => {
                googlePayComponent.mount(document.getElementById("payment1"));
            });

        const checkout2 = await createAdyenCheckout(checkoutSessionResponse);
        const applePayComponent = checkout2.create("applepay");
        applePayComponent
            .isAvailable()
            .then(() => {
                applePayComponent.mount(document.getElementById("payment2"));
            });


    } catch (error) {
        console.error(error);
        alert("Error occurred. Look at console for details");
    }
}

// Some payment methods use redirects. This is where we finalize the operation
async function finalizeCheckout() {
  try {

      const checkout = await createAdyenCheckout({ id: sessionId });

    checkout.submitDetails({details: {redirectResult}});
  } catch (error) {
    console.error(error);
    alert("Error occurred. Look at console for details");
  }
}

async function createAdyenCheckout(session){
    return new AdyenCheckout(
        {
            clientKey,
            environment: "test",
            session: session,
            showPayButton: true,
            amount: session.amount,
       
      onPaymentCompleted: (result, component) => {
        console.info("onPaymentCompleted");
        console.info(result, component);
        handleServerResponse(result, component);
            },
        onError: (error, component) => {
                console.error(error.name, error.message, error.stack, component);
            },
    }
  );
}

function handleServerResponse(res, _component) {
    switch (res.resultCode) {
        case "Authorised":
            window.location.href = "/Home/result/success";
            break;
        case "Pending":
        case "Received":
            window.location.href = "/Home/result/pending";
            break;
        case "Refused":
            window.location.href = "/Home/result/failed";
            break;
        default:
            window.location.href = "/Home/result/error";
            break;
    }
}

{ startCheckout() } 