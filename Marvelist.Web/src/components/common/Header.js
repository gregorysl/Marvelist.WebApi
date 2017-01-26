import React from 'react';
import {Link} from 'react-router';

const Header = (props) => {
  let url = require("../../images/logo.svg");
  return (
    <div className="navbar navbar-inverse navbar-fixed-top navbar-marvel">
      <div className="container">
        <div className="navbar-header">
          <button
            type="button"
            className="navbar-toggle"
            data-toggle="collapse"
            data-target=".navbar-collapse">
            <span className="icon-bar"></span>
            <span className="icon-bar"></span>
            <span className="icon-bar"></span>
          </button>
          <a href="/"><img className="logo" src ={url}/></a>
        </div>
        <div className="navbar-collapse collapse">
          <ul className="nav navbar-nav">
            <li>
              <Link to="/about">About</Link>
            </li>
            <li>
              <Link to="/books">Book</Link>
            </li>
            <li>
              <Link to="/series">Series</Link>
            </li>
          </ul>

        </div>
      </div>
    </div>
  );
};

export default Header;
