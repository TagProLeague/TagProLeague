import autobind from 'autobind-decorator';
import * as React from 'react';
import { Component } from 'react';
import { Auth0Authentication } from '../../auth/Auth0Authentication';
import { NavLink } from 'react-router-dom';

export interface AppProps {
	auth: Auth0Authentication;
}
export class App extends Component<AppProps, {}> {
	@autobind
	login() {
		this.props.auth.login();
	}

	@autobind
	logout() {
		this.props.auth.logout();
	}

	render() {
		const { authenticated } = this.props.auth;
		return (
			<nav className="navbar navbar-expand navbar-dark bg-dark">
				<NavLink className="navbar-brand" to="/">
					Auth0 - React
        </NavLink>
				<ul className="navbar-nav mr-auto">
					<li className="nav-item">
						<NavLink className="nav-link" to="/home" activeClassName="active">
							Home
            </NavLink>
					</li>
				</ul>
				<ul className="navbar-nav ml-auto">
					{!authenticated && (
						<li className="nav-item">
							<button
								className="btn btn-outline-primary my-2 my-sm-0"
								type="submit"
								onClick={this.login}
							>
								Log In
              </button>
						</li>
					)}
					{authenticated && (
						<li className="nav-item">
							<button
								className="btn btn-outline-primary my-2 my-sm-0"
								type="submit"
								onClick={this.logout}
							>
								Log Out
              </button>
						</li>
					)}
				</ul>
			</nav>
		);
	}
}

export default App;