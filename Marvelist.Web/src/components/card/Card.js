import React, { useState } from "react";
import PropTypes from "prop-types";
import {
  Card,
  CardContent,
  CardHeader,
  CardMedia,
  Collapse,
  Grid,
  makeStyles,
  Typography,
} from "@material-ui/core";
import url from "../../images/not_found.png";
import Title from "./Title";
import CoverDate from "./CoverDate";
import ActionsBar from "./ActionsBar";

const useStyles = makeStyles((theme) => ({
  root: {
    maxWidth: 300,
  },
  media: {
    objectFit: "contain",
    backgroundImage: `url("${url}")`,
  },
  description: {
    paddingTop: 0,
  },
  header: {
    paddingTop: theme.spacing(1),
    paddingBottom: theme.spacing(1),
  },
}));
const MarvelistCard = ({
  toggleFollow,
  dashboard,
  follow,
  place,
  data,
  week,
}) => {
  const classes = useStyles();
  const [expanded, setExpanded] = useState(false);

  const handleExpandClick = () => {
    setExpanded(!expanded);
  };
  const handleClick = () => {
    if (week) {
      follow(data.id, data.seriesId, week);
    } else {
      follow(data.id, data.seriesId);
    }
  };

  return (
    <Grid item xs={3}>
      <Card className={classes.root}>
        <CardHeader
          className={classes.header}
          disableTypography
          title={
            <Title
              place={place}
              title={data.title}
              id={data.seriesId || data.id}
            />
          }
          subheader={<CoverDate date={data.date} />}
        />
        <CardMedia
          component="img"
          className={classes.media}
          image={data.thumbnail}
          title={data.title}
        />
        <ActionsBar
          url={data.url}
          description={data.description}
          handleClick={handleClick}
          handleExpandClick={handleExpandClick}
          expanded={expanded}
        />

        <Collapse in={expanded} timeout="auto" unmountOnExit>
          <CardContent className={classes.description}>
            <Typography paragraph>{data.description}</Typography>
          </CardContent>
        </Collapse>
      </Card>
    </Grid>
  );
};

MarvelistCard.propTypes = {
  toggleFollow: PropTypes.func,
  dashboard: PropTypes.bool,
  follow: PropTypes.func.isRequired,
  place: PropTypes.number,
  data: PropTypes.object.isRequired,
};

export default MarvelistCard;
