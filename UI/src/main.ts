import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import { createPinia } from 'pinia';
import { Quasar } from 'quasar';

import '../assets/css/style.css';
// Import Quasar css
import 'quasar/dist/quasar.css';

const app = createApp(App);

app.use(createPinia());
app.use(router);
app.use(Quasar, { plugins: {} });

app.mount('#app');
