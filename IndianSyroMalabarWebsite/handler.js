const express = require('express');
const serverless = require('serverless-http');

const app = express();

// Route for the home page
app.get('/', (req, res) => {
  res.send('<h1>Hello World!</h1>');
});

// Export the Express app wrapped in serverless-http
module.exports.handler = serverless(app);

