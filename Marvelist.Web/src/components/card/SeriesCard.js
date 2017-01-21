import React, {PropTypes} from 'react';
import {Link} from 'react-router';

class SeriesCard extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        const url = require("file-loader!../../images/not_found.png");
        return (
            <div className="grid-item col-sm-3 col-xs-4">
                <div className="cover">
                    <img className="base" src={url}/>
                    <img className="real" src={`${this.props.series.Series.Thumbnail.Path}.jpg`}/>
                    <div className="shadow-base"></div>
                    <div className="titles">
                        <h3>
                            <a href={`/Series/${this.props.series.Series.Id}`}>{this.props.series.Series.Title}</a>
                        </h3>
                    </div>
                </div>
                <div className="quick-icons">
                    <div className="actions">
                        <a className="watch">
                            <div className="base"></div>
                            <div className="fa fa-heart rating-8"></div>
                        </a>
                    </div>
                    <div className="metadata">
                        <div className="percentage" data-original-title="" title="">
                            <div className="fa fa-heart rating-8"></div>81%</div>
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