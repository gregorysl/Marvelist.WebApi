import React, { useEffect } from "react";
import { connect } from "react-redux";
import {
  fetchSeriesById,
  folllowComic,
  folllowSeries,
  readAllComic,
} from "../../actions/seriesActions";
import Card from "../card/Card";
import DetailsHeader from "./DetailsHeader";
import { Grid } from "@material-ui/core";

const SeriesDetails = ({
  fetchById,
  match,
  seriesDetails,
  follow,
  folllowSeries,
  readAllComic,
}) => {
  const [data, setData] = React.useState(seriesDetails);
  useEffect(() => {
    fetchById(match.params.id);
  }, [fetchById, match]);

  useEffect(() => {
    if (!!seriesDetails) {
      setData(seriesDetails);
    }
  }, [seriesDetails]);

  const mapped = data.comics.map((x, i) => (
    <Card key={i} follow={follow} data={x} />
  ));
  return (
    <div style={{ display: "flex", flexDirection: "column" }}>
      <DetailsHeader
        details={seriesDetails}
        folllowSeries={folllowSeries}
        readAllComic={readAllComic}
      />
      <Grid container spacing={2}>
        {mapped}
      </Grid>
    </div>
  );
};

const mapStateToProps = (state) => {
  return { seriesDetails: state.seriesDetails };
};

const mapDispatchToProps = (dispatch) => {
  return {
    fetchById: (seriesId) => dispatch(fetchSeriesById(seriesId)),
    folllowSeries: (seriesId) => dispatch(folllowSeries(seriesId, true)),
    readAllComic: (seriesId) => dispatch(readAllComic(seriesId)),
    follow: (comicId, seriesId) =>
      dispatch(folllowComic(comicId, false, seriesId)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(SeriesDetails);
