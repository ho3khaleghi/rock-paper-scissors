<template>
    <div class="signup" id="signup">
      <p class="login-title">
        <i class="fa-solid fa-dice-five dice"></i>
        Rock Paper Scissors
        <i class="fa-solid fa-dice-five dice"></i>
      </p>
      <p class="signup-view-p">
        Please enter your username (max 10 characters) and password (max 20 characters)
      </p>
      <div class="starting-view">
        <input v-model="store.signupUsername" class="username user-pass" type="text" placeholder="Enter your username..." maxlength="10" required />
      </div>
      <div class="starting-view">
        <input v-model="store.signupUsername" class="username user-pass" type="text" placeholder="Enter your email..." maxlength="10" required />
      </div>
      <div class="starting-view">
        <input v-model="store.signupPassword" class="password user-pass" type="password" placeholder="Enter your password..." maxlength="20" required />
      </div>
      <div class="starting-view">
        <input v-model="store.signupConfirmPassword" class="password user-pass" type="password" placeholder="Re-enter your password..." maxlength="20" required />
      </div>
      <div class="gap-filler"></div>
      <button class="glowing-btn glowing-btn-signup signup-btn" @click="handleSignup">
        <span class="glowing-txt-signup">SI<span class="faulty-letter-signup">G</span>NUP</span>
      </button>
      <p v-if="store.alertMsg" class="alert-msg">{{ store.alertMsg }}</p>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue';
  import { useGameStore } from '../store/gameStore';
  import { useRouter } from 'vue-router';
  
  export default defineComponent({
    name: 'SignupView',
    setup() {
      const store = useGameStore();
      const router = useRouter();
  
      const handleSignup = (): void => {
        if (!store.signupUsername || !store.signupPassword || !store.signupConfirmPassword) {
          store.alertMsg = 'Please fill in all fields.';
          return;
        }
        if (store.signupPassword !== store.signupConfirmPassword) {
          store.alertMsg = 'Passwords do not match.';
          return;
        }
        store.gameUsername = store.signupUsername;
        router.push('/starting');
      };
  
      return { store, handleSignup };
    },
  });
  </script>
  