import { getProductImageUrl } from './getProductImageUrl';

/** Роздільник кількох URL в полі imageUrl (як на backend). */
export const IMAGE_URL_SEPARATOR = ';';

/** Розбити рядок imageUrl на список шляхів. */
export function parseProductImageUrls(imageUrl?: string | null): string[] {
  if (!imageUrl?.trim()) return [];
  return imageUrl
    .split(IMAGE_URL_SEPARATOR)
    .map((part) => part.trim())
    .filter(Boolean);
}

/** Перше фото для картки в каталозі. */
export function getPrimaryProductImageUrl(imageUrl?: string | null): string | undefined {
  const first = parseProductImageUrls(imageUrl)[0];
  return first ? getProductImageUrl(first) : undefined;
}

/** Усі фото для галереї на сторінці мотоцикла. */
export function getProductImageUrls(imageUrl?: string | null): string[] {
  return parseProductImageUrls(imageUrl)
    .map((path) => getProductImageUrl(path))
    .filter((url): url is string => Boolean(url));
}
