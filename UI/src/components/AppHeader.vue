<script setup lang="ts">
import {computed, onMounted} from 'vue'
import {useRoute} from 'vue-router'
import {useAuthStore} from '../store/auth'
import ProfileMenu from './ProfileMenu.vue'
import router from "../router";

const route = useRoute()
const auth = useAuthStore()

const showProfileMenu = computed(() =>
    !route.meta?.hideProfileMenu && !!auth.state.isAuthenticated
)

onMounted(() => {
  if (!auth.state.isAuthenticated || !auth.state.user) {
    auth.logout();
  }
})
</script>

<template>
  <header class="app-header">
    <div class="left"></div>

    <p class="title">
      <i class="fa-solid fa-dice-five dice"></i>
      Rock Paper Scissors
      <i class="fa-solid fa-dice-five dice"></i>
    </p>

    <div class="right">
      <ProfileMenu
          v-if="showProfileMenu"
          :avatarUrl="auth.state.user?.avatarUrl || null"
          @signout="auth.logout"
      />
    </div>
  </header>
  <div class="hr hr-header"></div>
</template>

<style scoped>
.app-header {
  display: grid;
  grid-template-columns: 1fr auto 1fr;
  align-items: center;

  height: 56px;
  padding: 0 12px;
  border-bottom: 1px solid rgba(0, 0, 0, 0.06);
}

.title {
  margin: 0;
  font-weight: 600;
  justify-self: center;
  color: rgb(83 241 255);
}

.left {
  justify-self: start;
}

.right {
  justify-self: end;
  display: flex;
  align-items: center;
  gap: 8px;
}

.hr-header {
  height: 5px;
  margin-top: 10px;
}
</style>
