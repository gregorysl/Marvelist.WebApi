import React from 'react';
import {Link} from 'react-router';

class SeriesCard extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="card col-xs-5 col-sm-35 col-lg-3" id="series-div-16410">
                <img
                    src={`${this.props.series.Series.Thumbnail.Path}.jpg`}
                    alt=""
                    className="card-image"></img>

                <div className="post-meta-test followed-background">
                    <span
                        className="glyphicon glyphicon-heart followed follow-series"
                        id="series-16410"></span>
                </div>

                <h4 className="sth">
                    <a href={`/Series/${this.props.series.Series.Id}`}>{this.props.series.Series.Title}</a>
                </h4>
            </div>
        );
    }
}

export default SeriesCard;