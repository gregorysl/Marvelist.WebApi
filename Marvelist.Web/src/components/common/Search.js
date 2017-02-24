import React, { PropTypes } from "react";
import { Link, browserHistory } from "react-router";
import { connect } from "react-redux";
import { search } from "../../actions/seriesActions";
import { Input } from 'antd';

const Search = Input.Search;
class SearchBar extends React.Component {
    constructor(props) {
        super(props);
        this.onSearch = this.onSearch.bind(this);
    }

    onSearch(value) {
        browserHistory.push('/search/' + value);
    }
    render() {
        return (
            <Search placeholder="Search" style={{ width: 200 }} onSearch={this.onSearch} />
        );
    }
}

export default SearchBar;