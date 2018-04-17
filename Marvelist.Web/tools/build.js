/* eslint-disable no-console */
import webpack from 'webpack';
import config from '../webpack.config.prod';

process.env.NODE_ENV = 'production';
console.info('Generating minified bundle. This will take a moment...');

webpack(config).run((error, stats) => {
  if (error) {
    console.error(error);
    return 1;
  }
  const jsonStats = stats.toJson();

  if (jsonStats.hasErrors) {
    return jsonStats.errors.map(error => console.error(error));
  }

  if (jsonStats.hasWarnings) {
    console.warn('Webpack generated the following warnings: ');
    jsonStats.warnings.map(warning => console.warn(warning));
  }

  console.log(`Webpack stats: ${stats}`);
  console.log('Your app is compiled in production mode in ../Marvelist.API/. It\'s ready to roll!');

  return 0;
});
