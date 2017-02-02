import React, { Component } from "react";
//import ErrorMessage from "./ErrorMessage"
//import LoadingButton from "./LoadingButton"


class Form extends Component {
  constructor(props) {
    super(props);


    this.state = { username: '', password: '' };
    this.handleChange = this.handleChange.bind(this);
    this._onSubmit = this._onSubmit.bind(this);
  }

  handleChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.id;

    this.setState({ [name]: value });
  }

  _onSubmit(event) {
    event.preventDefault();
    this.props.onSubmit(this.state.username, this.state.password);
  }
  render() {
    let {error} = this.props;

    // {error ? <ErrorMessage error={error} /> : null}
    return (
      <form className="form" onSubmit={this._onSubmit}>
        <div className="form__field-wrapper">
          <input
            className="form__field-input"
            type="text"
            id="username"
            value={this.state.username}
            onChange={this.handleChange}
            placeholder="frank.underwood"
            autoCorrect="off"
            autoCapitalize="off"
            spellCheck="false" />
          <label className="form__field-label" htmlFor="username">
            Username
          </label>
        </div>
        <div className="form__field-wrapper">
          <input
            className="form__field-input"
            id="password"
            type="password"
            value={this.state.password}
            onChange={this.handleChange}
            placeholder="••••••••••" />
          <label className="form__field-label" htmlFor="password">
            Password
          </label>
        </div>
        <div className="form__submit-btn-wrapper">
          {this.props.currentlySending ? (
            "sending"//  <LoadingButton />
          ) : (
              <button className="form__submit-btn" type="submit">
                {this.props.btnText}
              </button>
            )}
        </div>
      </form>
    );
  }

}

Form.propTypes = {
  onSubmit: React.PropTypes.func,
  btnText: React.PropTypes.string,
  error: React.PropTypes.string,
  currentlySending: React.PropTypes.bool
};

export default Form;
