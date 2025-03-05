<script setup lang="ts">
import { defineComponent } from 'vue';
import { useGameStore } from '../store/gameStore';
import { useRouter } from 'vue-router';

const store = useGameStore();
const router = useRouter();
// Icon definitions for match options:
const bo1Icon = `<i class="fa-solid fa-dice-one dice"></i>`;
const bo3Icon = `<i class="fa-solid fa-dice-three dice"></i>`;
const bo5Icon = `<i class="fa-solid fa-dice-five dice"></i>`;

const setMatchOption = (option: number): void => {
  store.setMatchOption(option, bo1Icon, bo3Icon, bo5Icon);
};

const startGame = (): void => {
  if (!store.gameUsername || !store.matchOption) {
    store.alertMsg = 'Enter your username and select a match option!';
    return;
  }
  store.alertMsg = '';
  store.resetGame();
  router.push('/matching');
};
</script>
  
<template>
  <div class="starting" id="starting">
    <div class="starting-view username-banner-container">
      <div class="username-banner">
        <div class="">{{ store.gameUsername }}</div>
      </div>
    </div>
    <div class="btn-container">
      <button id="bo1" :class="{ 'bo1-clicked': store.matchOption === 1 }" @click="setMatchOption(1)">
        <i class="fa-solid fa-dice-one dice"></i>
      </button>
      <button id="bo3" :class="{ 'bo3-clicked': store.matchOption === 3 }" @click="setMatchOption(3)">
        <i class="fa-solid fa-dice-three dice"></i>
      </button>
      <button id="bo5" :class="{ 'bo5-clicked': store.matchOption === 5 }" @click="setMatchOption(5)">
        <i class="fa-solid fa-dice-five dice"></i>
      </button>
    </div>
    <div class="rules-container">
      <h4>Rules:</h4>
      <ul>
        <li>You have 3 choices (Rock, Paper, Scissors)</li>
        <li>
          You have 3 options (Bo1, Bo3, Bo5). Bo1 is a 1‑round match.
          Bo3 is best‑of‑3 (2 wins needed) and Bo5 is best‑of‑5 (3 wins needed).
        </li>
        <li class="ol-title">
          Just remember:
          <ol>
            <li>Rock beats Scissors.</li>
            <li>Paper beats Rock.</li>
            <li>Scissors beats Paper.</li>
          </ol>
        </li>
      </ul>
    </div>
    <div class="alert-msg-container">
      <p v-if="store.alertMsg" id="alert-msg">
        <i class="fa-solid fa-circle-exclamation round"></i>
        {{ store.alertMsg }}
      </p>
    </div>
    <button class="glowing-btn" @click="startGame">
      <span class="glowing-txt">S<span class="faulty-letter">T</span>ART</span>
    </button>
  </div>
</template>

<style scoped>
.username-banner-container {
  padding-top: 20px;
  padding-bottom: 20px;
  display: flex;
  text-align: center;
  justify-content: center;
  align-items: center;
}

.username-banner {
  color: rgb(249, 154, 52);
  font-size: x-large;
  border-top-width: 1px;
  border-bottom-width: 1px;
  border-left-width: 0px;
  border-right-width: 0px;
  border-style: double;
  border-color: rgb(249, 154, 52);
  width: 98%;
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>