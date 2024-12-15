const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

const chatArea = document.querySelector(".chat");

connection.on("ReceiveMessage", (message) => {

    chatArea.innerHTML += `
     <li class="other">
     <div class="msg">
         <div class="user">${message.sender.userName}</div>
         <p>${message.text}</p>
         <time>${message.createdTime}</time>
     </div>
 </li>
    `
});

connection.start().catch(err => console.error(err));