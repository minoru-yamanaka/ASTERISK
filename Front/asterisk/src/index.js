// Libs
import React from 'react';
import ReactDOM from 'react-dom';
import {BrowserRouter as Router, Redirect, Route, Switch} from "react-router-dom";

// Services
import {parseJwt, userAuthentication} from './services/Auth';

// Styles
import './assets/styles/index.css';

// Pages
import Login from './pages/Login/Login';
import Alerts from './pages/Alerts/Alerts';
import Camera from './pages/Camera/Camera';
import NotFound from './pages/NotFound/NotFound';


const Restrict = ({component : Component}) => (
  <Route 
    render = {props =>
      userAuthentication() && parseJwt().role === "Administrator" || userAuthentication() && parseJwt().role === "Guest" ?
      <Component {...props} /> :
      <Redirect to="/" />
    }
  />
)

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} />
        <Route exact path="/alerts" component={Alerts} />
        <Route exact path="/camera" component={Camera} />
        <Route exact path="/notfound" component={NotFound} />
        <Redirect to="/notfound" />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));