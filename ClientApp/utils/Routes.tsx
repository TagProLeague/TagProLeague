import history from './history';
import * as React from 'react';
import { SFC } from 'react';
import { App } from '../Components/App/App';
import { Callback } from '../Components/Callback/Callback';
import { Home } from '../Components/Home/Home';
import { Route, RouteComponentProps } from 'react-router';
import { Router } from 'react-router-dom';
import { WebAuthentication } from '../Auth/WebAuthentication';

const auth = new WebAuthentication();

const handleAuthentication = (props: RouteComponentProps<{}>) => {
	if (/access_token|id_token|error/.test(location.hash)) {
		auth.handleAuthentication();
	}
};

const Routes: SFC<{}> = () => {
	return (
		<Router history={history}>
			<div>
				<Route path="/" render={props => <App auth={auth} {...props} />} />
				<main role="main">
					<Route
						path="/home"
						render={props => <Home auth={auth} {...props} />}
					/>
					<Route
						path="/callback"
						render={props => {
							handleAuthentication(props);
							return <Callback {...props} />;
						}}
					/>
				</main>
			</div>
		</Router>
	);
};
export default Routes;