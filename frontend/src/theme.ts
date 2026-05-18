import { createTheme } from '@mui/material/styles';

export const theme = createTheme({
  palette: {
    mode: 'dark',
    primary: {
      main: '#ff7043',
      light: '#ff8a65',
      dark: '#e64a19',
      contrastText: '#1a1a22',
    },
    secondary: {
      main: '#4a4a58',
      light: '#6b6b7b',
      dark: '#2d2d38',
    },
    background: {
      default: '#141418',
      paper: '#1e1e26',
    },
    text: {
      primary: '#ececf1',
      secondary: '#a8a8b5',
    },
    divider: '#2f2f3a',
  },
  typography: {
    fontFamily: '"Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif',
    h4: { fontWeight: 600 },
    h6: { fontWeight: 600 },
    button: { textTransform: 'none', fontWeight: 600 },
  },
  shape: {
    borderRadius: 8,
  },
  components: {
    MuiCard: {
      defaultProps: { elevation: 2 },
      styleOverrides: {
        root: {
          backgroundImage: 'none',
          border: '1px solid #2f2f3a',
        },
      },
    },
    MuiPaper: {
      styleOverrides: {
        root: {
          backgroundImage: 'none',
        },
        outlined: {
          borderColor: '#2f2f3a',
        },
      },
    },
    MuiAppBar: {
      styleOverrides: {
        root: {
          backgroundColor: '#1a1a22',
          backgroundImage: 'none',
          borderBottom: '1px solid #2f2f3a',
          boxShadow: 'none',
        },
      },
    },
    MuiChip: {
      styleOverrides: {
        outlined: {
          borderColor: '#3d3d4a',
        },
      },
    },
  },
});
