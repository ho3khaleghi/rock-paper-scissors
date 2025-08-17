<script setup lang="ts">
import {useAuthStore} from '../store/auth'
import {onMounted} from 'vue';
import {useGameStore} from '../store/gameStore';
import api from '../services/api';
import {useRouter} from 'vue-router';

const auth = useAuthStore();
const store = useGameStore();
const router = useRouter();

const showChangePassword = () => {
  router.push('/change-password');
}

onMounted(() => {
  api.get('/user/getUserProfile/?id=' + auth.state.user?.id, {
    headers: {
      Authorization: 'Bearer ' + auth.state.accessToken
    }
  })
      .then(response => {
        console.log(response.data);
        store.userEmail = response.data.data.email;
      })
      .catch(error => {
        console.error(error);
      });
})
</script>

<template>
  <div id="profile">
    <div class="starting-view">
      <input v-model="store.gameUsername" class="username user-pass" type="text" readonly/>
    </div>
    <div class="starting-view">
      <input v-model="store.userEmail" class="username user-pass" type="text" readonly/>
    </div>
    <div class="gap-filler"></div>
    <div class="content-center">
      <a class="link-button" @click="showChangePassword">
        <span class="glowing-txt-signup">Change Password</span>
      </a>
    </div>
  </div>
</template>

<style scoped>

.link-button {
  color: var(--glow-color);
  text-decoration: none;
  font-size: 18px;
  cursor: pointer;
}

</style>