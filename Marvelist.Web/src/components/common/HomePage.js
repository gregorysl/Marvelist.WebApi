import React from 'react';
import {Link} from 'react-router';

class HomePage extends React.Component {

  render() {
    const json = JSON.parse('{"Series":{"Description":null,"StartYear":2005,"EndYear":2006,"Rating":"","Id":3' +
        '45,"Modified":"0001-01-01T00:00:00","Url":"http://marvel.com/comics/series/345/x' +
        '-men_deadly_genesis_2005_-_2006?utm_campaign=apiRef&utm_source=867bc2e181b3a1467' +
        'cfc9d8265b4f785","Title":"X-Men: Deadly Genesis (2005 - 2006)","Thumbnail":"http' +
        '://i.annihil.us/u/prod/marvel/i/mg/c/00/4bc5fe8e21d02.jpg"},"Following":false}');

    return (
      <div className="row">
        <div className="row-lg-eq-height">
          <div className="card col-xs-5 col-sm-35 col-lg-3" id="series-div-16410">
            <img
              src={json.Series.Thumbnail}
              alt=""
              className="card-image"></img>

            <div className="post-meta-test followed-background">
              <span
                className="glyphicon glyphicon-heart followed follow-series"
                id="series-16410"></span>
            </div>

            <h4 className="sth">
              <a href="/Series/${json.Series.Id}">{json.Series.Title}</a>
            </h4>
          </div>
        </div>

      </div>
    );
  }
}

export default HomePage;
