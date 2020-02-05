var DualSelectWrapper = {
    // Moves all options to another list
    addAll:function (isFromAvailable = true, dualListBox){
        if(dualListBox==null || dualListBox==undefined){
            console.error("addAll: No dualListBoxWrapper was specified. dualListBox: ",dualListBox);
            return;
        }
        var selectedItems;
        // Check if movable options are from list "available" 
        if(isFromAvailable==true) {
            selectedItems = dualListBox.getElementsByClassName("available items")[0].options;
            targetItems = dualListBox.getElementsByClassName("selected items")[0].options;
        }
        else {
            selectedItems = dualListBox.getElementsByClassName("selected items")[0].options;
            targetItems = dualListBox.getElementsByClassName("available items")[0].options;
        }
        // Move each option
        for(var optionIndex = 0;optionIndex<selectedItems.length;optionIndex++){
            targetItems.add(selectedItems[optionIndex]);
            optionIndex--;
        };    
    },
    // Moves all selected options to another list
    add:function (isFromAvailable, dualListBox){
        if(dualListBox==null || dualListBox==undefined){
            console.error("addAll: No dualListBoxWrapper was specified. dualListBox: ",dualListBox);
            return;
        }
        // Check if movable options are from list "available" 
        if(isFromAvailable==true) {
            selectedItems = dualListBox.getElementsByClassName("available items")[0].selectedOptions;
            targetItems = dualListBox.getElementsByClassName("selected items")[0].options;
        }
        else {
            selectedItems = dualListBox.getElementsByClassName("selected items")[0].selectedOptions;
            targetItems = dualListBox.getElementsByClassName("available items")[0].options;
        }
        // Move every selected option
        for(var optionIndex = 0;optionIndex<selectedItems.length;optionIndex++){
            targetItems.add(selectedItems[optionIndex]);
            optionIndex--;
        };    
    },
    // Adds event listeners to all buttons
    AddButtonsEventListeners: function(){
        // Find all four type of the buttons
        var addAllButtons = document.getElementsByClassName("addAllButton");
        var removeAllButtons = document.getElementsByClassName("removeAllButton");
        var addButtons = document.getElementsByClassName("addButton");
        var removeButtons = document.getElementsByClassName("removeButton");
        // Add the event listeners to the buttons
        for(var buttonIndex = 0;buttonIndex<addAllButtons.length;buttonIndex++){
            addAllButtons[buttonIndex].addEventListener("click", function(){DualSelectWrapper.addAll(true, this.parentElement.parentElement)},true);
            removeAllButtons[buttonIndex].addEventListener("click", function(){DualSelectWrapper.addAll(false, this.parentElement.parentElement)},true);
            removeButtons[buttonIndex].addEventListener("click", function(){DualSelectWrapper.add(false, this.parentElement.parentElement)},true);
            addButtons[buttonIndex].addEventListener("click", function(){DualSelectWrapper.add(true, this.parentElement.parentElement)},true);
};
    }
};
// Add event listeners to all buttons.
DualSelectWrapper.AddButtonsEventListeners();
