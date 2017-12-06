import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';

export default class TipDetail extends React.Component<RouteComponentProps<{}>, {}> {

    public render() {
        return <form>
            <div className='form-group'>
                <label htmlFor='tipName'>Tip Name</label>
                <input type='text' className='form-control' id='tipName' aria-describedby='tipHelp' placeholder='Enter tip name' />
                <small id='tipNameHelp' className='form-text text-muted'>The name of the tip to be used as an ID, no whitepace.</small>
            </div>
        </form>
    }
}