<script setup lang="ts">
import {ref} from 'vue';
import {useRouter} from 'vue-router';
import {useAuthStore} from "../store/auth";
import {hashPassword} from '../utils/hashHelper';
import api from '../services/api';

const router = useRouter();
const auth = useAuthStore();
const currentPassword = ref('');
const newPassword = ref('');
const confirmPassword = ref('');
const validationMessage = ref('');

const changePassword = async (): Promise<void> => {
  if (!currentPassword.value || !newPassword.value || !confirmPassword.value) {
    validationMessage.value = 'Please fill in all fields.';
    return;
  }

  if (newPassword.value !== confirmPassword.value) {
    validationMessage.value = 'Passwords do not match.';
    return;
  }

  try {
    const response = await api.post('/user/changePassword', {
      userId: auth.state.user?.id,
      currentPassword: await hashPassword(currentPassword.value),
      newPassword: await hashPassword(newPassword.value)
    }, {
      headers: {
        Authorization: 'Bearer ' + auth.state.accessToken
      }
    });
    
    router.push('/profile');
  } catch (error) {
    console.error(error);
  }
}
</script>

<template>
  <div class="signup" id="signup">
    <p class="signup-view-p">
      Please enter your password (max 20 characters)
    </p>
    <div class="starting-view">
      <input v-model="currentPassword" class="password user-pass" type="password" placeholder="Your current password..."
             maxlength="20" required/>
    </div>
    <div class="starting-view">
      <input v-model="newPassword" class="password user-pass" type="password" placeholder="New password..."
             maxlength="20" required/>
    </div>
    <div class="starting-view">
      <input v-model="confirmPassword" class="password user-pass" type="password" placeholder="Confirm password..."
             maxlength="20" required/>
    </div>
    <div class="gap-filler"></div>
    <div class="content-center">
      <button class="glowing-btn glowing-btn-signup signup-btn" @click="changePassword">
        <span class="glowing-txt-signup">S<span class="faulty-letter-signup">A</span>VE</span>
      </button>
    </div>
    <div class="starting-view">
      <p v-if="validationMessage" class="alert-msg" style="color: red;">{{ validationMessage }}</p>
    </div>
  </div>
</template>

<style scoped>

</style>