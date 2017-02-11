import React, { PropTypes } from "react";
import { Link, browserHistory } from "react-router";
import { connect } from "react-redux";
import { search } from "../../actions/seriesActions";

class Search extends React.Component {
    constructor(props) {
        super(props);
        this.state = { text: '' };
        this.handleChange = this.handleChange.bind(this);
        this._onSubmit = this._onSubmit.bind(this);
    }

    _onSubmit(event) {
        event.preventDefault();
        browserHistory.push('/Search/' + this.state.text);
    }
    handleChange(event) {
        this.setState({ text: event.target.value });
    }
    render() {
        return (
                <form onSubmit={this._onSubmit}>
                    <input type="text" className="form-control" id="text" value={this.state.text} onChange={this.handleChange} placeholder="Search" />
                </form>
        );
    }
}

Search.propTypes = {
};


export default Search;