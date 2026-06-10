const apiBase = import.meta.env.VITE_API_URL ?? '';

/** URL для відображення фото продукту (шлях з API або через Vite proxy). */
export function getProductImageUrl(imageUrl?: string | null): string | undefined {
  if (!imageUrl) return undefined;
  if (imageUrl.startsWith('http://') || imageUrl.startsWith('https://')) {
    return imageUrl;
  }
  if (apiBase) {
    return `${apiBase.replace(/\/$/, '')}${imageUrl}`;
  }
  return imageUrl;
}
