<script setup lang="ts">
import { useGameStore } from '../store/gameStore';
import { useRouter } from 'vue-router';

const store = useGameStore();
const router = useRouter();

const handleRematch = (): void => {
  store.resetGame();
  router.push('/matching');
};

const handleMainMenu = (): void => {
  store.resetGame();
  store.matchOption = 0;
  router.push('/starting');
};
</script>
<template>
  <div id="end">
    <div id="end-message">
      <p class="tnx-message">Thank you for playing!</p>
      <br />
      <p class="tnx-message">We hope you have enjoyed the game.</p>
    </div>
    <div id="gameresult">
      <p v-if="store.matchResult === 'victory'" class="glowing-p">
        <span class="glowing-txt-p">VI<span class="faulty-letter-p">CT</span>ORY</span>
      </p>
      <p v-if="store.matchResult === 'defeat'" class="glowing-defeat">
        <span class="glowing-defeat-txt">DE<span class="faulty-letter-p">FE</span>AT</span>
      </p>
    </div>
    <div id="end-btns" class="btn-container">
      <button @click="handleRematch"><i class="fa-solid fa-rotate-left"></i></button>
      <button @click="handleMainMenu"><i class="fa-solid fa-house"></i></button>
    </div>
  </div>
</template>

<style>
.glowing-defeat {
  position: relative;
  color: var(--glow-color-defeat);
  padding: 0.35em 1em;
  border: 0.15em solid var(--glow-color-defeat);
  border-radius: 0.45em;
  background: none;
  perspective: 2em;
  font-family: "Raleway", sans-serif;
  font-size: 25px;
  font-weight: 900;
  letter-spacing: 1em;

  -webkit-box-shadow: inset 0px 0px 0.5em 0px var(--glow-color-defeat),
      0px 0px 0.5em 0px var(--glow-color-defeat);
  -moz-box-shadow: inset 0px 0px 0.5em 0px var(--glow-color-defeat),
      0px 0px 0.5em 0px var(--glow-color-defeat);
  box-shadow: inset 0px 0px 0.5em 0px var(--glow-color-defeat),
      0px 0px 0.5em 0px var(--glow-color-defeat);
  animation: border-flicker 2s linear infinite;
}

.glowing-defeat-txt {
  float: left;
  margin-right: -0.8em;
  -webkit-text-shadow: 0 0 0.125em hsl(0 0% 100% / 0.3),
      0 0 0.45em var(--glow-color-defeat);
  -moz-text-shadow: 0 0 0.125em hsl(0 0% 100% / 0.3),
      0 0 0.45em var(--glow-color-defeat);
  text-shadow: 0 0 0.125em hsl(0 0% 100% / 0.3), 0 0 0.45em var(--glow-color-defeat);
  animation: text-flicker 3s linear infinite;
}

.glowing-defeat::before {
    content: "";
    position: absolute;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    opacity: 0.7;
    filter: blur(1em);
    transform: translateY(120%) rotateX(95deg) scale(1, 0.35);
    background: var(--glow-color-defeat);
    pointer-events: none;
}

.glowing-defeat::after {
    content: "";
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    opacity: 0;
    z-index: -1;
    background-color: var(--glow-color-defeat);
    box-shadow: 0 0 2em 0.2em var(--glow-color-defeat);
    transition: opacity 100ms linear;
}
</style>