import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import { getPrimaryProductImageUrl } from '../../utils/productImageUrls';

type ProductImageProps = {
  imageUrl?: string | null;
  alt: string;
  fallbackLabel?: string;
  height?: number | { xs?: number; md?: number };
};

export function ProductImage({ imageUrl, alt, fallbackLabel, height = 100 }: ProductImageProps) {
  const src = getPrimaryProductImageUrl(imageUrl);

  if (src) {
    return (
      <Box
        component="img"
        src={src}
        alt={alt}
        sx={{
          width: '100%',
          height,
          objectFit: 'cover',
          display: 'block',
          bgcolor: '#2a2a34',
        }}
      />
    );
  }

  return (
    <Box
      sx={{
        height,
        bgcolor: '#2a2a34',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        borderBottom: 1,
        borderColor: 'divider',
      }}
    >
      <Typography color="text.secondary" variant="body2" align="center">
        {fallbackLabel ?? 'Немає фото'}
      </Typography>
    </Box>
  );
}
