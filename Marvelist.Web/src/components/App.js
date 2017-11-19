import React from 'react';
import PropTypes from 'prop-types';
import MyHeader from './common/Header';
import { Layout } from 'antd';
const { Header, Content } = Layout;

class App extends React.Component {
  render() {
    return (
      <Layout className="layout">
        <Header>
          <MyHeader />
        </Header>
        <Content style={{ padding: "0 50px" }}>
          {this.props.children}
        </Content>
      </Layout>

    );
  }
}

App.propTypes = {
  children: PropTypes.node.isRequired
};

export default App;