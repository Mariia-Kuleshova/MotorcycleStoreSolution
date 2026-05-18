import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Chip from '@mui/material/Chip';
import Divider from '@mui/material/Divider';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import { Link as RouterLink, useParams } from 'react-router-dom';
import { getMockProductById } from '../services/mockProducts';

export function ProductDetailPage() {
  const { id } = useParams<{ id: string }>();
  const product = getMockProductById(Number(id));

  if (!product) {
    return (
      <Stack spacing={2} sx={{ alignItems: 'flex-start' }}>
        <Typography variant="h5">Мотоцикл не знайдено</Typography>
        <Button component={RouterLink} to="/catalog" startIcon={<ArrowBackIcon />}>
          До каталогу
        </Button>
      </Stack>
    );
  }

  const qty = product.inventory?.quantity ?? 0;

  return (
    <Stack spacing={3}>
      <Button component={RouterLink} to="/catalog" startIcon={<ArrowBackIcon />} sx={{ alignSelf: 'flex-start' }}>
        Назад до каталогу
      </Button>

      <Box
        sx={{
          p: 3,
          borderRadius: 3,
          bgcolor: 'background.paper',
          border: '1px solid #2a2a36',
        }}
      >
        <Stack direction="row" spacing={1} sx={{ mb: 2 }}>
          <Chip label={product.category} />
          <Chip label={product.brand} variant="outlined" />
          <Chip
            label={product.isAvailable ? `В наявності: ${qty} шт.` : 'Немає в наявності'}
            color={product.isAvailable ? 'success' : 'default'}
          />
        </Stack>

        <Typography variant="h4" component="h1" gutterBottom sx={{ fontWeight: 700 }}>
          {product.name}
        </Typography>
        <Typography variant="h5" color="primary.main" gutterBottom>
          ${product.price.toLocaleString()}
        </Typography>

        <Divider sx={{ my: 2 }} />

        <Stack spacing={1}>
          <Typography><strong>Рік:</strong> {product.modelYear}</Typography>
          <Typography><strong>VIN:</strong> {product.vin}</Typography>
          <Typography><strong>Постачальник:</strong> {product.supplierName}</Typography>
          {product.description && (
            <Typography sx={{ mt: 1 }}>{product.description}</Typography>
          )}
        </Stack>

        <Stack direction="row" spacing={2} sx={{ mt: 3 }}>
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
      </Box>
    </Stack>
  );
}
