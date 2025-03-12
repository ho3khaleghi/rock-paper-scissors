<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useGameStore } from '../store/gameStore';
import { useRouter } from 'vue-router';
import { QueueService } from '../services/queueService';
import { JoinQueueModel } from '../models/queue/joinQueueModel';
import { LeaveQueueModel } from '../models/queue/leaveQueueModel';
import { SignalrService } from '../services/signalrService';

const store = useGameStore();
const router = useRouter();
const signalrService = new SignalrService();
// Icon definitions for match options:
const bo1Icon = `<i class="fa-solid fa-dice-one"></i>`;
const bo3Icon = `<i class="fa-solid fa-dice-three"></i>`;
const bo5Icon = `<i class="fa-solid fa-dice-five"></i>`;

const setMatchOption = (option: number): void => {
  store.setMatchOption(option, bo1Icon, bo3Icon, bo5Icon);
};

const startGame = (): void => {
  if (!store.gameUsername || !store.matchOption) {
    store.alertMsg = 'Enter your username and select a match option!';
    return;
  }
  store.alertMsg = '';
  store.resetGame();
  router.push('/matching');
};

const leaveQueue = (): void => {
  new QueueService().leaveQueue({ username: store.gameUsername, gameOption: store.matchOption } as LeaveQueueModel);
};

const joinQueue = (): void => {
  if (!store.gameUsername || !store.matchOption) {
    store.alertMsg = 'Enter your username and select a match option!';
    return;
  }

  new QueueService().joinQueue({ username: store.gameUsername, gameOption: store.matchOption } as JoinQueueModel);
};

onMounted(async () => {
  await signalrService.startUserSpesific(store.gameUsername);

  signalrService.connection?.invoke('JoinMatch', "FirstMatchId");

  signalrService.connection?.on("MatchFound", (match: any) => {
    debugger;
    console.log(match.opponentId, match.gameOption);
    alert(`Match found with ${match.opponentId} for ${match.gameOption}`);
  });
});
</script>
  
<template>
  <div class="starting" id="starting">
    <div class="starting-view username-banner-container">
      <div class="username-banner">
        <div class="">{{ store.gameUsername }}</div>
      </div>
    </div>
    <div class="btn-container">
      <button id="bo1" :class="{ 'bo1-clicked': store.matchOption === 1 }" @click="setMatchOption(1)">
        <i class="fa-solid fa-dice-one"></i>
      </button>
      <button id="bo3" :class="{ 'bo3-clicked': store.matchOption === 3 }" @click="setMatchOption(3)">
        <i class="fa-solid fa-dice-three"></i>
      </button>
      <button id="bo5" :class="{ 'bo5-clicked': store.matchOption === 5 }" @click="setMatchOption(5)">
        <i class="fa-solid fa-dice-five"></i>
      </button>
    </div>
    <div class="rules-container">
      <h4>Rules:</h4>
      <ul>
        <li>You have 3 choices (Rock, Paper, Scissors)</li>
        <li>
          You have 3 options (Bo1, Bo3, Bo5). Bo1 is a 1‑round match.
          Bo3 is best‑of‑3 (2 wins needed) and Bo5 is best‑of‑5 (3 wins needed).
        </li>
        <li class="ol-title">
          Just remember:
          <ol>
            <li>Rock beats Scissors.</li>
            <li>Paper beats Rock.</li>
            <li>Scissors beats Paper.</li>
          </ol>
        </li>
      </ul>
    </div>
    <div class="alert-msg-container">
      <p v-if="store.alertMsg" id="alert-msg">
        <i class="fa-solid fa-circle-exclamation round"></i>
        {{ store.alertMsg }}
      </p>
    </div>
    <div class="btn-container">
      <button id="joinQueue" class="join-queue" @click="joinQueue">
        <i class="fa-solid fa-users fa-beat-fade"></i>
      </button>
      <button id="battleBot" @click="startGame">
        <i class="fa-solid fa-robot fa-beat-fade"></i>
      </button>
      <button id="leaveQueue" class="leave-queue" @click="leaveQueue">
        <i class="fa-solid fa-users-slash fa-beat-fade"></i>
      </button>
    </div>
  </div>
</template>

<style scoped>
.username-banner-container {
  padding-top: 20px;
  padding-bottom: 20px;
  display: flex;
  text-align: center;
  justify-content: center;
  align-items: center;
}

.username-banner {
  color: rgb(249, 154, 52);
  font-size: x-large;
  border-top-width: 1px;
  border-bottom-width: 1px;
  border-left-width: 0px;
  border-right-width: 0px;
  border-style: double;
  border-color: rgb(249, 154, 52);
  width: 98%;
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
}

.btn-container-start {
  display: flex;
  text-align: center;
  justify-content: center;
  align-items: center;
}

.join-queue {
  color: rgb(97, 255, 83);
}

.leave-queue {
  color: rgb(255, 97, 97);
}
</style>