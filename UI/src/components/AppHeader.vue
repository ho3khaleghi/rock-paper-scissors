<script setup lang="ts">
import { computed } from 'vue'
import { useRoute } from 'vue-router'
import { useAuthStore } from '../store/auth'
import ProfileMenu from './ProfileMenu.vue'

const route = useRoute()
const auth = useAuthStore()

const showProfileMenu = computed(() =>
    !route.meta?.hideProfileMenu// && !!auth.isAuthenticated
)
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
          :avatarUrl="auth.user?.avatarUrl || null"
          @signout="auth.logout"
      />
    </div>
  </header>
</template>

<style scoped>
.app-header {
  display: grid;
  grid-template-columns: 1fr auto 1fr;
  align-items: center;

  height: 56px;
  padding: 0 12px;
  border-bottom: 1px solid rgba(0,0,0,0.06);
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
</style>
