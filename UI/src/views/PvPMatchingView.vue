<script setup lang="ts">
import { ref } from 'vue';
import { useGameStore } from '../store/gameStore';
import { useRouter } from 'vue-router';
import type { Choice, Result} from "../types/commonTypes";

const router = useRouter();
const store = useGameStore();

let playerChoice = ref<Choice | null>(null);
let opponentChoice = ref<Choice | null>(null);
let roundResult: Result | null = null;
let playerScore = ref<number>(0);
let opponentScore = ref<number>(0);
let roundCount = ref<number>(1);

const checkWinner = (): Result => {
  if (playerChoice.value === opponentChoice.value) return "draw";
  if (opponentChoice.value === "rock") {
    return playerChoice.value === "paper" ? "win" : "lose";
  } else if (opponentChoice.value === "paper") {
    return playerChoice.value === "scissors" ? "win" : "lose";
  } else if (opponentChoice.value === "scissors") {
    return playerChoice.value === "rock" ? "win" : "lose";
  }

  return "draw";
};

const checkRoundLimit = (): void => {
  if (playerScore.value === store.matchOption || opponentScore.value === store.matchOption) {
    setTimeout(() => {
      router.push("/end");
    }, 1500);
  }
};

const makeChoice = (choice: Choice): void => {
  playerChoice.value = choice;
  roundResult = checkWinner();
  if (roundResult === "win") {
    playerScore.value++;
  } else if (roundResult === "lose") {
    opponentScore.value++;
  }

  checkRoundLimit();

  roundCount.value++;
};
</script>

<template>
  <div class="container" id="pvpmatching">
    <div id="topic">
      <span id="topic-text" v-html="store.topicText"></span>
    </div>
    <div class="text-container" id="text-container">
      <p class="game-text">
        <span id="username-input" class="label">{{ store.gameUsername }}:</span>
        <i v-if="playerChoice === 'rock'" class="fa-solid fa-hand-back-fist fa-2xl"></i>
        <i v-if="playerChoice === 'paper'" class="fa-solid fa-hand fa-2xl"></i>
        <i v-if="playerChoice === 'scissors'" class="fa-solid fa-hand-scissors fa-rotate-90 fa-2xl"></i>
      </p>
      <div class="hr"></div>
      <p class="game-text">
        <span class="label">Opponent:</span>
        <i v-if="opponentChoice === 'rock'" class="fa-solid fa-hand-back-fist fa-2xl"></i>
        <i v-if="opponentChoice === 'paper'" class="fa-solid fa-hand fa-2xl"></i>
        <i v-if="opponentChoice === 'scissors'" class="fa-solid fa-hand-scissors fa-rotate-90 fa-2xl"></i>
      </p>
      <div class="hr"></div>
      <p class="game-text">
        <span class="label">Result:</span>
        <i v-if="roundResult === 'win'" class="fa-solid fa-thumbs-up fa-2xl"></i>
        <i v-if="roundResult === 'lose'" class="fa-solid fa-thumbs-down-2xl"></i>
        <i v-if="roundResult === 'draw'" class="fa-solid fa-handshake fa-2xl"></i>
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
        <span>{{ playerScore }}</span>
      </p>
      <p class="game-result">
        <i class="fa-solid fa-circle-xmark incorrect"></i> Opponent's Score:
        <span>{{ opponentScore }}</span>
      </p>
      <p class="game-result">
        <i class="fa-solid fa-circle-exclamation round"></i> Round:
        <span>{{ roundCount }}</span>
      </p>
    </div>
  </div>
</template>
  