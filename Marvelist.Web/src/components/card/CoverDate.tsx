import React from "react";
import { Typography } from "@material-ui/core";

interface CoverDateProps {
  date: Date;
}
const CoverDate = ({ date }: CoverDateProps) => {
  return (
    <Typography variant="body2" color="textSecondary">
      {date}
    </Typography>
  );
};

export default CoverDate;
