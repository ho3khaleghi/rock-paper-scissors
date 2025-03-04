<template>
    <div class="login" id="login" style="display: block;">
      <p class="login-title">
        <i class="fa-solid fa-dice-five dice"></i>
        Rock Paper Scissors
        <i class="fa-solid fa-dice-five dice"></i>
      </p>
      <p class="login-p">
        Fill your username and password to be able to play the game
      </p>
      <div class="starting-view">
        <input v-model="store.loginUsername" class="username user-pass" type="text" placeholder="Enter your username..." maxlength="10" required />
      </div>
      <div class="starting-view">
        <input v-model="store.loginPassword" class="password user-pass" type="password" placeholder="Enter your password..." maxlength="20" required />
      </div>
      <div class="gap-filler"></div>
      <button class="glowing-btn glowing-p login-btn" @click="handleLogin">
        <span class="glowing-txt-p">LO<span class="faulty-letter-p">G</span>IN</span>
      </button>
      <p class="signup-p">
        Click on the sign up button if you don't have any account.
      </p>
      <button class="glowing-btn glowing-btn-signup signup-btn" @click="goToSignup">
        <span class="glowing-txt-signup">SI<span class="faulty-letter-signup">G</span>NUP</span>
      </button>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue';
  import { useGameStore } from '../store/gameStore';
  import { useRouter } from 'vue-router';
  import { hashPassword } from '../utils/hashHelper';
  import api from '../services/api';
  
  export default defineComponent({
    name: 'LoginView',
    setup() {
      const store = useGameStore();
      const router = useRouter();
  
      const handleLogin = async (): Promise<void> => {
        if (store.loginUsername && store.loginPassword) {
          store.gameUsername = store.loginUsername;
          const hashedPassword = await hashPassword(store.loginPassword);

          try {
            const response = await api.post('/user/login', {
              username: store.loginUsername,
              password: hashedPassword,
            });

            router.push('/starting');
          } catch (error) {
            console.error(error);
          }
        }
      };
  
      const goToSignup = (): void => {
        router.push('/signup');
      };
  
      return { store, handleLogin, goToSignup };
    },
  });
  </script>
  