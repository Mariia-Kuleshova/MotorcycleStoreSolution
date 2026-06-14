import axios from 'axios';

const baseURL = import.meta.env.VITE_API_URL ?? '';

export const apiClient = axios.create({
  baseURL,
  headers: { 'Content-Type': 'application/json' },
});

export function getApiErrorMessage(error: unknown): string {
  if (axios.isAxiosError(error)) {
    if (error.response?.status === 502) {
      return 'Сервер тимчасово недоступний. Спробуйте пізніше.';
    }
    if (error.response) {
      const data = error.response.data as { message?: string } | string | undefined;
      if (data && typeof data === 'object' && data.message) {
        return data.message;
      }
      return `Помилка сервера (${error.response.status}).`;
    }
    if (error.code === 'ERR_NETWORK') {
      return 'Немає з\'єднання з сервером. Спробуйте пізніше.';
    }
    return error.message;
  }
  return 'Невідома помилка';
}
