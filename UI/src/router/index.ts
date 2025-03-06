import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import LoginView from '../views/LoginView.vue';
import SignupView from '../views/SignupView.vue';
import StartingView from '../views/StartingView.vue';
import MatchingView from '../views/MatchingView.vue';
import PvPMatchingView from '../views/PvPMatchingView.vue';
import EndView from '../views/EndView.vue';

const routes: Array<RouteRecordRaw> = [
  { path: '/', name: 'Login', component: LoginView },
  { path: '/signup', name: 'Signup', component: SignupView },
  { path: '/starting', name: 'Starting', component: StartingView },
  { path: '/matching', name: 'Matching', component: MatchingView },
  { path: '/pvp', name: 'PvPMatching', component: PvPMatchingView },
  { path: '/end', name: 'End', component: EndView },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
