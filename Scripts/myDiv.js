window.onload = function () {
    var Speed = 1;
    var timer;
    var myDiv = document.getElementById("myDiv");
    var pic2 = document.getElementById("pic2");
    pic2.innerHTML = document.getElementById("pic1").innerHTML;

    function picMarquee() {
        if (pic2.offsetWidth - myDiv.scrollLeft <= 0) {
            myDiv.scrollLeft = 0;
        } else {
            myDiv.scrollLeft++;
        }
    }
    timer = setInterval(picMarquee, Speed);
    myDiv.onmouseover = function () {
        clearInterval(timer);
    }
    myDiv.onmouseout = function () {
        timer = setInterval(picMarquee, Speed);
    }
};