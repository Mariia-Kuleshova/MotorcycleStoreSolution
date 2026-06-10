import FilterAltOffIcon from '@mui/icons-material/FilterAltOff';
import SearchIcon from '@mui/icons-material/Search';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import InputAdornment from '@mui/material/InputAdornment';
import MenuItem from '@mui/material/MenuItem';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import {
  defaultProductFilters,
  hasActiveFilters,
  type ProductFilterState,
} from '../../utils/filterProducts';

type ProductFiltersProps = {
  filters: ProductFilterState;
  brands: string[];
  categories: string[];
  disabled?: boolean;
  onChange: (filters: ProductFilterState) => void;
  onReset: () => void;
};

export function ProductFilters({
  filters,
  brands,
  categories,
  disabled,
  onChange,
  onReset,
}: ProductFiltersProps) {
  const update = (patch: Partial<ProductFilterState>) => {
    onChange({ ...filters, ...patch });
  };

  return (
    <Paper sx={{ p: 2 }}>
      <Stack spacing={2}>
        <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', gap: 2 }}>
          <Typography variant="subtitle1" sx={{ fontWeight: 600 }}>
            Фільтри
          </Typography>
          <Button
            size="small"
            startIcon={<FilterAltOffIcon />}
            onClick={onReset}
            disabled={disabled || !hasActiveFilters(filters)}
          >
            Скинути
          </Button>
        </Box>

        <Grid container spacing={2}>
          <Grid size={{ xs: 12, md: 6 }}>
            <TextField
              label="Пошук"
              placeholder="Назва, бренд, категорія або VIN"
              fullWidth
              size="small"
              value={filters.search}
              onChange={(e) => update({ search: e.target.value })}
              disabled={disabled}
              slotProps={{
                input: {
                  startAdornment: (
                    <InputAdornment position="start">
                      <SearchIcon color="action" fontSize="small" />
                    </InputAdornment>
                  ),
                },
              }}
            />
          </Grid>

          <Grid size={{ xs: 12, sm: 6, md: 3 }}>
            <TextField
              select
              label="Бренд"
              fullWidth
              size="small"
              value={filters.brand}
              onChange={(e) => update({ brand: e.target.value })}
              disabled={disabled}
            >
              <MenuItem value="">Усі бренди</MenuItem>
              {brands.map((brand) => (
                <MenuItem key={brand} value={brand}>
                  {brand}
                </MenuItem>
              ))}
            </TextField>
          </Grid>

          <Grid size={{ xs: 12, sm: 6, md: 3 }}>
            <TextField
              select
              label="Категорія"
              fullWidth
              size="small"
              value={filters.category}
              onChange={(e) => update({ category: e.target.value })}
              disabled={disabled}
            >
              <MenuItem value="">Усі категорії</MenuItem>
              {categories.map((category) => (
                <MenuItem key={category} value={category}>
                  {category}
                </MenuItem>
              ))}
            </TextField>
          </Grid>

          <Grid size={{ xs: 12, sm: 6, md: 3 }}>
            <TextField
              select
              label="Наявність"
              fullWidth
              size="small"
              value={filters.availability}
              onChange={(e) => update({ availability: e.target.value as ProductFilterState['availability'] })}
              disabled={disabled}
            >
              <MenuItem value="all">Усі</MenuItem>
              <MenuItem value="available">Лише в наявності</MenuItem>
            </TextField>
          </Grid>

          <Grid size={{ xs: 6, sm: 3, md: 2 }}>
            <TextField
              label="Ціна від"
              type="number"
              fullWidth
              size="small"
              value={filters.priceMin}
              onChange={(e) => update({ priceMin: e.target.value })}
              disabled={disabled}
              slotProps={{ htmlInput: { min: 0 } }}
            />
          </Grid>

          <Grid size={{ xs: 6, sm: 3, md: 2 }}>
            <TextField
              label="Ціна до"
              type="number"
              fullWidth
              size="small"
              value={filters.priceMax}
              onChange={(e) => update({ priceMax: e.target.value })}
              disabled={disabled}
              slotProps={{ htmlInput: { min: 0 } }}
            />
          </Grid>

          <Grid size={{ xs: 6, sm: 3, md: 2 }}>
            <TextField
              label="Рік від"
              type="number"
              fullWidth
              size="small"
              value={filters.yearMin}
              onChange={(e) => update({ yearMin: e.target.value })}
              disabled={disabled}
            />
          </Grid>

          <Grid size={{ xs: 6, sm: 3, md: 2 }}>
            <TextField
              label="Рік до"
              type="number"
              fullWidth
              size="small"
              value={filters.yearMax}
              onChange={(e) => update({ yearMax: e.target.value })}
              disabled={disabled}
            />
          </Grid>
        </Grid>
      </Stack>
    </Paper>
  );
}

export { defaultProductFilters };
