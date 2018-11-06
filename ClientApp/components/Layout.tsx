import * as React from 'react';
import { NavMenu } from './NavMenu';
import { Auth0Authentication } from 'ClientApp/auth/Auth0Authentication';

export interface LayoutProps {
    children?: React.ReactNode;
    auth: Auth0Authentication;
}

export class Layout extends React.Component<LayoutProps, {}> {
    public render() {
        return <div className='container-fluid'>
            <div className='row'>
                <div className='col-sm-3'>
                    <NavMenu auth={this.props.auth} />} />
                </div>
                <div className='col-sm-9'>
                    { this.props.children }
                </div>
            </div>
        </div>;
    }
}
