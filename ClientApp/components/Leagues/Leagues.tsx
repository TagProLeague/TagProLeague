import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface LeaguesState {
    leagues: LeagueModel[];
    loading: boolean;
}

export class Leagues extends React.Component<RouteComponentProps<{}>, LeaguesState> {
    constructor(props: any) {
        super(props);

        this.state = {
            leagues: [],
            loading: true
        };

        this.loadLeagues();
    }

    loadLeagues = () => {
        fetch('api/leagues/')
            .then(response => response.json() as Promise<LeagueModel[]>)
            .then(data => {
                this.setState({
                    leagues: data,
                    loading: false
                });
            });
    }

    public render() {

        let leagueTable = this.state.loading
            ? <p><em>Loading...</em></p>
            : Leagues.renderLeaguesTable(this.state.leagues);
       
        return <div>
            <h1>Leagues</h1>
            <p>This component fetches leagues.</p>
            {leagueTable}
        </div>;
    }
    
    private static renderLeaguesTable(leagues: LeagueModel[]) {
        return <div>
            {leagues.map(league =>
                <div key={league.id} style={divStyle}>
                    <strong>{league.name}</strong>
                    <div>Established: {league.startedOn}</div>
                    <div>Founder: {league.founder}</div>
                    <div>Status: {league.status}</div>
                </div>
            )}
        </div>;
    }
}

const divStyle = {
    margin: '10px',
    padding: '10px',
    backgroundColor: 'lightblue',
    border: '5px solid lightblue',
    borderRadius: '25px'
};