import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface TeamsState {
    teams: TeamModel[];
    loading: boolean;
}

export class Teams extends React.Component<RouteComponentProps<{}>, TeamsState> {
    constructor(props: any) {
        super(props);

        this.state = {
            teams: [],
            loading: true
        };

        this.loadTeams();
    }

    loadTeams = () => {
        fetch('api/teams/')
            .then(response => response.json() as Promise<TeamModel[]>)
            .then(data => {
                this.setState({
                    teams: data,
                    loading: false
                });
            });
    }

    public render() {

        let teamTable = this.state.loading
            ? <p><em>Loading...</em></p>
            : Teams.renderTeamsTable(this.state.teams);
       
        return <div>
            <h1>Teams</h1>
            <p>This component fetches teams.</p>
            {teamTable}
        </div>;
    }
    
    private static renderTeamsTable(teams: TeamModel[]) {
        return <div>
            {teams.map(team =>
                <div key={team.id} style={divStyle}>
                    <strong>{team.fullName}</strong>
                    <div>Established: {team.startedOn}</div>
                    <div>Founder: {team.founder}</div>
                    <div>Status: {team.status}</div>
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