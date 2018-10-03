import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import 'isomorphic-fetch';

interface LeaguesState {
    leagues: LeagueModel[];
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
            isHistoricalPage: false
        };

        this.loadLeagues();
    }

    loadLeagues = () => {
        fetch('api/Leagues/')
            .then(response => response.json() as Promise<LeagueModel[]>)
            .then(data => {
                this.setState({
                    leagues: data,
                    loading: false,
                    isHistoricalPage: false
                });
            });
    }

    loadHistoricalLeagues = () => {
        fetch('api/Leagues/Historical')
            .then(response => response.json() as Promise<LeagueModel[]>)
            .then(data => {
                this.setState({
                    leagues: data,
                    loading: false,
                    isHistoricalPage: true
                });
            });
    }

    public render() {
        var titleText = <h1>Leagues</h1>;
        var bodyText = <p>This component fetches leagues.</p>
        var link = <button onClick={this.loadHistoricalLeagues}>This link fetches historical leagues</button>;

        if (this.state.isHistoricalPage)
        {
            titleText = <h1>Historical Leagues</h1>
            bodyText = <p>This component fetches historical leagues.</p>
            link = <button onClick={this.loadLeagues}>This link fetches active leagues</button>;
        }

        let leagueTable = this.state.loading
            ? <p><em>Loading...</em></p>
            : Leagues.renderLeaguesTable(this.state.leagues);
       
        return <div>
            {titleText}
            {bodyText}
            {link}
            {leagueTable}
        </div>;
    }
    
    private static renderLeaguesTable(leagues: LeagueModel[]) {
        return <div>
            {leagues.map(league =>
                <div style={divStyle}>
                    <strong>{league.name}</strong>
                    <div>Est {league.startedOn}</div>
                    <div>Season: {league.currentSeason}</div>
                    <div>Founder: {league.founder.name}</div>
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