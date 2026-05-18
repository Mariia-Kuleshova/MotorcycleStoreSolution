import Alert from '@mui/material/Alert';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import MenuItem from '@mui/material/MenuItem';
import Stack from '@mui/material/Stack';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import { useState } from 'react';
import { useLocation } from 'react-router-dom';
import { getMockProductById, mockProducts } from '../services/mockProducts';

export function CheckoutPage() {
  const location = useLocation();
  const preselectedId = (location.state as { productId?: number } | null)?.productId;

  const [productId, setProductId] = useState(preselectedId ?? mockProducts[0]?.id ?? 0);
  const [name, setName] = useState('');
  const [phone, setPhone] = useState('');
  const [email, setEmail] = useState('');
  const [comment, setComment] = useState('');
  const [submitted, setSubmitted] = useState(false);

  const product = getMockProductById(productId);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setSubmitted(true);
  };

  return (
    <Stack spacing={3} sx={{ maxWidth: 560 }}>
      <Box>
        <Typography variant="h4" component="h1" gutterBottom sx={{ fontWeight: 700 }}>
          Оформлення замовлення
        </Typography>
        <Typography color="text.secondary">
          Демо-форма. Дані не відправляються на сервер (mock).
        </Typography>
      </Box>

      {submitted ? (
        <Alert severity="success">
          Заявку прийнято (локально). Після підключення API замовлення збережеться в системі менеджерів.
        </Alert>
      ) : (
        <Box component="form" onSubmit={handleSubmit}>
          <Stack spacing={2}>
            <TextField
              select
              label="Мотоцикл"
              value={productId}
              onChange={(e) => setProductId(Number(e.target.value))}
              fullWidth
              required
            >
              {mockProducts.map((p) => (
                <MenuItem key={p.id} value={p.id} disabled={!p.isAvailable}>
                  {p.brand} {p.name} — ${p.price.toLocaleString()}
                </MenuItem>
              ))}
            </TextField>

            {product && (
              <Typography variant="body2" color="text.secondary">
                Обрано: {product.brand} {product.name}, залишок: {product.inventory?.quantity ?? 0} шт.
              </Typography>
            )}

            <TextField label="ПІБ" value={name} onChange={(e) => setName(e.target.value)} required fullWidth />
            <TextField label="Телефон" value={phone} onChange={(e) => setPhone(e.target.value)} required fullWidth />
            <TextField label="Email" type="email" value={email} onChange={(e) => setEmail(e.target.value)} fullWidth />
            <TextField
              label="Коментар"
              value={comment}
              onChange={(e) => setComment(e.target.value)}
              multiline
              rows={3}
              fullWidth
            />
            <Button type="submit" variant="contained" size="large">
              Надіслати заявку
            </Button>
          </Stack>
        </Box>
      )}
    </Stack>
  );
}
