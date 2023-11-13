var connection = new signalR.HubConnectionBuilder().withUrl("/task-hub").build();

console.log(connection);
connection.on("RecieveMessage", function (message) {
    var msg = message;
    let permission = Notification.permission;

    if (permission === "granted") {
        showNotification(msg);
    } else if (permission === "default") {
        requestAndShowPermission();
    } else {
        alert("Use normal alert");
    }
});

function requestAndShowPermission() {
    Notification.requestPermission(function (permission) {
        if (permission === "granted") {
            showNotification(msg);
        }
    });
}

function showNotification(msg) {
    // Your notification logic here
    let title = msg;
    let icon = 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fcommons.wikimedia.org%2Fwiki%2FFile%3ASign-check-icon.png&psig=AOvVaw1z5loMsnRPQg_ynpVGYsFC&ust=1699909927112000&source=images&cd=vfe&ved=0CBIQjRxqFwoTCMDrsoywv4IDFQAAAAAdAAAAABAE';
    let body = "has changed";
    var notification = new Notification(title, { body, icon });
    // notification.onclick = () => {
    //     notification.close();
    //     window.parent.focus();
    // }
}

connection.start();

$('.UpdateBut').on("click", function () {
    var taskId = $(this).data('task-id');
    connection.invoke("SendMessage", `Task ${taskId}`);
});
