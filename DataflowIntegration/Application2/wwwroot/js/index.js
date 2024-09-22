var connection = new signalR.HubConnectionBuilder().withUrl("/syncHub").build();

connection.on("ReceiveMessage", function (message) {
    $('#outputText').text(message);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

function sendText() {
    var text = $('#inputText').val();
    $.ajax({
        url: '/api/application2',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ text: text }),
        success: function () {
            $('#outputText').text(text);
        }
    });
}