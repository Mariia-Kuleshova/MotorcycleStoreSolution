import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import Alert from '@mui/material/Alert';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Chip from '@mui/material/Chip';
import CircularProgress from '@mui/material/CircularProgress';
import Divider from '@mui/material/Divider';
import Grid from '@mui/material/Grid';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import { useEffect, useState } from 'react';
import { Link as RouterLink, useParams } from 'react-router-dom';
import { getApiErrorMessage } from '../services/apiClient';
import { fetchProductById } from '../services/productService';
import type { Product } from '../types/product';

export function ProductDetailPage() {
  const { id } = useParams<{ id: string }>();
  const [product, setProduct] = useState<Product | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const productId = Number(id);
    if (Number.isNaN(productId)) {
      setError('Невірний ідентифікатор мотоцикла.');
      setLoading(false);
      return;
    }

    fetchProductById(productId)
      .then(setProduct)
      .catch((err) => setError(getApiErrorMessage(err)))
      .finally(() => setLoading(false));
  }, [id]);

  if (loading) {
    return (
      <Box sx={{ display: 'flex', justifyContent: 'center', py: 6 }}>
        <CircularProgress />
      </Box>
    );
  }

  if (error || !product) {
    return (
      <Paper sx={{ p: 3 }}>
        <Typography variant="h6" gutterBottom>
          {error ?? 'Мотоцикл не знайдено'}
        </Typography>
        <Button component={RouterLink} to="/catalog" startIcon={<ArrowBackIcon />}>
          До каталогу
        </Button>
      </Paper>
    );
  }

  const qty = product.inventory?.quantity ?? 0;

  return (
    <Stack spacing={2}>
      <Button component={RouterLink} to="/catalog" startIcon={<ArrowBackIcon />} sx={{ alignSelf: 'flex-start' }}>
        Назад до каталогу
      </Button>

      <Grid container spacing={3}>
        <Grid size={{ xs: 12, md: 5 }}>
          <Paper
            variant="outlined"
            sx={{
              height: { xs: 200, md: 280 },
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'center',
              bgcolor: '#2a2a34',
            }}
          >
            <Typography color="text.secondary" align="center">
              {product.brand}
              <br />
              <Typography component="span" variant="caption">
                (зображення буде пізніше)
              </Typography>
            </Typography>
          </Paper>
        </Grid>

        <Grid size={{ xs: 12, md: 7 }}>
          <Paper sx={{ p: 3 }}>
            <Stack direction="row" spacing={1} sx={{ mb: 2, flexWrap: 'wrap', gap: 0.5 }}>
              <Chip label={product.category} color="primary" />
              <Chip
                label={product.isAvailable ? `В наявності: ${qty} шт.` : 'Немає в наявності'}
                color={product.isAvailable ? 'success' : 'default'}
              />
            </Stack>

            <Typography variant="h4" component="h1" gutterBottom>
              {product.brand} {product.name}
            </Typography>
            <Typography variant="h5" color="primary.main" gutterBottom>
              ${product.price.toLocaleString()}
            </Typography>

            <Divider sx={{ my: 2 }} />

            <Stack spacing={0.75}>
              <Typography><strong>Рік:</strong> {product.modelYear}</Typography>
              <Typography><strong>VIN:</strong> {product.vin}</Typography>
              <Typography><strong>Постачальник:</strong> {product.supplierName}</Typography>
              {product.description && (
                <Typography sx={{ mt: 1 }}>
                  <strong>Опис:</strong> {product.description}
                </Typography>
              )}
            </Stack>

            <Stack direction="row" spacing={1} sx={{ mt: 3, flexWrap: 'wrap', gap: 1 }}>
              <Button
                component={RouterLink}
                to="/checkout"
                state={{ productId: product.id }}
                variant="contained"
                disabled={!product.isAvailable}
              >
                Оформити замовлення
              </Button>
              <Button component={RouterLink} to="/callback" variant="outlined">
                Замовити консультацію
              </Button>
            </Stack>
          </Paper>
        </Grid>
      </Grid>
    </Stack>
  );
}
