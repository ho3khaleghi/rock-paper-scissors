import axios from 'axios';

const api = axios.create({
  // Set your base URL for the API here:
  baseURL: 'https://localhost:5002/api',
  timeout: 100000,

});

export default api;
