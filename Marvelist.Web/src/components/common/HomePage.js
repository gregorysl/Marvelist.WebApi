import React, { useEffect } from "react";
import { connect } from "react-redux";
import Card from "../card/Card";
import { fetchHome, folllowComic } from "../../actions/seriesActions";
import { PLACE } from "../../actions/constants";
import { Grid } from "@material-ui/core";

const HomePage = ({ user, fetch, home, follow }) => {
  const [data, setData] = React.useState(home);
  useEffect(() => {
    if (user.loggedIn) {
      fetch();
    }
  }, [user, fetch]);

  useEffect(() => {
    if (!!home) {
      setData(home);
    }
  }, [home]);

  const mapped = data.map((b, i) => (
    <Card key={i} follow={follow} data={b} place={PLACE.HOME} />
  ));

  return (
    <Grid container spacing={2}>
      {mapped}
    </Grid>
  );
};
const mapStateToProps = (state) => {
  return { home: state.homeComics, user: state.user };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetch: () => dispatch(fetchHome()),
    follow: (id, seriesId) => dispatch(folllowComic(id, PLACE.HOME, seriesId)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(HomePage);
