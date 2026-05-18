import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';

export function Footer() {
  return (
    <Box
      component="footer"
      sx={{
        mt: 'auto',
        py: 3,
        borderTop: '1px solid #2a2a36',
        bgcolor: '#1a1a24',
      }}
    >
      <Container maxWidth="lg">
        <Typography variant="body2" color="text.secondary" align="center">
          © {new Date().getFullYear()} Motorcycle Store — дипломний проєкт. Усі права захищені.
        </Typography>
      </Container>
    </Box>
  );
}
