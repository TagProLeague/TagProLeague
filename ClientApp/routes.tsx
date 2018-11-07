import * as React from 'react';
import { Route, RouteComponentProps, Switch, Redirect  } from 'react-router-dom';
import { Layout } from './Components/Layout';
import { League, Leagues } from './components/Leagues/index';
import { WebAuthentication } from './auth/WebAuthentication';
import Home from './Components/Home/Home';

const auth = new WebAuthentication();

export const routes = <Layout auth={auth}>
    <Switch>
        <Route exact path="/" component={Home} />
        <Route path='/leagues/' component={Leagues} />
        <Route path='/leagues/:leagueName' component={League} />
        <Route path="/callback" render={() => {
            if (/access_token|id_token|error/.test(location.hash))
                auth.handleAuthentication();
            return <Redirect to="/" />;
        }} />
    </Switch>
</Layout>;
