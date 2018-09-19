import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <div className='main-nav'>
                <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <Link className='navbar-brand' to={ '/' }>TagProLeague</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink to={'/login'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-globe'></span> Login
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-home'></span> Home
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/matchmaking'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-random'></span> Matchmaking
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/games'} activeClassName='active'>
                                <span className='glyphicon glyphicon-king'></span> Games
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/leagues'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-queen'></span> Leagues
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/tournaments'} exact activeClassName='active'>
                                <span className='glyphicon glyphicon-knight'></span> Tournaments
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/players'} activeClassName='active'>
                                <span className='glyphicon glyphicon-pawn'></span> Players
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/maps'} activeClassName='active'>
                                <span className='glyphicon glyphicon-map-marker'></span> Maps
                            </NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </div>;
    }
}
