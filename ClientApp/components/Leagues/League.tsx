import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface LeagueState {
    league: LeagueModel;
    loading: boolean;
}

interface Params {
    leagueName: string;
}

export class League extends React.Component<RouteComponentProps<{}>, LeagueState> {
    constructor(props: any) {
        super(props);
        const params = this.props.match.params as Params;
        this.state = {
            league: { id: 1, name: "" },
            loading: true
        };

        fetch(`api/Leagues/${params.leagueName}`)
            .then(response => response.json() as Promise<LeagueModel>)
            .then(data => {
                this.setState({
                    league: data,
                    loading: false
                });
        });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : League.renderLeague(this.state.league);

        return <div>
            {contents}
        </div>;
    }

    private static renderLeague(league: LeagueModel) {
        return <h1>{league.name}</h1>;
    }
}
