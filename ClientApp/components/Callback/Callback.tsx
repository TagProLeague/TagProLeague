import * as React from 'react';
import { CSSProperties, SFC } from 'react';
const loading = require('./loading.svg');

export interface CallbackProps { }

export const Callback: SFC<CallbackProps> = props => {
	const style: CSSProperties = {
		position: 'absolute',
		display: 'flex',
		justifyContent: 'center',
		height: '100vh',
		width: '100vw',
		top: 0,
		bottom: 0,
		left: 0,
		right: 0,
		backgroundColor: 'white',
	};

	return (
		<div style={style}>
			<img src={loading} alt="loading" />
		</div>
	);
};
export default Callback;