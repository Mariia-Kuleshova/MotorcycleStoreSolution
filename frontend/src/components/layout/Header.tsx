import TwoWheelerIcon from '@mui/icons-material/TwoWheeler';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Container from '@mui/material/Container';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import { NavLink } from 'react-router-dom';

const links = [
  { to: '/', label: 'Головна' },
  { to: '/catalog', label: 'Каталог' },
  { to: '/checkout', label: 'Замовлення' },
  { to: '/callback', label: 'Зворотний дзвінок' },
] as const;

export function Header() {
  return (
    <AppBar position="sticky" elevation={0} sx={{ bgcolor: '#1a1a24', borderBottom: '1px solid #2a2a36' }}>
      <Container maxWidth="lg">
        <Toolbar disableGutters sx={{ gap: 2, py: 0.5 }}>
          <TwoWheelerIcon sx={{ color: 'primary.main', mr: 0.5 }} />
          <Typography
            component={NavLink}
            to="/"
            variant="h6"
            sx={{ flexGrow: 1, color: 'inherit', textDecoration: 'none', fontWeight: 700 }}
          >
            Motorcycle Store
          </Typography>
          <Box sx={{ display: 'flex', gap: 1, flexWrap: 'wrap' }}>
            {links.map(({ to, label }) => (
              <NavLink key={to} to={to} style={{ textDecoration: 'none' }}>
                {({ isActive }) => (
                  <Button
                    sx={{
                      minWidth: 'auto',
                      color: isActive ? 'primary.main' : 'inherit',
                      fontWeight: isActive ? 600 : 400,
                    }}
                  >
                    {label}
                  </Button>
                )}
              </NavLink>
            ))}
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}
