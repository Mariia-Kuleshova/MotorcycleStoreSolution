import Alert from '@mui/material/Alert';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Divider from '@mui/material/Divider';
import MenuItem from '@mui/material/MenuItem';
import Paper from '@mui/material/Paper';
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
    <Box sx={{ maxWidth: 520 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Оформлення замовлення
      </Typography>
      <Typography variant="body2" color="text.secondary" sx={{ mb: 3 }}>
        Заповніть форму. Після підключення API заявка потрапить до системи менеджерів.
      </Typography>

      {submitted ? (
        <Alert severity="success">Дякуємо! Заявку збережено для перевірки інтерфейсу.</Alert>
      ) : (
        <Paper sx={{ p: 3 }}>
          <Typography variant="subtitle1" sx={{ fontWeight: 600 }}>
            Дані покупця
          </Typography>
          <Divider sx={{ my: 1.5, mb: 2 }} />

          <Box component="form" onSubmit={handleSubmit}>
            <Stack spacing={2}>
              <TextField
                select
                label="Мотоцикл"
                fullWidth
                value={productId}
                onChange={(e) => setProductId(Number(e.target.value))}
                required
              >
                {mockProducts.map((p) => (
                  <MenuItem key={p.id} value={p.id} disabled={!p.isAvailable}>
                    {p.brand} {p.name} — ${p.price.toLocaleString()}
                  </MenuItem>
                ))}
              </TextField>

              {product && (
                <Alert severity="info" variant="outlined">
                  Обрано: {product.brand} {product.name}. На складі: {product.inventory?.quantity ?? 0} шт.
                </Alert>
              )}

              <TextField label="ПІБ" fullWidth required value={name} onChange={(e) => setName(e.target.value)} />
              <TextField label="Телефон" fullWidth required value={phone} onChange={(e) => setPhone(e.target.value)} />
              <TextField label="Email" type="email" fullWidth value={email} onChange={(e) => setEmail(e.target.value)} />
              <TextField
                label="Коментар"
                fullWidth
                multiline
                rows={3}
                value={comment}
                onChange={(e) => setComment(e.target.value)}
              />
              <Button type="submit" variant="contained" size="large" fullWidth>
                Надіслати заявку
              </Button>
            </Stack>
          </Box>
        </Paper>
      )}
    </Box>
  );
}
