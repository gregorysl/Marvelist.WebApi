import React from "react";
import PropTypes from "prop-types";
import Title from "./Title";
import CoverDate from "./CoverDate";
import url from "../../images/not_found.png";

const Cover = (props) => {
  return (
    <div className="[ info-card ]">
      {props.date && <CoverDate comicDate={props.date} />}
      <img alt="background" className="basea" src={url} />
      {/* <img alt="cover" src={props.thumbnail} /> */}
      <div className="[ info-card-details ] animate">
        <Title place={props.place} {...props} />
        <p className="[ info-card-detail ]">{props.description}</p>
      </div>
    </div>
  );
};

Cover.propTypes = {
  id: PropTypes.number,
  date: PropTypes.string,
  thumbnail: PropTypes.string.isRequired,
  description: PropTypes.string.isRequired,
  place: PropTypes.number,
};

export default Cover;
