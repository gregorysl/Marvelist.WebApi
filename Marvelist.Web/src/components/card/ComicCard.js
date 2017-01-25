import React, {PropTypes} from 'react';
import {Link} from 'react-router';

class ComicCard extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        const url = require("file-loader!../../images/not_found.png");
        return (
            <div className="series-card col-sm-3 col-xs-4">
                <div className="cover">
                    <img className="base" src={url}/>
                    <img className="real" src={`${this.props.comic.thumbnail}`}/>
                    <div className="shadow-base"></div>
                    <div className="titles">
                        <h3>{this.props.comic.title}</h3>
                    </div>
                </div>
                <div className="date">
                    <span className="day">12</span>
                    <span className="month">Aug</span>
                    <span className="year">2016</span>
                </div>
                <div className="quick-icons">
                    <div className="actions">
                        <a>
                            <i className="fa fa-heart-o"></i>
                        </a>
                        <a href={this.props.comic.url} target="blank">
                            <i className="fa fa-external-link"></i>
                        </a>
                    </div>
                </div>
            </div>
        );
    }
}
ComicCard.propTypes = {
    comic: PropTypes.object.isRequired
};
export default ComicCard;