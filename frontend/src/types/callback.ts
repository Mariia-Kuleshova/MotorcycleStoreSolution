export type CreateCallbackRequest = {
  name: string;
  phone: string;
  preferredTime?: string;
  message?: string;
};

export type CreateCallbackResponse = {
  id: number;
  message: string;
};
