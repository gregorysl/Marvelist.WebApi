import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./components/App";
import { PreApp } from "./components/PreApp";
import reportWebVitals from "./reportWebVitals";
import configureStore from "./store/configureStore";
import { LocaleProvider } from "antd";
// import { ConnectedRouter } from "react-router-redux";
import { Provider } from "react-redux";

import enUS from "antd/lib/locale-provider/en_US";
import "antd/dist/antd.less";
import "./styles/main.less";
// require("./favicon.ico");

const store = configureStore();

ReactDOM.render(
  <React.StrictMode>
    <LocaleProvider locale={enUS}>
      <Provider store={store}>
        <PreApp />
      </Provider>
    </LocaleProvider>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
