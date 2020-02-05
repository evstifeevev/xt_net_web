(function(){
    // Show dialogue window about going to the first page. 
    confirmBox = function(){
        if (confirm("Continue scrolling?")){
            document.location.href = "1.html";
        } 
        else {
            alert("This page's been closed.");
            window.close();
        }
    };
    // Small delay to let the page display.
    setTimeout(confirmBox,700);
}());
