const CracoAntDesignPlugin = require("craco-antd");
const theme = require("./src/styles/theme.json");

module.exports = {
  plugins: [
    {
      plugin: CracoAntDesignPlugin,
      options: {
        customizeTheme: theme,
      },
    },
  ],
};
