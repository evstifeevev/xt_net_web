(function(){
    // Go to the previous page.
    previousPage = function(){
        if(window.location.href.match(/1.html/)){  
                document.location.href = "3.html";
        } else if(window.location.href.match(/2.html/)){
            document.location.href = "1.html";
        } else {
            document.location.href = "2.html";
        }
    };
    // Add event listener to the previous page button. 
    document.getElementById("previousPageButton").addEventListener('click',previousPage);
}());
