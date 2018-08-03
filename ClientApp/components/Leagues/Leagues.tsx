import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface LeaguesState {
    leagues: League[];
    loading: boolean;
}

export class Leagues extends React.Component<RouteComponentProps<{}>, LeaguesState> {
    constructor() {
        super();
        this.state = { leagues: [], loading: true };

        fetch('api/Leagues')
            .then(response => response.json() as Promise<League[]>)
            .then(data => {
                this.setState({ leagues: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Leagues.renderLeaguesTable(this.state.leagues);

        return <div>
            <h1>Leagues</h1>
            <p>This component fetches leagues.</p>
            <a href='Leagues/Historical'>This links to historical leagues</a>
            {contents}
        </div>;
    }

    private static renderLeaguesTable(leagues: League[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                {leagues.map(league =>
                    <tr key={league.id}>
                        <td>{league.id}</td>
                        <td>{league.name}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

interface League {
    id: number;
    name: string;
}
