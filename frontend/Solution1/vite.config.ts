import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      // Прокси для всех запросов, начинающихся с "/api", на наш бэкенд (http://localhost:5123)
      "/api": {
        target: "http://localhost:5123",
        changeOrigin: true
      }
    }
  }
});

