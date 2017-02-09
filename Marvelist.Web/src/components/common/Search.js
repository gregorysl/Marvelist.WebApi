import React, { PropTypes } from "react";
import { Link } from "react-router";
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
        this.props.search(this.state.text);
    }
    handleChange(event) {
        const target = event.target;
        const value = target.value;
        const name = target.id;

        this.setState({ [name]: value });
    }
    render() {
        return (
            <div>
                <form onSubmit={this._onSubmit}>
                    <input type="text" className="form-control" id="text" value={this.state.text} onChange={this.handleChange} placeholder="Search"  />
                </form>

            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        data: state.user
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        search: (text) => dispatch(search(text))
    };
};

Search.propTypes = {
    data: PropTypes.object.isRequired,
    search: PropTypes.func.isRequired
};


export default connect(mapStateToProps, mapDispatchToProps)(Search);