import Alert from '@mui/material/Alert';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import CircularProgress from '@mui/material/CircularProgress';
import Divider from '@mui/material/Divider';
import MenuItem from '@mui/material/MenuItem';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import { getApiErrorMessage } from '../services/apiClient';
import { createWebOrder } from '../services/orderService';
import { fetchProducts } from '../services/productService';
import type { Product } from '../types/product';

export function CheckoutPage() {
  const location = useLocation();
  const preselectedId = (location.state as { productId?: number } | null)?.productId;

  const [products, setProducts] = useState<Product[]>([]);
  const [productId, setProductId] = useState<number>(0);
  const [loading, setLoading] = useState(true);
  const [submitting, setSubmitting] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [name, setName] = useState('');
  const [phone, setPhone] = useState('');
  const [email, setEmail] = useState('');
  const [comment, setComment] = useState('');
  const [orderId, setOrderId] = useState<number | null>(null);

  useEffect(() => {
    fetchProducts()
      .then((data) => {
        setProducts(data);
        if (preselectedId && data.some((p) => p.id === preselectedId)) {
          setProductId(preselectedId);
        } else {
          const firstAvailable = data.find((p) => p.isAvailable);
          if (firstAvailable) setProductId(firstAvailable.id);
          else if (data.length > 0) setProductId(data[0].id);
        }
      })
      .catch((err) => setError(getApiErrorMessage(err)))
      .finally(() => setLoading(false));
  }, [preselectedId]);

  const product = products.find((p) => p.id === productId);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    setSubmitting(true);

    try {
      const result = await createWebOrder({
        productId,
        customerName: name.trim(),
        phone: phone.trim(),
        email: email.trim() || undefined,
        comment: comment.trim() || undefined,
      });
      setOrderId(result.orderId);
    } catch (err) {
      setError(getApiErrorMessage(err));
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Box sx={{ maxWidth: 520 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Оформлення замовлення
      </Typography>
      <Typography variant="body2" color="text.secondary" sx={{ mb: 3 }}>
        Заповніть форму — заявка одразу потрапить до менеджерів у десктопній програмі.
      </Typography>

      {loading && (
        <Box sx={{ display: 'flex', justifyContent: 'center', py: 4 }}>
          <CircularProgress />
        </Box>
      )}

      {error && (
        <Alert severity="error" sx={{ mb: 2 }}>
          {error}
        </Alert>
      )}

      {orderId !== null ? (
        <Alert severity="success">
          Дякуємо! Заявку №{orderId} прийнято. Менеджер зв&apos;яжеться з вами найближчим часом.
        </Alert>
      ) : (
        !loading && (
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
                  disabled={submitting}
                >
                  {products.map((p) => (
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

                <TextField
                  label="ПІБ"
                  fullWidth
                  required
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  disabled={submitting}
                />
                <TextField
                  label="Телефон"
                  fullWidth
                  required
                  value={phone}
                  onChange={(e) => setPhone(e.target.value)}
                  disabled={submitting}
                />
                <TextField
                  label="Email"
                  type="email"
                  fullWidth
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                  disabled={submitting}
                />
                <TextField
                  label="Коментар"
                  fullWidth
                  multiline
                  rows={3}
                  value={comment}
                  onChange={(e) => setComment(e.target.value)}
                  disabled={submitting}
                />
                <Button
                  type="submit"
                  variant="contained"
                  size="large"
                  fullWidth
                  disabled={submitting || !productId}
                >
                  {submitting ? 'Надсилання…' : 'Надіслати заявку'}
                </Button>
              </Stack>
            </Box>
          </Paper>
        )
      )}
    </Box>
  );
}
