import Alert from '@mui/material/Alert';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import { useState } from 'react';

export function CallbackPage() {
  const [name, setName] = useState('');
  const [phone, setPhone] = useState('');
  const [preferredTime, setPreferredTime] = useState('');
  const [message, setMessage] = useState('');
  const [submitted, setSubmitted] = useState(false);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setSubmitted(true);
  };

  return (
    <Stack spacing={3} sx={{ maxWidth: 560 }}>
      <Box>
        <Typography variant="h4" component="h1" gutterBottom sx={{ fontWeight: 700 }}>
          Зворотний дзвінок
        </Typography>
        <Typography color="text.secondary">
          Залиште контакти — менеджер зв&apos;яжеться з вами. Поки що лише mock (без API).
        </Typography>
      </Box>

      {submitted ? (
        <Alert severity="success">Дякуємо! Ваш запит збережено локально для демонстрації.</Alert>
      ) : (
        <Box component="form" onSubmit={handleSubmit}>
          <Stack spacing={2}>
            <TextField label="Ім'я" value={name} onChange={(e) => setName(e.target.value)} required fullWidth />
            <TextField label="Телефон" value={phone} onChange={(e) => setPhone(e.target.value)} required fullWidth />
            <TextField
              label="Зручний час для дзвінка"
              value={preferredTime}
              onChange={(e) => setPreferredTime(e.target.value)}
              placeholder="Наприклад: 14:00–16:00"
              fullWidth
            />
            <TextField
              label="Повідомлення"
              value={message}
              onChange={(e) => setMessage(e.target.value)}
              multiline
              rows={4}
              fullWidth
            />
            <Button type="submit" variant="contained" size="large">
              Замовити дзвінок
            </Button>
          </Stack>
        </Box>
      )}
    </Stack>
  );
}
