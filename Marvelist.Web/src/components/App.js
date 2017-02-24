import React, { PropTypes } from 'react';
import HeaderMy from './common/Header';
import { Layout, Menu, Breadcrumb } from 'antd';
const { Header, Content, Footer } = Layout;

class App extends React.Component {
  render() {
    return (
      <Layout className="layout">
        <Header>
          <HeaderMy />
        </Header>
        <Content style={{ padding:"0 50px"}}>
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