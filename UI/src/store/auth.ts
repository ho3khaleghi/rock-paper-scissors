import {defineStore} from 'pinia'
import {useRouter} from 'vue-router';
import api from '../services/api';
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

export const useAuthStore = defineStore('auth', () => {
    const router = useRouter();
    const state: AuthState = {
        accessToken: null,
        user: null,
        isAuthenticated: false,
    };
    
    const login = async (username: string, password: string): Promise<void> => {
        try {
            const response = await api.post('/user/login', {username, password});
            state.accessToken = response.data.accessToken;
            state.isAuthenticated = true;
            state.user = {
                id: response.data.userId,
                username: response.data.username,
                avatarUrl: ''
            };
        } catch (error) {
            console.error('Login failed:', error);
            state.isAuthenticated = false;
            throw error;
        }
    }
    
    const refreshAccessToken = async (): Promise<void> => {
        try {
            // The refresh token is sent automatically via the HttpOnly cookie.
            const response = await api.post('/auth/refresh');
            state.accessToken = response.data.accessToken;
            state.isAuthenticated = true;
        } catch (error) {
            console.error('Token refresh failed:', error);
            logout();
        }
    }

    const logout = async (): Promise<void> => {
        state.accessToken = null;
        state.user = null;
        state.isAuthenticated = false;

        try {
            // The refresh token is sent automatically via the HttpOnly cookie.
            //const response = await api.post('/auth/logout');
        } catch (error) {
            console.error('Logout failed:', error);
        }
        router.push('/');
    }
    
    return { state, login, refreshAccessToken, logout }
})