let playerText = document.getElementById("player-text");
let computerText = document.getElementById("computer-text");
let resultText = document.getElementById("result-text");
let btns = document.querySelectorAll(".choice-btn");
let userScoreElement = document.getElementById("user-score");
let computerScoreElement = document.getElementById("computer-score");
let userScore = 0;
let computerScore = 0;
let roundScore = document.getElementById("round-score");
let container = document.getElementById("container");
let starting = document.getElementById("starting");
let matching = document.getElementById("matching");
let end = document.getElementById("end");
let bestOfOne = document.getElementById("bo1");
let bestOfThree = document.getElementById("bo3");
let bestOfFive = document.getElementById("bo5");
let startButton = document.getElementById("start-button");
let player;
let computer;
let pageStatus = "starting";
let userNameSpan = document.getElementById("username-input");
let userName = document.getElementById("username");

// Making a variable for the icons to have less complicated code
let rockIcon = `<i class="fa-solid fa-hand-back-fist fa-2xl"></i>`;
let paperIcon = `<i class="fa-solid fa-hand fa-2xl"></i>`;
let scissorsIcon = `<i class="fa-solid fa-hand-scissors fa-rotate-90 fa-2xl"></i>`;
let thumbsUp = `<i class="fa-solid fa-thumbs-up fa-2xl"></i>`;
let thumbsDown = `<i class="fa-solid fa-thumbs-down fa-2xl"></i>`;
let handShake = `<i class="fa-solid fa-handshake fa-2xl"></i>`;

// Starting view of the application
let matchOption;
function handleMatchOption(e) {
    matchOption = e.target.value;
}

bestOfOne.addEventListener("click", handleMatchOption);
bestOfThree.addEventListener("click", handleMatchOption);
bestOfFive.addEventListener("click", handleMatchOption);



// Setting round limit
function roundLimit() {
    if (matchOption == "1") {
        if (userScore === 1 || computerScore === 1) {
            pageStatus = "end";
        }
    } else if (matchOption == "3") {
        if (userScore === 2 || computerScore === 2) {
            pageStatus = "end";
        }
    } else if (matchOption == "5") {
        if (userScore === 3 || computerScore === 3) {
            pageStatus = "end";
        }
    }
}

// Start button
function handleStartClick() {
    pageStatus = "matching";
    userNameSpan.textContent = userName.value;
    checkStatus();
}

startButton.addEventListener("click", handleStartClick);

function checkStatus() {
    switch (pageStatus) {
        case "starting":
            matching.style.display = "none";
            end.style.display = "none";
            starting.style.display = "block";
            break;
        case "matching":
            starting.style.display = "none";
            end.style.display = "none";
            matching.style.display = "block";
            break;
        case "end":
            starting.style.display = "none";
            matching.style.display = "none";
            end.style.display = "block";
            break;
    }
}

// Matching view of the application
// Game Run
function handleClickButton(button) {
    playerValue = button.id;
    player = button.innerHTML;
    computerTurn();
    playerText.innerHTML = player;
    computerText.innerHTML = computer;
    resultText.innerHTML = checkWinner();
    roundLimit();
    if (pageStatus == "end") {
        checkStatus();
    }
}

function addClickListener(button) {
    button.addEventListener("click", function () {
        handleClickButton(button);
    });
}

btns.forEach(addClickListener);

// Game Logic
// Random computer choice
function computerTurn() {
    // Generate a random number between 1 to 3
    let randomNumber = Math.floor(Math.random() * 3) + 1;

    switch (randomNumber) {
        case 1:
            computerValue = "rock";
            computer = rockIcon;
            break;
        case 2:
            computerValue = "paper";
            computer = paperIcon;
            break;
        case 3:
            computerValue = "scissors";
            computer = scissorsIcon;
            break;
    }
}

// Compare the user choice and the computer choice
function checkWinner() {
    let matchResult;
    // Adding the logic of the rock-paper-scissors to find the winner
    if (playerValue == computerValue) {
        matchResult = "draw";
    } else if (computerValue == "rock") {
        matchResult = (playerValue == "paper") ? "win" : "lose";
    } else if (computerValue == "paper") {
        matchResult = (playerValue == "scissors") ? "win" : "lose";
    } else if (computerValue == "scissors") {
        matchResult = (playerValue == "rock") ? "win" : "lose";
    }

    switch (matchResult) {
        case "win":
            container.style.boxShadow = "0 0 50px 20px rgb(10, 251, 10)";
            correctScore();
            roundCounter();

            return thumbsUp;
        case "lose":
            container.style.boxShadow = "0 0 50px 20px red";
            incorrectScore();
            roundCounter();

            return thumbsDown;
        case "draw":
            container.style.boxShadow = "0 0 50px 20px rgb(255, 183, 0)";
            // roundCounter();
            return handShake;
    }
}

// Result part
function correctScore() {
    userScore++;
    userScoreElement.innerHTML = userScore;
}

function incorrectScore() {
    computerScore++;
    computerScoreElement.innerHTML = computerScore;
}

function roundCounter() {
    let oldScore = parseInt(roundScore.innerHTML);
    roundScore.innerHTML = ++oldScore;
}

// Ending view of the application


checkStatus();