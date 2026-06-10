import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import { useState } from 'react';
import { getProductImageUrls } from '../../utils/productImageUrls';

type ProductImageGalleryProps = {
  imageUrl?: string | null;
  alt: string;
  fallbackLabel?: string;
  mainHeight?: number | { xs?: number; md?: number };
};

export function ProductImageGallery({
  imageUrl,
  alt,
  fallbackLabel,
  mainHeight = { xs: 200, md: 280 },
}: ProductImageGalleryProps) {
  const urls = getProductImageUrls(imageUrl);
  const [activeIndex, setActiveIndex] = useState(0);

  if (urls.length === 0) {
    return (
      <Box
        sx={{
          height: mainHeight,
          bgcolor: '#2a2a34',
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
        }}
      >
        <Typography color="text.secondary">{fallbackLabel ?? 'Немає фото'}</Typography>
      </Box>
    );
  }

  const safeIndex = Math.min(activeIndex, urls.length - 1);

  return (
    <Box>
      <Box
        component="img"
        src={urls[safeIndex]}
        alt={alt}
        sx={{
          width: '100%',
          height: mainHeight,
          objectFit: 'cover',
          display: 'block',
          bgcolor: '#2a2a34',
        }}
      />
      {urls.length > 1 && (
        <Grid container spacing={1} sx={{ mt: 1 }}>
          {urls.map((url, index) => (
            <Grid key={url} size={{ xs: 4, sm: 3 }}>
              <Box
                component="img"
                src={url}
                alt={`${alt} ${index + 1}`}
                onClick={() => setActiveIndex(index)}
                sx={{
                  width: '100%',
                  height: 72,
                  objectFit: 'cover',
                  cursor: 'pointer',
                  borderRadius: 1,
                  border: 2,
                  borderColor: index === safeIndex ? 'primary.main' : 'transparent',
                  opacity: index === safeIndex ? 1 : 0.75,
                }}
              />
            </Grid>
          ))}
        </Grid>
      )}
    </Box>
  );
}
