import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface SeasonState {
    season: SeasonModel;
    loading: boolean;
}

interface Params {
    leagueName: string;
    seasonName: string;
}

export class Season extends React.Component<RouteComponentProps<{}>, Partial<SeasonState>> {
    constructor(props: any) {
        super(props);
        const params = this.props.match.params as Params;
        this.state = {
            loading: true
        };

        fetch(`api/seasons/${params.leagueName}/${params.seasonName}/`)
            .then(response => response.json() as Promise<LeagueModel>)
            .then(data => {
                this.setState({
                    season: data,
                    loading: false
                });
        });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Season.renderSeason(this.state.season!!);

        return <div>
            {contents}
        </div>;
    }

    private static renderSeason(season: SeasonModel) {
        return <div>
            <h1>{season.name}</h1>
            </div>;
    }
}
