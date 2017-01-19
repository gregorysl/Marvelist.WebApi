import React from 'react';
import {Link} from 'react-router';

const Header = (props) => {
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
          <a href="/">Marvelist</a>
        </div>
        <div className="navbar-collapse collapse">
          <ul className="nav navbar-nav">
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/about">About</Link>
            </li>
            <li>
              <Link to="/books">Book</Link>
            </li>
            <li>
              <Link to="/series">Series</Link>
            </li>
            <li>
              <label className="searchbox">
                <input
                  type="search"
                  placeholder="Search"
                  checked="checked"
                  id="search-input"
                  className="searchfield vcenter"/>
              </label>
            </li>
          </ul>

        </div>
      </div>
    </div>
  );
};

export default Header;
