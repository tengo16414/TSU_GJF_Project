
    var startTimeInt = 240;
        var currentTimeInt = startTimeInt;
        var interval = undefined;

        function startCounter() {
            if (!interval) {
                if (currentTimeInt <= 0) {
                    var minutes = Math.floor(-1 * currentTimeInt / 60);
                    var seconds = -1 * currentTimeInt - minutes * 60;
                    if (seconds < 10) {
        seconds = "0" + seconds;
    }
                    document.getElementById("timer").textContent = minutes + ":" + seconds;
                    document.getElementById("checkTime").textContent = currentTimeInt;
                }
                if (currentTimeInt > 0) {
                    var minutes = Math.floor(currentTimeInt / 60);
                    var seconds = currentTimeInt - minutes * 60;
                    if (seconds < 10) {
        seconds = "0" + seconds;
    }
                    document.getElementById("timer").textContent = minutes + ":" + seconds;
                    document.getElementById("checkTime").textContent = currentTimeInt;
                }

                interval = setInterval(newNumber, 1000)
            }
        }

        function stopCounter() {
        clearInterval(interval)
            interval = undefined;
        }

        function resetCounter() {
            var r = confirm("დავარესტარტო მიმდინარე დრო?");
            if (r == true) {
        currentTimeInt = startTimeInt;
    var minutes = Math.floor(currentTimeInt / 60);
                var seconds = currentTimeInt - minutes * 60;
                if (seconds < 10) {
        seconds = "0" + seconds;
    }
                document.getElementById("timer").textContent = minutes + ":" + seconds;
                document.getElementById("checkTime").textContent = currentTimeInt;
                stopCounter()
            }

        }

        function newNumber() {
        currentTimeInt--;
    if (currentTimeInt <= 0) {
                var minutes = Math.floor(-1 * currentTimeInt / 60);
                var seconds = -1 * currentTimeInt - minutes * 60;
                if (seconds < 10) {
        seconds = "0" + seconds;
    }
                document.getElementById("timer").textContent = minutes + ":" + seconds;
                document.getElementById("checkTime").textContent = currentTimeInt;
            }
            if (currentTimeInt > 0) {
                var minutes = Math.floor(currentTimeInt / 60);
                var seconds = currentTimeInt - minutes * 60;
                if (seconds < 10) {
        seconds = "0" + seconds;
    }
                document.getElementById("timer").textContent = minutes + ":" + seconds;
                document.getElementById("checkTime").textContent = currentTimeInt;
            }

        }

