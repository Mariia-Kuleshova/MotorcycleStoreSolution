export interface Inventory {
  id: number;
  productId: number;
  quantity: number;
  location?: string;
  lastUpdated: string;
}

export interface Product {
  id: number;
  name: string;
  brand: string;
  category: string;
  vin: string;
  modelYear: number;
  price: number;
  description?: string;
  imageUrl?: string;
  isAvailable: boolean;
  createdAt: string;
  supplierName: string;
  inventory?: Inventory;
}
