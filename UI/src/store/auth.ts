// src/stores/auth.ts
import { defineStore } from 'pinia'
import { useRouter } from 'vue-router';
import api from '../services/api'

const router = useRouter();

interface User {
  id: number
  username: string
  avatarUrl: string
}

interface AuthState {
  accessToken: string | null
  user: User | null
  isAuthenticated: boolean
}

export const useAuthStore = defineStore('auth', {
  state: (): AuthState => ({
    accessToken: null,
    user: null,
    isAuthenticated: false,
  }),
  actions: {
    async login(username: string, password: string): Promise<void> {
      try {
        const response = await api.post('/auth/login', { username, password });
        this.accessToken = response.data.accessToken;
        this.isAuthenticated = true;

        // Optionally, decode the token to extract user information.
        // For example, using jwt-decode library:
        // import jwtDecode from 'jwt-decode'
        // this.user = jwtDecode<User>(this.accessToken)

      } catch (error) {
        console.error('Login failed:', error);
        this.isAuthenticated = false;
        throw error;
      }
    },
    async refreshAccessToken(): Promise<void> {
      try {
        // The refresh token is sent automatically via the HttpOnly cookie.
        const response = await api.post('/auth/refresh');
        this.accessToken = response.data.accessToken;
        this.isAuthenticated = true;
      } catch (error) {
        console.error('Token refresh failed:', error);
        this.logout();
      }
    },
    async logout(): Promise<void> {
      this.accessToken = null;
      this.user = null;
      this.isAuthenticated = false;

      try {
        // The refresh token is sent automatically via the HttpOnly cookie.
        //const response = await api.post('/auth/logout');
      } catch (error) {
        console.error('Logout failed:', error);
      }

      router.push('/');
    }
  }
})
