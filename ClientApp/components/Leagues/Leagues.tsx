import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import 'isomorphic-fetch';

interface LeaguesState {
    leagues: League[];
    loading: boolean;
    isHistoricalPage: boolean;
}

interface Params {
    argument: string;
}

export class Leagues extends React.Component<RouteComponentProps<{}>, LeaguesState> {
    constructor(props: any) {
        super(props);
        const params = this.props.match.params as Params;
        this.state = {
            leagues: [],
            loading: true,
            isHistoricalPage: (params.argument != undefined && params.argument.toLowerCase() == "historical")
        };

        if (this.state.isHistoricalPage)
        {
            fetch('api/Leagues/Historical')
                .then(response => response.json() as Promise<League[]>)
                .then(data => {
                    this.setState({ leagues: data, loading: false });
                });
        }
        else 
        {
            fetch('api/Leagues')
                .then(response => response.json() as Promise<League[]>)
                .then(data => {
                    this.setState({ leagues: data, loading: false });
                });
        }
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Leagues.renderLeaguesTable(this.state.leagues);

        let historicalLink = this.state.isHistoricalPage ? null : <a href='Leagues/Historical'>This links to historical leagues</a>

        return <div>
            <h1>Leagues</h1>
            <p>This component fetches leagues.</p>
            {historicalLink}
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
                        <td><Link className='' to={`/league/${league.name}`}>{league.name}</Link></td>
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
