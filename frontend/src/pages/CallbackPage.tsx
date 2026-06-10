import Alert from '@mui/material/Alert';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Divider from '@mui/material/Divider';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import { useState } from 'react';
import { getApiErrorMessage } from '../services/apiClient';
import { createCallbackRequest } from '../services/callbackService';

export function CallbackPage() {
  const [name, setName] = useState('');
  const [phone, setPhone] = useState('');
  const [preferredTime, setPreferredTime] = useState('');
  const [message, setMessage] = useState('');
  const [submitting, setSubmitting] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [requestId, setRequestId] = useState<number | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    setSubmitting(true);

    try {
      const result = await createCallbackRequest({
        name: name.trim(),
        phone: phone.trim(),
        preferredTime: preferredTime.trim() || undefined,
        message: message.trim() || undefined,
      });
      setRequestId(result.id);
    } catch (err) {
      setError(getApiErrorMessage(err));
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Box sx={{ maxWidth: 520 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Зворотний дзвінок
      </Typography>
      <Typography variant="body2" color="text.secondary" sx={{ mb: 3 }}>
        Залиште контакти — менеджер побачить заявку в десктопі на вкладці «Дзвінки».
      </Typography>

      {error && (
        <Alert severity="error" sx={{ mb: 2 }}>
          {error}
        </Alert>
      )}

      {requestId !== null ? (
        <Alert severity="success">
          Запит №{requestId} прийнято. Дякуємо! Ми зателефонуємо найближчим часом.
        </Alert>
      ) : (
        <Paper sx={{ p: 3 }}>
          <Typography variant="subtitle1" sx={{ fontWeight: 600 }}>
            Контактні дані
          </Typography>
          <Divider sx={{ my: 1.5, mb: 2 }} />

          <Box component="form" onSubmit={handleSubmit}>
            <Stack spacing={2}>
              <TextField
                label="Ім'я"
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
                label="Зручний час для дзвінка"
                fullWidth
                placeholder="Наприклад: 14:00–16:00"
                value={preferredTime}
                onChange={(e) => setPreferredTime(e.target.value)}
                disabled={submitting}
              />
              <TextField
                label="Повідомлення"
                fullWidth
                multiline
                rows={3}
                value={message}
                onChange={(e) => setMessage(e.target.value)}
                disabled={submitting}
              />
              <Button type="submit" variant="contained" size="large" fullWidth disabled={submitting}>
                {submitting ? 'Надсилання…' : 'Замовити дзвінок'}
              </Button>
            </Stack>
          </Box>
        </Paper>
      )}
    </Box>
  );
}
