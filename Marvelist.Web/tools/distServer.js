import browserSync from 'browser-sync';
import historyApiFallback from 'connect-history-api-fallback';
console.log('Opening production build...');
browserSync({
  port: 4000,
  ui: {
    port: 4001
  },
  server: {
    baseDir: 'dist'
  },

  files: [
    'src/*.html'
  ],

  middleware: [historyApiFallback()]
});
