import Alert from '@mui/material/Alert';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Chip from '@mui/material/Chip';
import CircularProgress from '@mui/material/CircularProgress';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import { useEffect, useMemo, useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';
import { defaultProductFilters, ProductFilters } from '../components/catalog/ProductFilters';
import { ProductImage } from '../components/product/ProductImage';
import { getApiErrorMessage } from '../services/apiClient';
import { fetchProducts } from '../services/productService';
import type { Product } from '../types/product';
import { filterProducts, getFilterOptions } from '../utils/filterProducts';

export function CatalogPage() {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [filters, setFilters] = useState(defaultProductFilters);

  useEffect(() => {
    fetchProducts()
      .then(setProducts)
      .catch((err) => setError(getApiErrorMessage(err)))
      .finally(() => setLoading(false));
  }, []);

  const { brands, categories } = useMemo(() => getFilterOptions(products), [products]);
  const filtered = useMemo(() => filterProducts(products, filters), [filters, products]);

  return (
    <Stack spacing={3}>
      <Box>
        <Typography variant="h4" component="h1" gutterBottom>
          Каталог мотоциклів
        </Typography>
        <Typography color="text.secondary">
          У каталозі {products.length} моделей · показано {filtered.length}
        </Typography>
      </Box>

      <ProductFilters
        filters={filters}
        brands={brands}
        categories={categories}
        disabled={loading}
        onChange={setFilters}
        onReset={() => setFilters(defaultProductFilters)}
      />

      {loading && (
        <Box sx={{ display: 'flex', justifyContent: 'center', py: 4 }}>
          <CircularProgress />
        </Box>
      )}

      {error && <Alert severity="error">{error}</Alert>}

      {!loading && !error && (
        <Grid container spacing={2}>
          {filtered.map((product) => (
            <Grid key={product.id} size={{ xs: 12, sm: 6, md: 4 }}>
              <Card sx={{ height: '100%', display: 'flex', flexDirection: 'column' }}>
                <ProductImage
                  imageUrl={product.imageUrl}
                  alt={`${product.brand} ${product.name}`}
                  fallbackLabel={product.brand}
                />
                <CardContent sx={{ flexGrow: 1 }}>
                  <Stack direction="row" spacing={0.5} sx={{ mb: 1, flexWrap: 'wrap', gap: 0.5 }}>
                    <Chip label={product.brand} size="small" variant="outlined" />
                    <Chip label={product.category} size="small" color="primary" variant="outlined" />
                    <Chip
                      label={product.isAvailable ? 'В наявності' : 'Немає'}
                      size="small"
                      color={product.isAvailable ? 'success' : 'default'}
                      variant="outlined"
                    />
                  </Stack>
                  <Typography variant="subtitle1" sx={{ fontWeight: 600 }}>
                    {product.name}
                  </Typography>
                  <Typography variant="body2" color="text.secondary">
                    {product.modelYear} р.
                  </Typography>
                  <Typography variant="h6" color="primary.main" sx={{ mt: 1 }}>
                    ${product.price.toLocaleString()}
                  </Typography>
                </CardContent>
                <CardActions>
                  <Button component={RouterLink} to={`/catalog/${product.id}`} variant="contained" size="small">
                    Переглянути
                  </Button>
                </CardActions>
              </Card>
            </Grid>
          ))}
        </Grid>
      )}

      {!loading && !error && filtered.length === 0 && (
        <Paper sx={{ p: 3, textAlign: 'center' }}>
          <Typography color="text.secondary">За обраними фільтрами нічого не знайдено.</Typography>
        </Paper>
      )}
    </Stack>
  );
}
