import * as React from 'react';
import { Route, RouteComponentProps  } from 'react-router-dom';
import { Layout } from './Components/Layout';
import { League, Leagues } from './components/Leagues/index';
import { WebAuthentication } from './auth/WebAuthentication';
import { Callback } from './components/Callback/Callback';
import Home from './Components/Home/Home';

const auth = new WebAuthentication();

const handleAuthentication = (props: RouteComponentProps<{}>) => {
    if (/access_token|id_token|error/.test(location.hash)) {
      auth.handleAuthentication();
    }
  };
  

export const routes = <Layout auth={auth}>
    <Route exact path="/" component={Home} />
    <Route exact path="/callback" render={props => { handleAuthentication(props); return <Callback {...props} />; }} />
    <Route exact path='/leagues/' component={Leagues} />
    <Route exact path='/leagues/:leagueName' component={League} />
</Layout>;
