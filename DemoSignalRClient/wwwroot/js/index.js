const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:44398/notification-hub")
    .configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect([0, 2000, 10000, 30000])
    .build();

connection.onreconnecting(error => {
    console.assert(connection.state === signalR.HubConnectionState.Reconnecting);    
});

connection.onreconnected(connectionId => {
    console.assert(connection.state === signalR.HubConnectionState.Connected);
});

connection.onclose(error => {
    console.assert(connection.state === signalR.HubConnectionState.Disconnected);
});

async function start() {
    try {
        await connection.start();
        console.assert(connection.state === signalR.HubConnectionState.Connected);
        console.log("SignalR Connected.");
        try {
            await connection.invoke("Register", "tanapat");
        } catch (err) {
            console.error(err);
        }
    } catch (err) {
        console.assert(connection.state === signalR.HubConnectionState.Disconnected);
        console.log(err);
        setTimeout(() => start(), 5000);
    }
};

connection.on("notificationCreated", () => {
    console.log("notification has created");
});

// Start the connection.
start();