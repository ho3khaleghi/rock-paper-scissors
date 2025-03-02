<template>
    <div class="container" id="end">
      <div id="end-message">
        <p class="tnx-message">Thank you for playing!</p>
        <br />
        <p class="tnx-message">We hope you have enjoyed the game.</p>
      </div>
      <div id="gameresult">
        <p v-if="store.userScore > store.computerScore" id="victory" class="glowing-p">
          <span class="glowing-txt-p">VI<span class="faulty-letter-p">CT</span>ORY</span>
        </p>
        <p v-else id="defeat" class="glowing-p">
          <span class="glowing-txt-p">DE<span class="faulty-letter-p">FE</span>AT</span>
        </p>
      </div>
      <div id="end-btns" class="btn-container">
        <button @click="handleRematch"><i class="fa-solid fa-rotate-left"></i></button>
        <button @click="handleMainMenu"><i class="fa-solid fa-house"></i></button>
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue';
  import { useGameStore } from '../store/gameStore';
  import { useRouter } from 'vue-router';
  
  export default defineComponent({
    name: 'EndView',
    setup() {
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
  
      return { store, handleRematch, handleMainMenu };
    },
  });
  </script>
  