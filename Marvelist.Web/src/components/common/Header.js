import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import IconButton from "@material-ui/core/IconButton";
import InputBase from "@material-ui/core/InputBase";
import SearchIcon from "@material-ui/icons/Search";
import AccountCircle from "@material-ui/icons/AccountCircle";
import url from "../../images/logo.svg";
import { Link, useHistory } from "react-router-dom";
import { logout } from "../../actions/userActions";
import { connect } from "react-redux";

const useStyles = makeStyles((theme) => ({
  grow: {
    flexGrow: 1,
  },
}));

const Header = ({ user, logout }) => {
  const classes = useStyles();
  const history = useHistory();
  const onSearch = (event, a, s, d) => {
    history.push("/search/" + event.target[0].value);
    event.preventDefault();
  };
  let navButtons = user.loggedIn ? (
    <>
      <Link to="/dashboard">{user.username}</Link>
      <a href="#" onClick={() => logout()}>
        Logout
      </a>
    </>
  ) : (
    <>
      <Link to="/register">Register</Link>
      <Link to="/login">Login</Link>
    </>
  );
  return (
    <AppBar className={classes.grow} position="static">
      <Toolbar>
        <Link to="/">
          <img alt="logo" className="logo" src={url} />
        </Link>
        <Link to="/week">Weekly pull</Link>
        <Link to="/series">Series</Link>
        <form onSubmit={onSearch}>
          <InputBase placeholder="Search" />
          <IconButton type="submit">
            <SearchIcon />
          </IconButton>
        </form>

        <div className={classes.grow} />
        {navButtons}
        <div className={classes.sectionDesktop}>
          <IconButton
            edge="end"
            aria-label="account of current user"
            aria-haspopup="true"
            color="inherit"
          >
            <AccountCircle />
          </IconButton>
        </div>
      </Toolbar>
    </AppBar>
  );
};

const mapStateToProps = (state) => {
  return { user: state.user };
};

const mapDispatchToProps = (dispatch) => {
  return {
    logout: () => dispatch(logout()),
  };
};
export default connect(mapStateToProps, mapDispatchToProps)(Header);
