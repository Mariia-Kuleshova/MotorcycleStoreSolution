import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import CardActionArea from '@mui/material/CardActionArea';
import CardContent from '@mui/material/CardContent';
import Chip from '@mui/material/Chip';
import Grid from '@mui/material/Grid';
import Stack from '@mui/material/Stack';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import { useMemo, useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';
import { mockProducts } from '../services/mockProducts';

export function CatalogPage() {
  const [search, setSearch] = useState('');

  const filtered = useMemo(() => {
    const q = search.trim().toLowerCase();
    if (!q) return mockProducts;
    return mockProducts.filter(
      (p) =>
        p.name.toLowerCase().includes(q) ||
        p.brand.toLowerCase().includes(q) ||
        p.category.toLowerCase().includes(q) ||
        p.vin.toLowerCase().includes(q),
    );
  }, [search]);

  return (
    <Stack spacing={3}>
      <Box>
        <Typography variant="h4" component="h1" gutterBottom sx={{ fontWeight: 700 }}>
          Каталог мотоциклів
        </Typography>
        <Typography color="text.secondary">
          {filtered.length} з {mockProducts.length} моделей (mock-дані)
        </Typography>
      </Box>

      <TextField
        label="Пошук за назвою, брендом, категорією або VIN"
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        fullWidth
      />

      <Grid container spacing={2}>
        {filtered.map((product) => (
          <Grid key={product.id} size={{ xs: 12, sm: 6, md: 4 }}>
            <Card sx={{ height: '100%' }}>
              <CardActionArea component={RouterLink} to={`/catalog/${product.id}`} sx={{ height: '100%' }}>
                <CardContent>
                  <Stack direction="row" spacing={1} sx={{ mb: 1 }}>
                    <Chip label={product.category} size="small" />
                    <Chip
                      label={product.isAvailable ? 'В наявності' : 'Немає'}
                      size="small"
                      color={product.isAvailable ? 'success' : 'default'}
                    />
                  </Stack>
                  <Typography variant="overline" color="primary">
                    {product.brand}
                  </Typography>
                  <Typography variant="h6">{product.name}</Typography>
                  <Typography variant="body2" color="text.secondary">
                    {product.modelYear} · залишок: {product.inventory?.quantity ?? 0}
                  </Typography>
                  <Typography variant="h6" color="primary.main" sx={{ mt: 1 }}>
                    ${product.price.toLocaleString()}
                  </Typography>
                </CardContent>
              </CardActionArea>
            </Card>
          </Grid>
        ))}
      </Grid>

      {filtered.length === 0 && (
        <Typography color="text.secondary" align="center">
          За вашим запитом нічого не знайдено.
        </Typography>
      )}
    </Stack>
  );
}
