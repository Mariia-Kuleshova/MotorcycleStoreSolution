import TwoWheelerIcon from '@mui/icons-material/TwoWheeler';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Container from '@mui/material/Container';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import { NavLink } from 'react-router-dom';

const navItems = [
  { to: '/catalog', label: 'Каталог' },
  { to: '/checkout', label: 'Замовлення' },
  { to: '/callback', label: 'Дзвінок' },
] as const;

export function Header() {
  return (
    <AppBar position="sticky">
      <Container maxWidth="lg">
        <Toolbar disableGutters sx={{ gap: 1, minHeight: 56 }}>
          <TwoWheelerIcon sx={{ mr: 0.5, color: 'primary.main' }} />
          <Typography
            variant="h6"
            component={NavLink}
            to="/"
            sx={{ flexGrow: 1, color: 'inherit', textDecoration: 'none' }}
          >
            MotoUA
          </Typography>
          <Box sx={{ display: 'flex', gap: 0.5, flexWrap: 'wrap' }}>
            {navItems.map(({ to, label }) => (
              <NavLink key={to} to={to} style={{ textDecoration: 'none' }}>
                {({ isActive }) => (
                  <Button
                    color="inherit"
                    size="small"
                    variant={isActive ? 'outlined' : 'text'}
                    sx={{
                      borderColor: isActive ? 'primary.main' : 'transparent',
                      color: isActive ? 'primary.main' : 'inherit',
                      fontWeight: isActive ? 700 : 400,
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
