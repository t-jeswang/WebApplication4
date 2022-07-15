var stripe = Stripe('pk_test_51L9EjNKzkvbUaEshwHDn7y5fa1e6NhiRwVbGWrLTSDcYMWaZH6FWGMBb3DkP06Hd7zK7cUCn7TwNow1dJ2X9Q59h00m85XPJHF', {
    apiVersion: "2020-08-27",
});
var paymentRequest = stripe.paymentRequest({
    country: 'US',
    currency: 'usd',
    total: {
        label: 'Demo total',
        amount: 1099,
    },
    requestPayerName: true,
    requestPayerEmail: true,
});

var elements = stripe.elements();
var prButton = elements.create('paymentRequestButton', {
    paymentRequest: paymentRequest,
});

console.log('here');
// Check the availability of the Payment Request API first.
paymentRequest.canMakePayment().then(function (result) {
    if (result) {
        prButton.mount('#payment-request-button');
    } else {
        document.getElementById('payment-request-button').style.display = 'none';
    }
});