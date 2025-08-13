<script setup lang="ts">
import {onMounted, onBeforeUnmount, ref, computed} from 'vue'

type Props = {
  avatarUrl?: string | null
  profileHref?: string
}
const props = withDefaults(defineProps<Props>(), {
  avatarUrl: null,
  profileHref: '/profile'
})

const emit = defineEmits<{
  (e: 'signout'): void
}>()

const open = ref(false)
const btnRef = ref<HTMLButtonElement | null>(null)
const menuRef = ref<HTMLDivElement | null>(null)

const resolvedAvatar = computed(() =>
    props.avatarUrl && props.avatarUrl.trim()
        ? props.avatarUrl
        : DEFAULT_AVATAR
)

function onToggle() {
  open.value = !open.value
}

function onEscape(e: KeyboardEvent) {
  if (e.key === 'Escape') {
    open.value = false
    btnRef.value?.focus()
  }
}

function onGlobalClick(e: MouseEvent) {
  if (!open.value) return
  const t = e.target as Node
  if (!menuRef.value?.contains(t) && !btnRef.value?.contains(t)) {
    open.value = false
  }
}

function signOut() {
  emit('signout')
  open.value = false
}

onMounted(() => {
  document.addEventListener('click', onGlobalClick)
  document.addEventListener('keydown', onEscape)
})

onBeforeUnmount(() => {
  document.removeEventListener('click', onGlobalClick)
  document.removeEventListener('keydown', onEscape)
})

const DEFAULT_AVATAR =
    // tiny inline SVG fallback (circle + user silhouette)
    `data:image/svg+xml;utf8,` +
    encodeURIComponent(`
<svg xmlns="http://www.w3.org/2000/svg" width="96" height="96" viewBox="0 0 24 24">
  <circle cx="12" cy="12" r="12" fill="#ddd"/>
  <circle cx="12" cy="8.5" r="3.5" fill="#bbb"/>
  <path d="M4 20c1.7-3.2 4.7-5 8-5s6.3 1.8 8 5" fill="#bbb"/>
</svg>
`)
</script>

<template>
  <div>
    <div class="profile-menu">
      <div class="avatar-container">
        <button
            ref="btnRef"
            type="button"
            aria-haspopup="menu"
            :aria-expanded="open"
            @click="onToggle"
        >
      <!--<img :src="resolvedAvatar" alt="User avatar" class="avatar-img"/>-->
          <i class="fa-regular fa-user"></i>
        </button>
      </div>
      <div
          v-show="open"
          ref="menuRef"
          class="dropdown"
          role="menu"
          aria-label="Profile menu"
      >
        <a class="dropdown-item" :href="profileHref" role="menuitem">Profile</a>
        <button class="dropdown-item danger" type="button" role="menuitem" @click="signOut">
          Sign out
        </button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.profile-menu {
  position: relative;
  display: inline-block;
  margin: 5px 5px 5px 5px;
  height: 50px;
  align-items: center;
  align-content: center;
  vertical-align: middle;
}

.avatar-btn {
  border: 0;
  background: transparent;
  padding: 0;
  cursor: pointer;
  display: inline-flex;
  align-items: center;
  justify-content: center;
}

.avatar-img {
  width: 36px;
  height: 36px;
  border-radius: 9999px;
  display: block;
  object-fit: cover;
  border: 1px solid rgba(0, 0, 0, 0.08);
}

.avatar-title {
  margin: 0;
  font-weight: 600;
  justify-self: center;
  color: rgb(83 241 255);
}

.avatar-container {
  display: flex;
  justify-content: space-evenly;
}

.avatar-container button {
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

.avatar-container i {
  font-size: 3em;
}

@keyframes mymove {
  50% {
    box-shadow: none;
  }
}

.avatar-container button:hover {
  background: #288cff;
  color: #081743;
  box-shadow: 0 0 5px #288cff,
  0 0 25px #288cff,
  0 0 50px #288cff,
  0 0 200px #288cff;
}

.dropdown {
  position: absolute;
  right: 0;
  margin-top: 8px;
  min-width: 180px;
  background-color: #081743;
  border: 1px solid rgba(0, 0, 0, 0.08);
  border-radius: 10px;
  box-shadow: 0 8px 24px rgba(0, 0, 0, 0.12);
  padding: 6px;
  z-index: 1000;
}

.dropdown-item {
  width: 100%;
  text-align: left;
  padding: 10px 12px;
  background: transparent;
  border: 0;
  font-size: 14px;
  border-radius: 8px;
  cursor: pointer;
  display: block;
  color: rgb(83 241 255);
  text-decoration: none;
}

.dropdown-item:hover {
  background: #288cff;
  color: #081743;
}

.dropdown-item.danger {
  color: #b91c1c;
}
</style>
