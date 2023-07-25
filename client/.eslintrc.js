module.exports = {
  root: true,
  env: {
    node: true,
  },
  extends: ['eslint:recommended', 'plugin:vue/recommended'],
  parserOptions: {
  parser: '@babel/eslint-parser',
  requireConfigFile: false, 
  ecmaVersion: 2018,
  sourceType: 'module' 
},
  rules: {
    // 'no-console': 'warn',
    // 'no-unused-vars': 'error',
    // 'vue/require-default-prop': 'off',
  },
};