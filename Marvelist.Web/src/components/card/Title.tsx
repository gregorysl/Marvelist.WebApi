import React from "react";
import { PLACE } from "../../actions/constants";
import { Typography } from "@material-ui/core";

interface TitleProps {
  place: number;
  id?: number;
  title: string;
}

const Title = ({ place, id, title }: TitleProps) => {
  let finalTitle = null;
  switch (place) {
    case PLACE.HOME:
    case PLACE.SERIES:
      finalTitle = <a href={`/Series/${id}`}>{title}</a>;
      break;
    default:
      finalTitle = title;
      break;
  }
  return <Typography variant="body2">{title}</Typography>;
};

export default Title;
