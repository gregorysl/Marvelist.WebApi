import React from "react";
import { Button } from "@material-ui/core";

const ReadAllButton = ({ click, following, id, percent }) => {
  if (!following) return <></>;
  const disabled = percent === 100;

  return (
    <Button
      variant="contained"
      color="primary"
      onClick={() => click(id)}
      disabled={disabled}
    >
      Mark all as read
    </Button>
  );
};

export default ReadAllButton;
