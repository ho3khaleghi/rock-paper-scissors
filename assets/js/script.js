let playerText = document.getElementById("player-text");
let computerText = document.getElementById("computer-text");
let resultText = document.getElementById("result-text");
let btns = document.querySelectorAll(".choice-btn");
let player;
let computer;

let rockIcon = `<i class="fa-solid fa-hand-back-fist fa-2xl"></i>`;
let paperIcon = `<i class="fa-solid fa-hand fa-2xl"></i>`;
let scissorsIcon = `<i class="fa-solid fa-hand-scissors fa-rotate-90 fa-2xl"></i>`;

// Game Run
function handleClickButton(button) {
    player = button.innerHTML;
    ComputerTurn();
    playerText.innerHTML = player;
    computerText.innerHTML = computer;
}

function addClickListener(button) {
    button.addEventListener("click", function() {
        handleClickButton(button);
    })
}

btns.forEach(addClickListener);

// Game Logic
// Random computer choice
function ComputerTurn() {
    // Generate a random number between 1 to 3
    let randomNumber = Math.floor(Math.random() * 3) + 1;

    switch (randomNumber) {
        case 1:
            computer = rockIcon;
            break;
        case 2:
            computer = paperIcon;
            break;
        case 3:
            computer = scissorsIcon;
            break;
    }
}

// Compare the user choice and the computer choice
function checkWinner() {

}

// Result part
function correctScore() {

}

function incorrectScore() {

}

function roundCounter() {

}