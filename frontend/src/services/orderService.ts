import type { CreateWebOrderRequest, CreateWebOrderResponse } from '../types/order';
import { apiClient } from './apiClient';

export async function createWebOrder(request: CreateWebOrderRequest): Promise<CreateWebOrderResponse> {
  const { data } = await apiClient.post<CreateWebOrderResponse>('/api/orders', request);
  return data;
}
