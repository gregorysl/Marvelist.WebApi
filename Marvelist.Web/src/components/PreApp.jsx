import React from "react";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import { App2 } from "./App2";

export const PreApp = () => (
  <BrowserRouter>
    <>
      <App2 />
      <App />
    </>
  </BrowserRouter>
);
