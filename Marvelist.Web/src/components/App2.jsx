import { createStyles, CssBaseline, makeStyles } from "@material-ui/core";
import React from "react";
import Header from "./common/Header";
import { BrowserRouter } from "react-router-dom";

const useStyles = makeStyles((theme) =>
  createStyles({
    root: {
      display: "flex",
      flexDirection: "column",
    },
    content: {
      flexGrow: 1,
      padding: theme.spacing(2),
    },
    toolbar: theme.mixins.toolbar,
  })
);

export const App2 = () => {
  const classes = useStyles();
  return (
    <div className={classes.root}>
      <CssBaseline />
      <Header />
      <main className={classes.content}>
        {/* <div className={classes.toolbar} /> */}
        <h1>asd</h1>
      </main>
    </div>
  );
};
