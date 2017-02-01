import React, {PropTypes} from 'react';
import {connect} from 'react-redux';
import {Link} from 'react-router';
import { folllowSeries} from '../../actions/seriesActions';

class SeriesCard extends React.Component {
    constructor(props) {
        super(props);
    this.toggleFollow = this
      .toggleFollow
      .bind(this);
    }

  toggleFollow() {
    this.props.follow(this.props.series.id);
  }
    render() {
        const url = require("file-loader!../../images/not_found.png");
        return (
            <div className="series-card col-sm-3 col-xs-4">
                <div className="cover">
                    <img className="base" src={url}/>
                    <img className="real" src={`${this.props.series.thumbnail}`}/>
                    <div className="shadow-base"></div>
                    <div className="titles">
                        <h3>
                            <a href={`/Series/${this.props.series.id}`}>{this.props.series.title}</a>
                        </h3>
                    </div>
                </div>
                <div className="quick-icons">
                    <div className="actions">
                        <a>
                            {this.props.series.following? <i className="fa fa-heart" ></i>:<i className="fa fa-heart-o" onClick={this.toggleFollow}></i>}
                        </a>
                        <a href={this.props.series.url} target="blank">
                            <i className="fa fa-external-link"></i>
                        </a>
                    </div>
                    <div className="metadata">
                        {this.props.series.comicCount}
                        <i className="fa fa-folder-o"></i>
                    </div>
                </div>
            </div>
        );
    }
}

const mapStateToProps = (state, ownProps) => {
  return {};
};

const mapDispatchToProps = (dispatch) => {
  return {
    follow: (id) => dispatch(folllowSeries(id))
  };
};

SeriesCard.propTypes = {
    series: PropTypes.object.isRequired,
  follow: PropTypes.func.isRequired
};
export default connect(mapStateToProps, mapDispatchToProps)(SeriesCard);