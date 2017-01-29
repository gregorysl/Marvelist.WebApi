import React from 'react';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {loginRequest,changeForm} from '../../actions/userActions';
import Form from './Form';

class HomePage extends React.Component {
  constructor (props) {
    super(props)

    this._login = this._login.bind(this)
  }

  render() {
    let {dispatch} = this.props
    let {formState, currentlySending, error} = this.props.data


    return (
      <div className='form-page__wrapper'>
        <div className='form-page__form-wrapper'>
          <div className='form-page__form-header'>
            <h2 className='form-page__form-heading'>Login</h2>
          </div>
          <Form data={formState} dispatch={dispatch} history={this.props.history} onSubmit={this._login} btnText={'Login'} error={error} currentlySending={currentlySending} />
        </div>
      </div>
    );
  }
  _login (username, password) {
    this.props.dispatch(loginRequest({username, password}))
  }
}

function select (state) {
  return {
    data: state.user
  }
}


export default connect(select)(HomePage);
