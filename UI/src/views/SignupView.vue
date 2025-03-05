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
      <input v-model="username" class="username user-pass" type="text" placeholder="Enter your username..." maxlength="10" required />
    </div>
    <div class="starting-view">
      <input v-model="email" class="username user-pass" type="text" placeholder="Enter your email..." maxlength="30" required />
    </div>
    <div class="starting-view">
      <input v-model="password" class="password user-pass" type="password" placeholder="Enter your password..." maxlength="20" required />
    </div>
    <div class="starting-view">
      <input v-model="confirmPassword" class="password user-pass" type="password" placeholder="Re-enter your password..." maxlength="20" required />
    </div>
    <div class="gap-filler"></div>
    <button class="glowing-btn glowing-btn-signup signup-btn" @click="handleSignup">
      <span class="glowing-txt-signup">SI<span class="faulty-letter-signup">G</span>NUP</span>
    </button>
    <div class="starting-view">
      <p v-if="validationMessage" class="alert-msg" style="color: red;">{{ validationMessage }}</p>
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineComponent, ref } from 'vue';
import { useRouter } from 'vue-router';
import { hashPassword } from '../utils/hashHelper';
import api from '../services/api';

const router = useRouter();
const username = ref('');
const password = ref('');
const email = ref('');
const confirmPassword = ref('');
const validationMessage = ref('');

const handleSignup = async (): Promise<void> => {
  if (!username.value || !password.value || !confirmPassword.value || !email.value) {
    validationMessage.value = 'Please fill in all fields.';
    return;
  }
  
  if (password.value !== confirmPassword.value) {
    validationMessage.value = 'Passwords do not match.';
    return;
  }

  try{
    const response = await api.post('/user/signup', {
      username: username.value,
      password: await hashPassword(password.value),
      email: email.value
    });
    router.push('/');
  } catch (error) {
    console.error(error);
  }
};
</script>
