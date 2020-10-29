import { createStyles, CssBaseline, makeStyles } from "@material-ui/core";
import React from "react";
import Header from "./common/Header";
import { Route, Switch } from "react-router-dom";
import { BrowserRouter } from "react-router-dom";
import Home from "../components/common/HomePage";
import Login from "../components/common/Login";
import Register from "../components/common/Register";
import Series from "../components/series/SeriesPage";
import Week from "../components/common/WeekPage";
import Dashboard from "../components/series/DashboardPage";
import SeriesDetails from "../components/series/SeriesDetailPage";

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

export const App = () => {
  const classes = useStyles();
  return (
    <BrowserRouter>
      <div className={classes.root}>
        <CssBaseline />
        <Header />
        <main className={classes.content}>
          <div className={classes.toolbar} />
          <Switch>
            <Route exact path="/" component={Home} />
            <Route path="/login" component={Login} />
            <Route path="/register" component={Register} />
            <Route path="/series/:id" component={SeriesDetails} />
            <Route path="/series" component={Series} />
            <Route path="/search/:text" component={Series} />
            <Route path="/week/:week?" component={Week} />
            <Route path="/y:year" component={Series} />
            <Route path="/dashboard" component={Dashboard} />
          </Switch>
        </main>
      </div>
    </BrowserRouter>
  );
};
