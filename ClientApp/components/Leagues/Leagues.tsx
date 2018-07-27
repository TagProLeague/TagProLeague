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

        fetch('api/Leagues/Current')
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
            {contents}
        </div>;
    }

    private static renderLeaguesTable(leagues: League[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                {leagues.map(league =>
                    <tr key={league.name}>
                        <td>{league.name}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

interface League {
    name: string;
}
