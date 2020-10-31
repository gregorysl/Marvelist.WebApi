import React from "react";
import PropTypes from "prop-types";
import Cover from "./Cover";
import ActionsBar from "./ActionsBar";
import { Card, CardContent, Grid } from "@material-ui/core";

const MarvelistCard = ({ toggleFollow, dashboard, follow, place, data }) => {
  const handleClick = () => {
    const {
      props: { week, data, follow },
    } = this;
    if (week) {
      follow(data.id, data.seriesId, week);
    } else {
      follow(data.id, data.seriesId);
    }
  };

  // let percent =
  //   data.comicCount !== 0
  //     ? Math.round((data.read / data.comicCount) * 100 * 10) / 10
  //     : 100;

  // {/* Todo loader */}
  return (
    <Grid item xs={4}>
      <Card>
        <CardContent>
          <Cover place={place} {...data} />
          <ActionsBar click={() => handleClick()} {...data} />
        </CardContent>
        {/* {dashboard && <Progress percent={percent} />} */}
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
