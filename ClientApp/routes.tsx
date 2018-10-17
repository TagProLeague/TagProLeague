import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { League, Leagues } from './components/Leagues/index';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route exact path='/leagues/' component={Leagues} />
    <Route exact path='/leagues/:leagueName' component={League} />
</Layout>;
