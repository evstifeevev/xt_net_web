(function(){
    // Timer display.
    var state = 3;
    // Timer's working flag.
    var isWorking = true;
    var pauseButton = document.getElementById("pauseButton");
    // Page flip
    var pageFlip = function(){
        // Display timer's state.
        document.getElementById("timer").innerText = state;
        if(state<=0){
            // Go to the next page.
            if(window.location.href.match(/1.html/)){
                document.location.href = "2.html";
            } else if(window.location.href.match(/2.html/)){
                document.location.href = "3.html";
            }
        }
        state--;
    };
    // Initialize the timer.
    var timerId = setInterval(pageFlip, 1000);
    // Timer's state management.
    var pause = function(){
        if(isWorking){
        clearTimeout(timerId);
        pauseButton.innerText="Continue";
        isWorking=false;
        }
        else {
            timerId = setInterval(pageFlip, 1000);
            pauseButton.innerText="Pause";
            isWorking=true;
        }
    };
    // Add event listener to the pause button. 
    pauseButton.addEventListener('click',pause);
}());


