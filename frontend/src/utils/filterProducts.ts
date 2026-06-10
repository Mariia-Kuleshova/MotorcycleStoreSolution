import type { Product } from '../types/product';

export type AvailabilityFilter = 'all' | 'available';

export type ProductFilterState = {
  search: string;
  brand: string;
  category: string;
  availability: AvailabilityFilter;
  priceMin: string;
  priceMax: string;
  yearMin: string;
  yearMax: string;
};

export const defaultProductFilters: ProductFilterState = {
  search: '',
  brand: '',
  category: '',
  availability: 'all',
  priceMin: '',
  priceMax: '',
  yearMin: '',
  yearMax: '',
};

function parseNumber(value: string): number | null {
  const trimmed = value.trim();
  if (!trimmed) return null;
  const num = Number(trimmed);
  return Number.isFinite(num) ? num : null;
}

export function filterProducts(products: Product[], filters: ProductFilterState): Product[] {
  const q = filters.search.trim().toLowerCase();
  const priceMin = parseNumber(filters.priceMin);
  const priceMax = parseNumber(filters.priceMax);
  const yearMin = parseNumber(filters.yearMin);
  const yearMax = parseNumber(filters.yearMax);

  return products.filter((product) => {
    if (filters.brand && product.brand !== filters.brand) return false;
    if (filters.category && product.category !== filters.category) return false;
    if (filters.availability === 'available' && !product.isAvailable) return false;

    if (priceMin !== null && product.price < priceMin) return false;
    if (priceMax !== null && product.price > priceMax) return false;
    if (yearMin !== null && product.modelYear < yearMin) return false;
    if (yearMax !== null && product.modelYear > yearMax) return false;

    if (!q) return true;

    return (
      product.name.toLowerCase().includes(q) ||
      product.brand.toLowerCase().includes(q) ||
      product.category.toLowerCase().includes(q) ||
      product.vin.toLowerCase().includes(q)
    );
  });
}

export function getFilterOptions(products: Product[]) {
  const brands = [...new Set(products.map((p) => p.brand).filter(Boolean))].sort((a, b) =>
    a.localeCompare(b, 'uk'),
  );
  const categories = [...new Set(products.map((p) => p.category).filter(Boolean))].sort((a, b) =>
    a.localeCompare(b, 'uk'),
  );

  return { brands, categories };
}

export function hasActiveFilters(filters: ProductFilterState): boolean {
  return (
    filters.search.trim() !== '' ||
    filters.brand !== '' ||
    filters.category !== '' ||
    filters.availability !== 'all' ||
    filters.priceMin.trim() !== '' ||
    filters.priceMax.trim() !== '' ||
    filters.yearMin.trim() !== '' ||
    filters.yearMax.trim() !== ''
  );
}
