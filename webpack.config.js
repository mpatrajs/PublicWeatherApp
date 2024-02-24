const path = require('path');

module.exports = {
  // Entry point should be the main TypeScript file for your React app
  entry: './wwwroot/js/app.tsx',
  output: {
    // Output should be directed to the 'wwwroot/dist' directory
    path: path.resolve(__dirname, 'wwwroot/dist'),
    filename: 'bundle.js'
  },
  module: {
    rules: [
      {
        // Use ts-loader for TypeScript files
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/
      },
      {
        // Add babel-loader for JSX/TSX files
        test: /\.jsx?$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: {
            presets: ['@babel/preset-env', '@babel/preset-react']
          }
        }
      }
    ]
  },
  resolve: {
    // Resolve these extensions
    extensions: ['.tsx', '.ts', '.js', '.jsx']
  },
  devtool: 'source-map'
};
