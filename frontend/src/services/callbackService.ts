import type { CreateCallbackRequest, CreateCallbackResponse } from '../types/callback';
import { apiClient } from './apiClient';

export async function createCallbackRequest(
  request: CreateCallbackRequest,
): Promise<CreateCallbackResponse> {
  const { data } = await apiClient.post<CreateCallbackResponse>('/api/callbacks', request);
  return data;
}
