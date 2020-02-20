(function () {
    var helpButton = document.getElementById("helpButton");
    var helpMessageBox = document.getElementById("helpMessageBox");
    var username = document.getElementById("username").innerText.trim();
    var role = document.getElementById("roleWrapper").innerText.trim();
    var isShown = false;
    var ShowHelpMessage = function () {
        if (!isShown) {
            var commandsDescription = "";
            if (role == 'guest') {
                commandsDescription = "Since you are not authenticated user you can only use 'get' option to get the list of users without their awards."
            }
            else if (role == "user") {
                commandsDescription = "Since you are an authentificated user you can only use 'get' option to get the list of users with their awards."
            } 
            else if (role == "admin") {
                commandsDescription = "Since you are an admin you can use all available options. Use 'Get' to get the list of users, awards and website users.\r\n " +
                    "Use 'Edit' to change user's or award's properties.\r\n " +
                    "Use 'Add' to add new user or new award to the file, add users to award or add awards to user.\r\n " +
                    "Use 'Remove' to remove award or user by specified id, remove users from award or awards from user.\r\n " +
                    "Use 'Change admin role' to change administrative role of saved website user.\r\n ";
            }

            helpMessageBox.innerText = helpMessageBox.innerText.concat('Dear ', username,', thank you for using the help button! \r\n', commandsDescription) ;
            isShown = true;
            helpButton.innerText = "Hide";
        }
        else {
            helpMessageBox.innerText = "";
            isShown = false;
            helpButton.innerText = "Help";
        }
       
    };
    helpButton.addEventListener("click", ShowHelpMessage)
}())