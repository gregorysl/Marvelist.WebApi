import webpack from 'webpack';
import path from 'path';
import theme from './src/styles/theme';
const ExtractTextPlugin = require("extract-text-webpack-plugin");
export default {
  debug: true,
  devtool: 'inline-source-map',
  noInfo: true,
  entry: [
    'eventsource-polyfill', // necessary for hot reloading with IE
    'webpack-hot-middleware/client?reload=true', //note that it reloads the page if hot module reloading fails.
    path.resolve(__dirname, 'src/index')
  ],
  target: 'web',
  output: {
    path: __dirname + '/dist', // Note: Physical files are only output by the production build task `npm run build`.
    publicPath: '/',
    filename: 'bundle.js'
  },
  devServer: {
    contentBase: path.resolve(__dirname, 'src')
  },
  plugins: [
    new webpack.HotModuleReplacementPlugin(),
    new webpack.NoErrorsPlugin(),
    new ExtractTextPlugin("css/bundle.css")
  ],
  module: {
    loaders: [
      { test: /\.js$/, include: path.join(__dirname, 'src'), loaders: ['babel']},
      { test: /\.(css|less)$/, loader: ExtractTextPlugin.extract(`css?sourceMap!less-loader?{"sourceMap":true,"modifyVars":${JSON.stringify(theme)}}`) },
      { test: /\.svg$/,  loader: "file-loader" }
    ]
  }
};