import webpack from 'webpack';
import HtmlWebpackPlugin from 'html-webpack-plugin';
import autoprefixer from 'autoprefixer';
import path from 'path';
//import theme from './src/styles/theme';


export default {
  resolve: {
    extensions: ['*', '.js', '.jsx', '.json']
  },
  devtool: 'inline-source-map',
  entry: [
    './src/webpack-public-path',
    'webpack-hot-middleware/client?reload=true',
    path.resolve(__dirname, 'src/index.js') 
  ],
  target: 'web',
  output: {
    path: path.resolve(__dirname, 'dist'),
    publicPath: '/',
    filename: 'bundle.js'
  },
  plugins: [
    new webpack.DefinePlugin({
      'process.env.NODE_ENV': JSON.stringify('development'),
      __DEV__: true
    }),
    new webpack.HotModuleReplacementPlugin(),
    new webpack.NoEmitOnErrorsPlugin(),
    new HtmlWebpackPlugin({
      template: 'src/index.ejs',
      minify: {
        removeComments: true,
        collapseWhitespace: true
      },
      inject: true
    }),
    new webpack.LoaderOptionsPlugin({
      minimize: false,
      debug: true,
      noInfo: true,
      options: {
        lessLoader: {
          includePaths: [path.resolve(__dirname, 'src', 'less')]
        },
        context: '/',
        postcss: () => [autoprefixer],
      }
    })
  ],
  module: {
    loaders: [
      {test: /\.jsx?$/, exclude: /node_modules/, loaders: ['babel-loader']},
      { test: /\.(css|less)$/,loaders:['style-loader', 'css-loader?sourceMap', 'postcss-loader', `less-loader?{"sourceMap":true,"modifyVars":${JSON.stringify('')}}`]},
      { test: /\.svg$/,  loader: "file-loader" },
      {test: /\.ico$/, loader: 'file-loader?name=[name].[ext]'},
      {test: /\.(jpe?g|png|gif)$/i, loader: 'file-loader?name=[name].[ext]'}
    ]
  }
};