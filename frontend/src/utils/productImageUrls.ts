import { getProductImageUrl } from './getProductImageUrl';

export const IMAGE_URL_SEPARATOR = ';';

export function parseProductImageUrls(imageUrl?: string | null): string[] {
  if (!imageUrl?.trim()) return [];
  return imageUrl
    .split(IMAGE_URL_SEPARATOR)
    .map((part) => part.trim())
    .filter(Boolean);
}

export function getPrimaryProductImageUrl(imageUrl?: string | null): string | undefined {
  const first = parseProductImageUrls(imageUrl)[0];
  return first ? getProductImageUrl(first) : undefined;
}

export function getProductImageUrls(imageUrl?: string | null): string[] {
  return parseProductImageUrls(imageUrl)
    .map((path) => getProductImageUrl(path))
    .filter((url): url is string => Boolean(url));
}
