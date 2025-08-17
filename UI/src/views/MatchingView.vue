<script setup lang="ts">
import { useGameStore } from '../store/gameStore';
import { useRouter } from 'vue-router';

const store = useGameStore();
const router = useRouter();

// Icon definitions for choices and results:
const rockIcon = `<i class="fa-solid fa-hand-back-fist fa-2xl"></i>`;
const paperIcon = `<i class="fa-solid fa-hand fa-2xl"></i>`;
const scissorsIcon = `<i class="fa-solid fa-hand-scissors fa-rotate-90 fa-2xl"></i>`;
const thumbsUp = `<i class="fa-solid fa-thumbs-up fa-2xl"></i>`;
const thumbsDown = `<i class="fa-solid fa-thumbs-down fa-2xl"></i>`;
const handShake = `<i class="fa-solid fa-handshake fa-2xl"></i>`;

const computerTurn = (): string => {
  const randomNumber = Math.floor(Math.random() * 3) + 1;
  let compChoice = '';
  if (randomNumber === 1) {
    compChoice = 'rock';
    store.computerDisplay = rockIcon;
  } else if (randomNumber === 2) {
    compChoice = 'paper';
    store.computerDisplay = paperIcon;
  } else {
    compChoice = 'scissors';
    store.computerDisplay = scissorsIcon;
  }
  return compChoice;
};

const checkWinner = (playerChoice: string, computerChoice: string): string => {
  if (playerChoice === computerChoice) return 'draw';
  if (computerChoice === 'rock') {
    return playerChoice === 'paper' ? 'win' : 'lose';
  } else if (computerChoice === 'paper') {
    return playerChoice === 'scissors' ? 'win' : 'lose';
  } else if (computerChoice === 'scissors') {
    return playerChoice === 'rock' ? 'win' : 'lose';
  }
  return 'draw';
};

const makeChoice = (choice: string): void => {
  if (choice === 'rock') {
    store.playerDisplay = rockIcon;
  } else if (choice === 'paper') {
    store.playerDisplay = paperIcon;
  } else if (choice === 'scissors') {
    store.playerDisplay = scissorsIcon;
  }
  const compChoice = computerTurn();
  const outcome = checkWinner(choice, compChoice);
  if (outcome === 'win') {
    store.resultDisplay = thumbsUp;
    store.userScore++;
  } else if (outcome === 'lose') {
    store.resultDisplay = thumbsDown;
    store.computerScore++;
  } else {
    store.resultDisplay = handShake;
  }
  store.roundCount++;
  checkRoundLimit();
};

const checkRoundLimit = (): void => {
  let winCondition = 0;
  if (store.matchOption === 1) winCondition = 1;
  else if (store.matchOption === 3) winCondition = 2;
  else if (store.matchOption === 5) winCondition = 3;

  if (store.userScore === winCondition || store.computerScore === winCondition) {
    store.matchResult = (store.userScore > store.computerScore) ? "victory" : "defeat";
    setTimeout(() => {
      router.push('/end');
    }, 1500);
  }
};
</script>

<template>
  <div id="matching">
    <div id="topic">
      <span id="topic-text" v-html="store.topicText"></span>
    </div>
    <div class="text-container" id="text-container">
      <p class="game-text">
        <span id="username-input" class="label">{{ store.gameUsername }}:</span>
        <span v-html="store.playerDisplay"></span>
      </p>
      <div class="hr"></div>
      <p class="game-text">
        <span class="label">Computer:</span>
        <span v-html="store.computerDisplay"></span>
      </p>
      <div class="hr"></div>
      <p class="game-text">
        <span class="label">Result:</span>
        <span v-html="store.resultDisplay"></span>
      </p>
      <div class="hr"></div>
    </div>
    <div class="btn-container" id="btn-container">
      <button class="choice-btn" @click="makeChoice('rock')">
        <i class="fa-solid fa-hand-back-fist fa-2xl"></i>
      </button>
      <button class="choice-btn" @click="makeChoice('paper')">
        <i class="fa-solid fa-hand fa-2xl"></i>
      </button>
      <button class="choice-btn" @click="makeChoice('scissors')">
        <i class="fa-solid fa-hand-scissors fa-rotate-90 fa-2xl"></i>
      </button>
    </div>
    <div class="result-container" id="result-container">
      <p class="game-result">
        <i class="fa-solid fa-circle-check correct"></i> Your Score:
        <span>{{ store.userScore }}</span>
      </p>
      <p class="game-result">
        <i class="fa-solid fa-circle-xmark incorrect"></i> Computer's Score:
        <span>{{ store.computerScore }}</span>
      </p>
      <p class="game-result">
        <i class="fa-solid fa-circle-exclamation round"></i> Round:
        <span>{{ store.roundCount }}</span>
      </p>
    </div>
  </div>
</template>