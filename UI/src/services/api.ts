import axios from 'axios';

const api = axios.create({
  // Set your base URL for the API here:
  baseURL: 'http://localhost:5002/api',
});

export default api;
