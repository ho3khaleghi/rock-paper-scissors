let playerText = document.getElementById("player-text");
let computerText = document.getElementById("computer-text");
let resultText = document.getElementById("result-text");
let btns = document.querySelectorAll(".choice-btn");
let player;
let computer;

// Making a variable for the icons to have less complicated code
let rockIcon = `<i class="fa-solid fa-hand-back-fist fa-2xl"></i>`;
let paperIcon = `<i class="fa-solid fa-hand fa-2xl"></i>`;
let scissorsIcon = `<i class="fa-solid fa-hand-scissors fa-rotate-90 fa-2xl"></i>`;
let thumbsUp = `<i class="fa-solid fa-thumbs-up fa-2xl"></i>`;
let thumbsDown = `<i class="fa-solid fa-thumbs-down fa-2xl"></i>`;
let handShake = `<i class="fa-solid fa-handshake fa-2xl"></i>`;

// Game Run
function handleClickButton(button) {
    playerValue = button.id;
    player = button.innerHTML;
    computerTurn();
    playerText.innerHTML = player;
    computerText.innerHTML = computer;
    resultText.innerHTML = checkWinner();
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
        matchResult = (player == "rock") ? "win" : "lose";
    }

    switch (matchResult) {
        case "win":
            return thumbsUp;
        case "lose":
            return thumbsDown;
        case "draw":
            return handShake;

    }
}

// Result part
function correctScore() {

}

function incorrectScore() {

}

function roundCounter() {

}