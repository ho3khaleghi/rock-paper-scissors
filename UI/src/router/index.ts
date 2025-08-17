import {createRouter, createWebHistory, RouteRecordRaw} from 'vue-router';
import LoginView from '../views/LoginView.vue';
import SignupView from '../views/SignupView.vue';
import StartingView from '../views/StartingView.vue';
import MatchingView from '../views/MatchingView.vue';
import PvPMatchingView from '../views/PvPMatchingView.vue';
import EndView from '../views/EndView.vue';
import ProfileView from '../views/ProfileView.vue';

const routes: Array<RouteRecordRaw> = [
    {path: '/', name: 'Login', component: LoginView, meta: {hideProfileMenu: true}},
    {path: '/signup', name: 'Signup', component: SignupView, meta: {hideProfileMenu: true}},
    {path: '/starting', name: 'Starting', component: StartingView, meta: {hideProfileMenu: false}},
    {path: '/matching', name: 'Matching', component: MatchingView, meta: {hideProfileMenu: false}},
    {path: '/pvp', name: 'PvPMatching', component: PvPMatchingView, meta: {hideProfileMenu: false}},
    {path: '/profile', name: 'Profile', component: ProfileView, meta: {hideProfileMenu: false}},
    {path: '/end', name: 'End', component: EndView, meta: {hideProfileMenu: false}},
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
