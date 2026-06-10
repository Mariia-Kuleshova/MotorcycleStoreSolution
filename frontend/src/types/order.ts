export type CreateWebOrderRequest = {
  productId: number;
  customerName: string;
  phone: string;
  email?: string;
  comment?: string;
};

export type CreateWebOrderResponse = {
  orderId: number;
  message: string;
};
