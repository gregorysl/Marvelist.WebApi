import React from "react";
import { CardActions, IconButton, makeStyles } from "@material-ui/core";
import clsx from "clsx";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import LinkIcon from "@material-ui/icons/Link";

import FavoriteIcon from "@material-ui/icons/Favorite";

const useStyles = makeStyles((theme) => ({
  expand: {
    transform: "rotate(0deg)",
    marginLeft: "auto",
    transition: theme.transitions.create("transform", {
      duration: theme.transitions.duration.shortest,
    }),
  },
  expandOpen: {
    transform: "rotate(180deg)",
  },
  actions: {
    paddingTop: 0,
    paddingBottom: 0,
  },
}));
interface ActionsBarProps {
  handleClick: () => void;
  url?: string;
  description?: string;
  expanded: boolean;
  handleExpandClick: () => void;
}
const ActionsBar = ({
  handleClick,
  url,
  description,
  expanded,
  handleExpandClick,
}: ActionsBarProps) => {
  const classes = useStyles();
  return (
    <CardActions className={classes.actions} disableSpacing>
      <IconButton onClick={handleClick}>
        <FavoriteIcon />
      </IconButton>
      {url && (
        <a href={url} target="blank">
          <IconButton onClick={handleClick}>
            <LinkIcon />
          </IconButton>
        </a>
      )}
      {description && (
        <IconButton
          className={clsx(classes.expand, {
            [classes.expandOpen]: expanded,
          })}
          onClick={handleExpandClick}
          aria-expanded={expanded}
          aria-label="show more"
        >
          <ExpandMoreIcon />
        </IconButton>
      )}
    </CardActions>
  );
};

export default ActionsBar;
