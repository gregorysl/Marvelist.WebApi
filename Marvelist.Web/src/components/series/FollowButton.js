import React from "react";
import { Button } from "@material-ui/core";

const FollowButton = ({ click, following, id, percent }) => {
  if (!following) return <></>;
  const disabled = percent === 100;

  const text = following ? "Following" : "Follow";
  return (
    <Button
      variant="contained"
      color="primary"
      onClick={() => click(id)}
      disabled={disabled}
    >
      {text}
    </Button>
  );
};

export default FollowButton;
