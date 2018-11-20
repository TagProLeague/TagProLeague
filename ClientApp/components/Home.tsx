import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
	render() {
		return (
            <div className="jumbotron">
                <h1>Welcome Home!</h1>
			</div>
		);
	}
}

export default Home;