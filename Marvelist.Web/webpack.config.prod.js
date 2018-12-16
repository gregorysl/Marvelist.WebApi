import webpack from "webpack";
import WebpackMd5Hash from "webpack-md5-hash";
import HtmlWebpackPlugin from "html-webpack-plugin";
import MiniCssExtractPlugin from "mini-css-extract-plugin";
import path from "path";
import theme from "./src/styles/theme";

import UglifyJsPlugin from "uglifyjs-webpack-plugin";

const GLOBALS = {
	"process.env.NODE_ENV": JSON.stringify("production"),
	__DEV__: false
};

export default {
	mode: "production",
	resolve: {
		extensions: ["*", ".js", ".jsx", ".json"]
	},
	devtool: "source-map",
	entry: path.resolve(__dirname, "src/index"),
	target: "web",
	output: {
		path: path.resolve(__dirname, "../Marvelist.API/"),
		publicPath: "/",
		filename: "[name].[chunkhash].js"
	},
	plugins: [
		new WebpackMd5Hash(),
		new webpack.DefinePlugin(GLOBALS),
		new HtmlWebpackPlugin({
			template: "src/index.ejs",
			favicon: "src/favicon.ico",
			minify: {
				removeComments: true,
				collapseWhitespace: true,
				removeRedundantAttributes: true,
				useShortDoctype: true,
				removeEmptyAttributes: true,
				removeStyleLinkTypeAttributes: true,
				keepClosingSlash: true,
				minifyJS: true,
				minifyCSS: true,
				minifyURLs: true
			},
			inject: true
		})
	],

	optimization: {
		minimizer: [
			new UglifyJsPlugin({
				sourceMap: true
			})
		]
	},
	module: {
		rules: [
			{
				test: /\.jsx?$/,
				exclude: /node_modules/,
				use: ["babel-loader"]
			},
			{
				test: /\.eot(\?v=\d+.\d+.\d+)?$/,
				use: [
					{
						loader: "url-loader",
						options: {
							name: "[name].[ext]"
						}
					}
				]
			},
			{
				test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/,
				use: [
					{
						loader: "url-loader",
						options: {
							limit: 10000,
							mimetype: "application/font-woff",
							name: "[name].[ext]"
						}
					}
				]
			},
			{
				test: /\.[ot]tf(\?v=\d+.\d+.\d+)?$/,
				use: [
					{
						loader: "url-loader",
						options: {
							limit: 10000,
							mimetype: "application/octet-stream",
							name: "[name].[ext]"
						}
					}
				]
			},
			{
				test: /\.svg(\?v=\d+\.\d+\.\d+)?$/,
				use: [
					{
						loader: "url-loader",
						options: {
							limit: 10000,
							mimetype: "image/svg+xml",
							name: "[name].[ext]"
						}
					}
				]
			},
			{
				test: /\.(jpe?g|png|gif|ico)$/i,
				use: [
					{
						loader: "file-loader",
						options: {
							name: "[name].[ext]"
						}
					}
				]
			},
			{
				test: /(\.css|\.less)$/,
				use: [
					MiniCssExtractPlugin.loader,
					"css-loader",
					{
						loader: "less-loader",
						options: {
							modifyVars: theme,
							sourceMap: true
						}
					}
				]
			}
		]
	}
};
