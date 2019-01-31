import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface TeamState {
    team: TeamModel;
    loading: boolean;
}

interface Params {
    teamName: string;
}

export class Team extends React.Component<RouteComponentProps<{}>, Partial<TeamState>> {
    constructor(props: any) {
        super(props);
        const params = this.props.match.params as Params;
        this.state = {
            loading: true
        };

        fetch(`api/teams/${params.teamName}`)
            .then(response => response.json() as Promise<TeamModel>)
            .then(data => {
                this.setState({
                    team: data,
                    loading: false
                });
        });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Team.renderTeam(this.state.team!!);

        return <div>
            {contents}
        </div>;
    }

    private static renderTeam(team: TeamModel) {
        return <div>
            <h1>{team.fullName}</h1>
            <p>{team.status}</p>
            </div>;
    }
}
