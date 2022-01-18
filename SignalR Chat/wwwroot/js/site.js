"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

////Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);
//    // We can assign user-supplied strings to an element's textContent because it
//    // is not interpreted as markup. If you're assigning in any other way, you 
//    // should be aware of possible script injection concerns.
//    li.textContent = `${user} says ${message}`;
//});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});





/* Messenger */
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceivePrivateMessage", function (senderid, message) {
    //<div class="reciever">Qazax ipsum aleykum salam</div >'
    var recieverid = document.getElementById("recieverid").value;
    if (recieverid == senderid) {
        var div = document.createElement("div");
        div.classList.add("reciever");
        div.textContent = message;
        document.getElementsByClassName("messageBox")[0].appendChild(div);
    }
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendMessage").addEventListener("click", function (event) {
    var recieverid = document.getElementById("recieverid").value;
    var senderid = document.getElementById("senderid").value;
    var message = document.getElementById("message").value;
    connection.invoke("SendPrivateMessage", recieverid, senderid, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();

    var div = document.createElement("div");
    div.classList.add("sender");
    div.textContent = message;
    document.getElementsByClassName("messageBox")[0].appendChild(div);

    document.getElementById("message").value = "";
});