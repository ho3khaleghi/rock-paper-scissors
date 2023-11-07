let playerText = document.getElementById("player-text");
let computerText = document.getElementById("computer-text");
let resultText = document.getElementById("result-text");
let btns = document.querySelectorAll(".choice-btn");
let userScore = document.getElementById("user-score");
let computerScore = document.getElementById("computer-score");
let roundScore = document.getElementById("round-score");
let container = document.getElementById("container");
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
            roundCounter();
            return handShake;
    }
}

// Result part
function correctScore() {
    let oldScore = parseInt(userScore.innerHTML);
    userScore.innerHTML = ++oldScore;
}

function incorrectScore() {
    let oldScore = parseInt(computerScore.innerHTML);
    computerScore.innerHTML = ++oldScore;
}

function roundCounter() {
    let oldScore = parseInt(roundScore.innerHTML);
    roundScore.innerHTML = ++oldScore;
}

startingView = document.createElement("div");
startingView.id = "starting-view";
container.appendChild(startingView);
userName = document.createElement("input");
userName.type = "text";
userName.name = "user-name";
userName.id = "username";
userName.placeholder = "Enter your name...";
startingView.appendChild(userName);
optionButtonContainer = document.createElement("div");
optionButtonContainer.className = "btn-container";
container.appendChild(optionButtonContainer);
bestOfOne = document.createElement("button");
bestOfThree = document.createElement("button");
bestOfFive = document.createElement("button");
bestOfOne.innerHTML = `<i class="fa-solid fa-dice-one"></i>`;
bestOfOne.id = "bo1";
bestOfThree.innerHTML = `<i class="fa-solid fa-dice-three"></i>`;
bestOfThree.id = "bo3";
bestOfFive.innerHTML = `<i class="fa-solid fa-dice-five"></i>`;
bestOfFive.id = "bo5";
optionButtonContainer.appendChild(bestOfOne);
optionButtonContainer.appendChild(bestOfThree);
optionButtonContainer.appendChild(bestOfFive);
rulesContainer = document.createElement("div");
rulesContainer.className = "rules-container"
container.appendChild(rulesContainer);
rulesTitle = document.createElement("h4");
rulesTitle.textContent = "Rules:";
rulesContainer.appendChild(rulesTitle);
rulesList = document.createElement("ul");
rulesContainer.appendChild(rulesList);
rulesItem1 = document.createElement("li");
rulesItem1.textContent = "You have 3 choices (Rock, Paper, Scissors)"
rulesList.appendChild(rulesItem1);
rulesItem2 = document.createElement("li");
rulesItem2.textContent = "You have 3 option (Bo1, Bo3, Bo5). Bo1 is only 1 round match. Bo3 is 3 rounds match if your score reach 2 you are the winner. Bo5 is similar to Bo3 but if your score reach 3 you will be winner.";
rulesList.appendChild(rulesItem2);
rulesItem3 = document.createElement("li");
rulesItem3.textContent = "Just remember 1. Rock beats Scissors. 2. Paper beats Rock. 3. Scissors beats Paper.";
rulesList.appendChild(rulesItem3);
startButton = document.createElement("button");
startButton.className = "glowing-btn";
startButton.innerHTML = `<span class='glowing-txt'>S<span class='faulty-letter'>T</span>ART</span>`
container.appendChild(startButton);

