import axios from 'axios';

// Порожній baseURL — запити на той самий хост (5173), Vite проксує /api на backend
const baseURL = import.meta.env.VITE_API_URL ?? '';

export const apiClient = axios.create({
  baseURL,
  headers: { 'Content-Type': 'application/json' },
});

export function getApiErrorMessage(error: unknown): string {
  if (axios.isAxiosError(error)) {
    if (error.response?.status === 502) {
      return 'API не запущено на порту 5100. У другому терміналі: dotnet run --project MotorcycleStore.API --launch-profile http';
    }
    if (error.response) {
      const data = error.response.data as { message?: string } | string | undefined;
      if (data && typeof data === 'object' && data.message) {
        return data.message;
      }
      return `Сервер відповів з помилкою ${error.response.status}. Перевірте MySQL і лог API.`;
    }
    if (error.code === 'ERR_NETWORK') {
      return 'Немає з\'єднання з API. Запустіть MotorcycleStore.API на http://localhost:5100';
    }
    return error.message;
  }
  return 'Невідома помилка';
}
