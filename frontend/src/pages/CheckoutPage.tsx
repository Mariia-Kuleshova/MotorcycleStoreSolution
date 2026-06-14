import Alert from '@mui/material/Alert';
import Autocomplete from '@mui/material/Autocomplete';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import CircularProgress from '@mui/material/CircularProgress';
import Divider from '@mui/material/Divider';
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

function matchesProductSearch(product: Product, query: string): boolean {
  const q = query.trim().toLowerCase();
  if (!q) return true;

  return (
    product.name.toLowerCase().includes(q) ||
    product.brand.toLowerCase().includes(q) ||
    product.category.toLowerCase().includes(q) ||
    product.vin.toLowerCase().includes(q)
  );
}

function getProductLabel(product: Product): string {
  return `${product.brand} ${product.name} — $${product.price.toLocaleString()}`;
}
export function CheckoutPage() {
  const location = useLocation();
  const preselectedId = (location.state as { productId?: number } | null)?.productId;

  const [products, setProducts] = useState<Product[]>([]);
  const [selectedProduct, setSelectedProduct] = useState<Product | null>(null);  const [loading, setLoading] = useState(true);
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
          setSelectedProduct(data.find((p) => p.id === preselectedId) ?? null);
        } else {
          const firstAvailable = data.find((p) => p.isAvailable);
          setSelectedProduct(firstAvailable ?? data[0] ?? null);
        }
      })
      .catch((err) => setError(getApiErrorMessage(err)))
      .finally(() => setLoading(false));
  }, [preselectedId]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!selectedProduct) return;

    setError(null);
    setSubmitting(true);

    try {
      const result = await createWebOrder({
        productId: selectedProduct.id,        customerName: name.trim(),
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
        Заповніть форму — ми зв&apos;яжемося з вами для підтвердження.
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
                <Autocomplete
                  options={products}
                  value={selectedProduct}
                  onChange={(_, value) => setSelectedProduct(value)}
                  getOptionLabel={getProductLabel}
                  getOptionDisabled={(option) => !option.isAvailable}
                  isOptionEqualToValue={(option, value) => option.id === value.id}
                  filterOptions={(options, { inputValue }) =>
                    options.filter((option) => matchesProductSearch(option, inputValue))
                  }
                  noOptionsText="Нічого не знайдено"
                  disabled={submitting}
                  fullWidth
                  renderInput={(params) => (
                    <TextField
                      {...params}
                      label="Мотоцикл"
                      required
                      placeholder="Пошук за назвою, брендом, категорією"
                    />
                  )}
                />

                {selectedProduct && (
                  <Alert severity="info" variant="outlined">
                    Обрано: {selectedProduct.brand} {selectedProduct.name}.{' '}
                    {selectedProduct.isAvailable ? 'В наявності' : 'Немає в наявності'}.
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
                  disabled={submitting || !selectedProduct}                >
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
