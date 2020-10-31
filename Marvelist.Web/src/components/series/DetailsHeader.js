import React from "react";
import ReadAllButton from "./ReadAllButton";
import FollowButton from "./FollowButton";
import CircularProgress from "@material-ui/core/CircularProgress";
import Typography from "@material-ui/core/Typography";
import Box from "@material-ui/core/Box";
import { makeStyles } from "@material-ui/core/styles";
import { Grid } from "@material-ui/core";

function CircularProgressWithLabel(props) {
  return (
    <Box position="relative" display="inline-flex">
      <CircularProgress variant="determinate" {...props} />
      <Box
        top={0}
        left={0}
        bottom={0}
        right={0}
        position="absolute"
        display="flex"
        alignItems="center"
        justifyContent="center"
      >
        <Typography variant="caption" color="textPrimary">{`${Math.round(
          props.value
        )}%`}</Typography>
      </Box>
    </Box>
  );
}
const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  paper: {
    padding: theme.spacing(2),
    margin: "auto",
    maxWidth: 500,
  },
  image: {
    width: 200,
    height: 200,
  },
  img: {
    margin: "auto",
    display: "block",
    maxWidth: "100%",
    maxHeight: "100%",
  },
}));
const DetailsHeader = ({ folllowSeries, readAllComic, details }) => {
  let percent =
    Math.round((details.read / details.comicCount) * 100 * 100) / 100;
  const classes = useStyles();
  return (
    <>
      <Grid container direction="horizontal">
        <Grid item>
          <img style={{ height: "100%" }} src={details.thumbnail} alt="" />
        </Grid>
        <Grid item>
          <Grid container direction="vertical">
            <Grid item>
              {details.following && (
                <CircularProgressWithLabel value={percent} />
              )}
            </Grid>
            <Grid item>
              <Typography variant="h5" color="textPrimary">
                {details.title}
              </Typography>
            </Grid>
            <Grid item>
              <FollowButton
                following={details.following}
                click={folllowSeries}
                id={details.id}
              />
              <ReadAllButton
                following={details.following}
                percent={percent}
                click={readAllComic}
                id={details.id}
              />
            </Grid>
            <Grid item>
              <p>{details.details}</p>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </>
  );
};

export default DetailsHeader;
