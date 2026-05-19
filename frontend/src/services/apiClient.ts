import axios from 'axios';

// Порожній baseURL — запити на той самий хост (5173), Vite проксує /api на backend
const baseURL = import.meta.env.VITE_API_URL ?? '';

export const apiClient = axios.create({
  baseURL,
  headers: { 'Content-Type': 'application/json' },
});

export function getApiErrorMessage(error: unknown): string {
  if (axios.isAxiosError(error)) {
    if (error.response) {
      return `Сервер відповів з помилкою ${error.response.status}. Перевірте MySQL і лог API.`;
    }
    if (error.code === 'ERR_NETWORK') {
      return 'Немає з\'єднання з API. Запустіть MotorcycleStore.API на http://localhost:5100';
    }
    return error.message;
  }
  return 'Невідома помилка';
}
