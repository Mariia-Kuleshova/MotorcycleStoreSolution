import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';

export function Footer() {
  return (
    <Box
      component="footer"
      sx={{
        mt: 5,
        py: 2.5,
        bgcolor: '#1a1a22',
        borderTop: 1,
        borderColor: 'divider',
      }}
    >
      <Container maxWidth="lg">
        <Typography variant="body2" color="text.secondary" align="center">
          MotoUA — веб-частина дипломного проєкту
        </Typography>
        <Typography variant="caption" color="text.secondary" align="center" sx={{ mt: 0.5, display: 'block' }}>
          © {new Date().getFullYear()}
        </Typography>
      </Container>
    </Box>
  );
}
