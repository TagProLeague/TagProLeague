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
                <div style={bannerStyle} id='leagueBanner'>
                    <text style={labelStyle}><strong>{league.abbreviation}</strong></text>
                    <div style={subLabelStyle}>Est. {league.startedOn.substring(0, 4)}</div>
                    {/*<div>Season: {league.currentSeason}</div>
                    <div>Founder: {league.founder.name}</div>
                    <div>Status: {league.status}</div>*/}
                </div>
            )}
        </div>;
    }
}

const bannerStyle = {
    margin: '10px',
    padding: '10px',
    backgroundImage: 'linear-gradient(to left, rgba(255, 255, 255, .5), rgba(181, 194, 204, 0.75), rgba(7, 59, 94, 1))',
    height: '8em'
};

const labelStyle = {
    color: 'white',
    fontSize: '3.5em',
    fontFamily: 'Montserrat, sans-serif'
}

const subLabelStyle = {
    color: 'white',
    fontSize: '1em',
    fontFamily: 'Montserrat, sans-serif',
    marginTop: '-10px'
}
