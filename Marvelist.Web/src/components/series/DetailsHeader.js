import React from "react";
import PropTypes from "prop-types";
import ReadAllButton from "./ReadAllButton";
import FollowButton from "./FollowButton";
import { Row, Col, Progress } from "antd";

class DetailsHeader extends React.Component {
  render() {
    const details = this.props.details;
    let percent =
      Math.round((details.read / details.comicCount) * 100 * 100) / 100;
    let { folllowSeries, readAllComic } = this.props;
    return (
      <Row type="flex" justify="center" style={{ paddingTop: "20px" }}>
        <Col md={5} sm={8} style={{ height: "340px" }}>
          <img style={{ height: "100%" }} src={details.thumbnail} alt="" />
        </Col>
        {details.following && (
          <Col md={3} sm={6} xs={24}>
            <Progress type="circle" percent={percent} />
          </Col>
        )}
        <Col md={8} sm={6}>
          <h2>{details.title}</h2>
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
          <p>{details.details}</p>
        </Col>
      </Row>
    );
  }
}
DetailsHeader.propTypes = {
  details: PropTypes.object.isRequired,
  folllowSeries: PropTypes.func.isRequired,
  readAllComic: PropTypes.func.isRequired,
};

export default DetailsHeader;
