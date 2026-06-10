import SearchIcon from '@mui/icons-material/Search';
import Alert from '@mui/material/Alert';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Chip from '@mui/material/Chip';
import CircularProgress from '@mui/material/CircularProgress';
import Grid from '@mui/material/Grid';
import InputAdornment from '@mui/material/InputAdornment';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import { useEffect, useMemo, useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';
import { ProductImage } from '../components/product/ProductImage';
import { getApiErrorMessage } from '../services/apiClient';
import { fetchProducts } from '../services/productService';
import type { Product } from '../types/product';

export function CatalogPage() {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [search, setSearch] = useState('');

  useEffect(() => {
    fetchProducts()
      .then(setProducts)
      .catch((err) => setError(getApiErrorMessage(err)))
      .finally(() => setLoading(false));
  }, []);

  const filtered = useMemo(() => {
    const q = search.trim().toLowerCase();
    if (!q) return products;
    return products.filter(
      (p) =>
        p.name.toLowerCase().includes(q) ||
        p.brand.toLowerCase().includes(q) ||
        p.category.toLowerCase().includes(q) ||
        p.vin.toLowerCase().includes(q),
    );
  }, [search, products]);

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

      <Paper sx={{ p: 2 }}>
        <TextField
          label="Пошук за назвою, брендом, категорією або VIN"
          fullWidth
          size="small"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          disabled={loading}
          slotProps={{
            input: {
              startAdornment: (
                <InputAdornment position="start">
                  <SearchIcon color="action" />
                </InputAdornment>
              ),
            },
          }}
        />
      </Paper>

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
                  height={88}
                />
                <CardContent sx={{ flexGrow: 1 }}>
                  <Stack direction="row" spacing={0.5} sx={{ mb: 1, flexWrap: 'wrap', gap: 0.5 }}>
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
                    {product.modelYear} р. · залишок {product.inventory?.quantity ?? 0} шт.
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
          <Typography color="text.secondary">За вашим запитом нічого не знайдено.</Typography>
        </Paper>
      )}
    </Stack>
  );
}
