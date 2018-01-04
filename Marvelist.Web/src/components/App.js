import React from 'react';
import MyHeader from './common/Header';
import { Layout } from 'antd';
import { Route, Switch } from 'react-router-dom';
import Home from '../components/common/HomePage';
import Login from '../components/common/Login';
import Register from '../components/common/Register';
import About from '../components/common/AboutPage';
import Series from '../components/series/SeriesPage';
import Dashboard from '../components/series/DashboardPage';
import SeriesDetails from '../components/series/SeriesDetailPage';
const { Header, Content } = Layout;

class App extends React.Component {
  render() {
    return (
      <Layout className="layout">
        <Header>
          <MyHeader />
        </Header>
        <Content style={{ padding: "0 50px" }}>
        <Switch>
          <Route exact path='/' component={Home} />
          <Route path="/about" component={About} />
          <Route path="/login" component={Login} />
          <Route path="/register" component={Register} />
          <Route path="/series/:id" component={SeriesDetails} />
          <Route path="/series" component={Series} />
          <Route path="/search/:text" component={Series} />
          <Route path="/y:year" component={Series} />
          <Route path="/dashboard" component={Dashboard} />
        </Switch>
        </Content>
      </Layout>

    );
  }
}


export default App;