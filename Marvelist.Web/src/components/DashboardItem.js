import React from "react";
import PropTypes from "prop-types";
import Title from "./card/Title";
import ActionsBar from "./card/ActionsBar";
import { PLACE } from "../actions/constants";
import Typography from "@material-ui/core/Typography";
import Box from "@material-ui/core/Box";

import CircularProgress from "@material-ui/core/CircularProgress";

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
class DashboardItem extends React.Component {
  constructor(props) {
    super(props);
    this.handleClick = this.handleClick.bind(this);
  }

  handleClick() {
    this.props.follow(this.props.data.id, this.props.data.seriesId);
  }

  render() {
    let percent =
      this.props.data.comicCount !== 0
        ? Math.round(
            (this.props.data.read / this.props.data.comicCount) * 100 * 10
          ) / 10
        : 100;
    return (
      <>
        {/* <img
              alt="thumbnail"
              className="img-dashboard"
              src={this.props.data.thumbnail}
            /> */}
        <ActionsBar click={this.handleClick} {...this.props.data} />
        <Title
          place={PLACE.SERIES}
          id={this.props.data.id}
          title={this.props.data.title}
        />
        <CircularProgressWithLabel value={percent} />
      </>
    );
  }
}

DashboardItem.propTypes = {
  toggleFollow: PropTypes.func,
  dashboard: PropTypes.bool,
  follow: PropTypes.func.isRequired,
  place: PropTypes.number,
  data: PropTypes.object.isRequired,
};

export default DashboardItem;
