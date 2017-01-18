import React from 'react';
import { Link } from 'react-router';

const Header = (props) => {
  return ( 
    <div className="container">
      <nav className="navbar navbar-default">
        <div className="container-fluid">
          <div className="navbar-header">
            <a className="navbar-brand" href="#">Marvelist</a>
          </div>
          <div className="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul className="nav navbar-nav">
              <li><Link to="/">Home</Link></li>
              <li><Link to="/about">About</Link></li>
              <li><Link to="/books">Book</Link></li>
              <li><Link to="/series">Series</Link></li>
            </ul>
          </div>
        </div>
      </nav>
    </div>
  );
};

export default Header;
