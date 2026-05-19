import type { Product } from '../types/product';
import { apiClient } from './apiClient';

export async function fetchProducts(): Promise<Product[]> {
  const { data } = await apiClient.get<Product[]>('/api/products');
  return data;
}

export async function fetchProductById(id: number): Promise<Product> {
  const { data } = await apiClient.get<Product>(`/api/products/${id}`);
  return data;
}
