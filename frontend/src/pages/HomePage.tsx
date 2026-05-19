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
import { useEffect, useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';
import { getApiErrorMessage } from '../services/apiClient';
import { fetchProducts } from '../services/productService';
import type { Product } from '../types/product';

export function HomePage() {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    fetchProducts()
      .then(setProducts)
      .catch((err) => setError(getApiErrorMessage(err)))
      .finally(() => setLoading(false));
  }, []);

  const featured = products.filter((p) => p.isAvailable).slice(0, 3);

  return (
    <Stack spacing={4}>
      <Paper
        elevation={0}
        sx={{
          p: { xs: 3, md: 4 },
          bgcolor: 'background.paper',
          borderLeft: 4,
          borderColor: 'primary.main',
          borderRadius: 2,
        }}
      >
        <Typography variant="h4" component="h1" gutterBottom>
          Ласкаво просимо
        </Typography>
        <Typography sx={{ mb: 3, maxWidth: 600, opacity: 0.95 }}>
          Оберіть мотоцикл у каталозі, перегляньте характеристики та залиште заявку на покупку або
          консультацію з менеджером.
        </Typography>
        <Stack direction="row" spacing={1} sx={{ flexWrap: 'wrap', gap: 1 }}>
          <Button component={RouterLink} to="/catalog" variant="contained" color="primary">
            Перейти до каталогу
          </Button>
          <Button component={RouterLink} to="/callback" variant="outlined" color="primary">
            Зворотний дзвінок
          </Button>
        </Stack>
      </Paper>

      <Box>
        <Typography variant="h6" gutterBottom>
          Популярні моделі
        </Typography>

        {loading && (
          <Box sx={{ display: 'flex', justifyContent: 'center', py: 4 }}>
            <CircularProgress />
          </Box>
        )}

        {error && <Alert severity="error">{error}</Alert>}

        {!loading && !error && featured.length === 0 && (
          <Typography color="text.secondary">Немає доступних моделей.</Typography>
        )}

        {!loading && !error && featured.length > 0 && (
          <Grid container spacing={2}>
            {featured.map((product) => (
              <Grid key={product.id} size={{ xs: 12, sm: 6, md: 4 }}>
                <Card sx={{ height: '100%', display: 'flex', flexDirection: 'column' }}>
                  <Box
                    sx={{
                      height: 100,
                      bgcolor: '#2a2a34',
                      display: 'flex',
                      alignItems: 'center',
                      justifyContent: 'center',
                    }}
                  >
                    <Typography color="text.secondary" variant="body2">
                      {product.brand}
                    </Typography>
                  </Box>
                  <CardContent sx={{ flexGrow: 1 }}>
                    <Chip label={product.category} size="small" sx={{ mb: 1 }} />
                    <Typography variant="subtitle1" sx={{ fontWeight: 600 }}>
                      {product.name}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                      {product.modelYear} р. · ${product.price.toLocaleString()}
                    </Typography>
                  </CardContent>
                  <CardActions>
                    <Button component={RouterLink} to={`/catalog/${product.id}`} size="small">
                      Детальніше
                    </Button>
                  </CardActions>
                </Card>
              </Grid>
            ))}
          </Grid>
        )}
      </Box>
    </Stack>
  );
}
