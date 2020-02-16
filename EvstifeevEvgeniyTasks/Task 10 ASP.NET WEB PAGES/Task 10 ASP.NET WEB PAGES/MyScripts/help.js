(function () {
    var helpButton = document.getElementById("helpButton");
    var helpMessageBox = document.getElementById("helpMessageBox");
    var isShown = false;
    var ShowHelpMessage = function () {
        if (!isShown) {
            helpMessageBox.innerText = "The list of available commands:\n add[user | award][properties of(user | award)]- " +
                "adds user or award with specified properties.\n addawards [user's id] [list of awards ids] - adds awards to" +
                "the user.\n addusers [award's id] [list of users ids] - adds users to the award.\n" +
                "getall [user|award] - displays all users or awards. Entering just getall displays all entities.\n" +
                "help - displays this list of the available commands.\n" +
                "remove [user|award] [id of (user|award)] - removes user or award with specified id.\n" +
                "removeusers [award's id] [list of users ids] - removes users from the award.\n" +
                "removeawards [user's id] [list of awards ids] - removes awards from the user.\n";
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