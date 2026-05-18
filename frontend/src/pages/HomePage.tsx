import TwoWheelerIcon from '@mui/icons-material/TwoWheeler';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Grid from '@mui/material/Grid';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import { Link as RouterLink } from 'react-router-dom';
import { mockProducts } from '../services/mockProducts';

const featured = mockProducts.filter((p) => p.isAvailable).slice(0, 3);

export function HomePage() {
  return (
    <Stack spacing={5}>
      <Box
        sx={{
          textAlign: 'center',
          py: { xs: 4, md: 6 },
          px: 2,
          borderRadius: 3,
          background: 'linear-gradient(135deg, #1a1a24 0%, #2d1f1a 50%, #1a1a24 100%)',
          border: '1px solid #2a2a36',
        }}
      >
        <TwoWheelerIcon sx={{ fontSize: 56, color: 'primary.main', mb: 2 }} />
        <Typography variant="h3" component="h1" gutterBottom sx={{ fontWeight: 700 }}>
          Магазин мотоциклів
        </Typography>
        <Typography variant="h6" color="text.secondary" sx={{ maxWidth: 560, mx: 'auto', mb: 3 }}>
          Оберіть мотоцикл мрії — спорт, круїзер, adventure та інші категорії в одному каталозі.
        </Typography>
        <Stack direction="row" spacing={2} sx={{ justifyContent: 'center', flexWrap: 'wrap' }}>
          <Button component={RouterLink} to="/catalog" variant="contained" size="large">
            Перейти до каталогу
          </Button>
          <Button component={RouterLink} to="/callback" variant="outlined" size="large">
            Замовити дзвінок
          </Button>
        </Stack>
      </Box>

      <Box>
        <Typography variant="h5" gutterBottom sx={{ fontWeight: 600 }}>
          Популярні моделі
        </Typography>
        <Grid container spacing={2}>
          {featured.map((product) => (
            <Grid key={product.id} size={{ xs: 12, sm: 6, md: 4 }}>
              <Card sx={{ height: '100%', bgcolor: 'background.paper' }}>
                <CardContent>
                  <Typography variant="overline" color="primary">
                    {product.brand}
                  </Typography>
                  <Typography variant="h6">{product.name}</Typography>
                  <Typography variant="body2" color="text.secondary" gutterBottom>
                    {product.category} · {product.modelYear}
                  </Typography>
                  <Typography variant="h6" color="primary.main">
                    ${product.price.toLocaleString()}
                  </Typography>
                  <Button
                    component={RouterLink}
                    to={`/catalog/${product.id}`}
                    size="small"
                    sx={{ mt: 1 }}
                  >
                    Детальніше
                  </Button>
                </CardContent>
              </Card>
            </Grid>
          ))}
        </Grid>
      </Box>
    </Stack>
  );
}
