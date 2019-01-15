import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface SeasonsState {
    seasons: SeasonModel[];
    loading: boolean;
}

interface Params {
    leagueName: string;
}

export class Seasons extends React.Component<RouteComponentProps<{}>, SeasonsState> {
    constructor(props: any) {
        super(props);
        const params = this.props.match.params as Params;
        this.state = {
            seasons: [],
            loading: true
        };

        fetch(`api/seasons/${params.leagueName}`)
            .then(response => response.json() as Promise<SeasonModel[]>)
            .then(data => {
                this.setState({
                    seasons: data,
                    loading: false
                });
            });
    }

    public render() {

        let leagueTable = this.state.loading
            ? <p><em>Loading...</em></p>
            : Seasons.renderSeasonsTable(this.state.seasons);
       
        return <div>
            <h1>Seasons</h1>
            <p>This component fetches seasons.</p>
            {leagueTable}
        </div>;
    }

    private static renderSeasonsTable(seasons: SeasonModel[]) {
        return <div>
            {seasons.map(season =>
                <div style={divStyle}>
                    <strong>{season.name}</strong>
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