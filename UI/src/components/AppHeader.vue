<script setup lang="ts">
import {computed, onMounted, ref} from 'vue'
import {useRoute, useRouter} from 'vue-router'
import {useAuthStore} from '../store/auth'
import ProfileMenu from './ProfileMenu.vue'

const route = useRoute()
const router = useRouter()
const auth = useAuthStore()

const btnRef = ref<HTMLButtonElement | null>(null)

const showProfileMenu = computed(() =>
    !route.meta?.hideProfileMenu && !!auth.state.isAuthenticated
)

const back = () => {
  router.back()
}

onMounted(() => {
  if (!auth.state.isAuthenticated || !auth.state.user) {
    auth.logout();
  }
})
</script>

<template>
  <header class="app-header">
    <div class="left">
      <div class="back-button">
        <div class="back-button-container">
          <button
              ref="btnRef"
              type="button"
              @click="back"
          >
            <!--<img :src="resolvedAvatar" alt="User avatar" class="avatar-img"/>-->
<!--            <i class="fa-solid fa-backward-step"></i>-->
            <i class="fa-solid fa-angle-left"></i>
          </button>
        </div>
      </div>
    </div>

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
  <div class="title title-banner-container">
    <div class="hr hr-header"></div>
    <div class="title-banner">
      {{ route.name }}
    </div>
    <div class="hr hr-header"></div>
  </div>
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

.left {
  justify-self: start;
}

.right {
  justify-self: end;
  display: flex;
  align-items: center;
  gap: 8px;
}

.back-button {
  position: relative;
  display: inline-block;
  margin: 5px 5px 5px 5px;
  height: 50px;
  align-items: center;
  align-content: center;
  vertical-align: middle;
}

.back-button-container {
  display: flex;
  justify-content: space-evenly;
}

.back-button-container button {
  position: relative;
  padding: 5px 10px 5px 10px;
  margin-top: 5px;
  border: none;
  border-radius: 5px;
  background-color: transparent;
  color: #288cff;
  overflow: hidden;
  cursor: pointer;
  transition: 0.5s;
}

.back-button-container i {
  font-size: 3em;
}

@keyframes mymove {
  50% {
    box-shadow: none;
  }
}

.back-button-container button:hover {
  background: #288cff;
  color: #081743;
  box-shadow: 0 0 5px #288cff,
  0 0 25px #288cff,
  0 0 50px #288cff,
  0 0 200px #288cff;
}

.hr-header {
  width: 100%;
  height: 5px;
  margin-top: 20px;
}

.title {
  width: 100%;
  margin: 0;
  font-weight: 600;
  justify-self: center;
  color: rgb(83 241 255);
}

.title-banner-container {
  padding-top: 10px;
  padding-bottom: 20px;
  display: flex;
  text-align: center;
  justify-content: center;
  align-items: center;
}

.title-banner {
  color: rgb(249, 154, 52);
  font-size: large;
  white-space: nowrap;
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
