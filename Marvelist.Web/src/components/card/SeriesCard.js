import React, {PropTypes} from 'react';
import {Link} from 'react-router';

class SeriesCard extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        const url = require("file-loader!../../images/not_found.png");
        return (
            <div className="series-card col-sm-3 col-xs-4">
                <div className="cover">
                    <img className="base" src={url}/>
                    <img className="real" src={`${this.props.series.Thumbnail}`}/>
                    <div className="shadow-base"></div>
                    <div className="titles">
                        <h3>
                            <a href={`/Series/${this.props.series.Id}`}>{this.props.series.Title}</a>
                        </h3>
                    </div>
                </div>
                <div className="quick-icons">
                    <div className="actions">
                        <a>
                            <i className="fa fa-heart-o"></i>
                        </a>
                        <a href={this.props.series.Url}>
                            <i className="fa fa-external-link"></i>
                        </a>
                    </div>
                    <div className="metadata">
                        <span>{this.props.series.ComicCount}</span>
                        <i className="fa fa-folder-o"></i>
                    </div>
                </div>
            </div>
        );
    }
}
SeriesCard.propTypes = {
    series: PropTypes.object.isRequired
};
export default SeriesCard;