import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { League, Leagues, HistoricalLeagues } from './components/Leagues/index';
import { Counter } from './components/Counter';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/counter' component={Counter} />
    <Route exact path='/leagues/' component={Leagues} />
    <Route exact path='/leagues/historical' component={HistoricalLeagues} />
    <Route exact path='/leagues/:leagueName' component={League} />
</Layout>;
