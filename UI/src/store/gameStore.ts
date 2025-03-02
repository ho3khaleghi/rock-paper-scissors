import { defineStore } from 'pinia';

interface GameState {
  // Authentication & user info
  loginUsername: string;
  loginPassword: string;
  signupUsername: string;
  signupPassword: string;
  signupConfirmPassword: string;
  gameUsername: string;
  alertMsg: string;
  // Game settings and scores
  matchOption: number;
  topicText: string;
  userScore: number;
  computerScore: number;
  roundCount: number;
  // Display values for icons
  playerDisplay: string;
  computerDisplay: string;
  resultDisplay: string;
  // Flag for showing a "Next Round!" announcer
  showNextRoundAnnouncer: boolean;
}

export const useGameStore = defineStore('game', {
  state: (): GameState => ({
    loginUsername: '',
    loginPassword: '',
    signupUsername: '',
    signupPassword: '',
    signupConfirmPassword: '',
    gameUsername: '',
    alertMsg: '',
    matchOption: 0,
    topicText: '',
    userScore: 0,
    computerScore: 0,
    roundCount: 0,
    playerDisplay: '',
    computerDisplay: '',
    resultDisplay: '',
    showNextRoundAnnouncer: false,
  }),
  actions: {
    resetGame() {
      this.userScore = 0;
      this.computerScore = 0;
      this.roundCount = 0;
      this.playerDisplay = '';
      this.computerDisplay = '';
      this.resultDisplay = '';
    },
    setMatchOption(option: number, bo1Icon: string, bo3Icon: string, bo5Icon: string) {
      this.matchOption = option;
      if (option === 1) {
        this.topicText = `${bo1Icon} Best of One ${bo1Icon}`;
      } else if (option === 3) {
        this.topicText = `${bo3Icon} Best of Three ${bo3Icon}`;
      } else if (option === 5) {
        this.topicText = `${bo5Icon} Best of Five ${bo5Icon}`;
      }
    },
  },
});
